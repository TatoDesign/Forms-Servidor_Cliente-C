using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;
using System.DirectoryServices.ActiveDirectory;

namespace SistemasFisicos_Cliente
{
    public partial class Form1 : Form
    {

        static ConcurrentQueue<string> values_rx = new ConcurrentQueue<string>();
        static ConcurrentQueue<string> values_tx = new ConcurrentQueue<string>();
        static bool activo;

        public Form1()
        {
            InitializeComponent();
            activo = true;
            button2.Enabled = false;
        }

        public void Mensaje()
        {
            if (values_rx.Count > 0)
            {
                string? dato;
                values_rx.TryDequeue(out dato);

                if (dato != null)
                {
                    Recibir.Text += (dato);
                }
            }
        }

        static void cliente()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");  //ip servidor
            EndPoint remote = new IPEndPoint(ip, 12345); //endpoint del servidor
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket configurado");

            socket.Connect(remote);

            Console.WriteLine("Conectado");
            try
            {
                while (activo == true)
                {
                    //recibiendo
                    if (socket.Available > 0)
                    {
                        byte[] data = new byte[socket.Available];
                        int len = socket.Receive(data);
                        if (len > 0)
                        {
                            string data_rx = Encoding.ASCII.GetString(data, 0, len);
                            values_rx.Enqueue(data_rx);
                        }
                    }

                    if (socket.Connected == false)
                    {
                        break;
                    }

                    //transmitiendo la cola
                    if (values_tx.Count > 0)
                    {
                        string? var_tx;
                        values_tx.TryDequeue(out var_tx);
                        if (var_tx != null)
                        {
                            byte[] enviar = Encoding.ASCII.GetBytes(var_tx);
                            socket.Send(enviar);
                        }
                    }
                    // Thread.Sleep(1000);
                    // Console.WriteLine("Esperando...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            socket.Close();
            socket.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread client = new Thread(new ThreadStart(cliente));
            client.Start();

            button1.Enabled = false;
            conexiones.Text += "Me conecte.";
            button2.Enabled = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            values_tx.Enqueue(Enviar.Text);
            Enviar.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Mensaje();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activo = false;
            conexiones.Text += "Me desconecte.";
            button2.Enabled = false;
        }
    }
}
