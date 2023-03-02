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

namespace SistemasFisicos_Servidor
{

    public partial class Form1 : Form
    {

        static ConcurrentQueue<string> values_rx = new ConcurrentQueue<string>();
        static ConcurrentQueue<string> values_tx = new ConcurrentQueue<string>();
        int control;

        public Form1()
        {
            control = 0;
            InitializeComponent();
            Mensaje();
        }

        public void Mensaje()
        {
            values_tx.Enqueue("Bienvenido a Preguntados");
            values_tx.Enqueue("\r\nResponde a, b o c!");
            values_tx.Enqueue("\r\nCuales son los colores de la bandera de colombia?");
            values_tx.Enqueue("\r\na. Amarillo, azul y rojo");
            values_tx.Enqueue("\r\nb. Verde, blanco y amarillo");
            values_tx.Enqueue("\r\nc. Lila, azul y rojo");
        }

        public void Mensaje2()
        {
            values_tx.Enqueue("\r\nQue significa UPB?");
            values_tx.Enqueue("\r\na. Universidad Para Bobos");
            values_tx.Enqueue("\r\nb. Uvas Peras Bananos");
            values_tx.Enqueue("\r\nc. Universidad Pontificia Bolivariana");

            control = 1;
           
        }

        public void Mensaje3()
        {
            values_tx.Enqueue("\r\nQue es int?");
            values_tx.Enqueue("\r\na. un numero flotante");
            values_tx.Enqueue("\r\nb. un numero entero");
            values_tx.Enqueue("\r\nc. ni idea bro");

            control = 2;
        }

        public void Mensaje4()
        {
            values_tx.Enqueue("\r\nLenguajes de un frontend");
            values_tx.Enqueue("\r\na. html, css y js");
            values_tx.Enqueue("\r\nb. c#, python y pseint");
            values_tx.Enqueue("\r\nc. css, c++ y c#");

            control = 3;
        }

        public void Respuesta()
        {
            if (control == 0)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("a"))
                    {
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje2();
                    }
                    else
                    {
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje2();
                    }
                }
            }

            else if (control == 1)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("c"))
                    {
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje3();
                    }
                    else
                    {
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje3();
                    }
                }
            }

            else if (control == 2)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("b"))
                    {
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje4();
                    }
                    else
                    {
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje4();
                    }
                }
            }

            else if (control == 3)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("a"))
                    {
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
            
                    }
                    else
                    {
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                    
                    }
                }
            }
        }

        public void servidor()
        {
            IPAddress ip = IPAddress.Any;  //ip servidor
            EndPoint local = new IPEndPoint(ip, 12345); //endpoint del servidor
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket configurado");

            socket.Bind(local);
            socket.Listen(1);

            Socket handler = socket.Accept();

            try
            {
                while (true)
                {
                    //recibiendo
                    if (handler.Available > 0)
                    {
                        byte[] data = new byte[handler.Available];
                        int len = handler.Receive(data);
                        if (len > 0)
                        {
                            string data_rx = Encoding.ASCII.GetString(data, 0, len);
                            values_rx.Enqueue(data_rx);
                        }
                    }
                    if (handler.Connected == false)
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
                            handler.Send(enviar);
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

            handler.Close();
            handler.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread server = new Thread(new ThreadStart(servidor));
            server.Start();

            button1.Enabled = false;
            Conexiones.Text = "--Socket configurado" + "\n";

        }

        private void p(object sender, EventArgs e)
        {
            Respuesta();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
