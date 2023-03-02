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
        static bool activo;
        int control;
        int buenas;
        int malas;

        public Form1()
        {
            control = 0;
            buenas = 0;
            malas = 0;
            activo = true;
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

        public void Mensaje5()
        {
            values_tx.Enqueue("\r\nQue lenguaje se trabaja con unity?");
            values_tx.Enqueue("\r\na. Python");
            values_tx.Enqueue("\r\nb. Scratch");
            values_tx.Enqueue("\r\nc. C#");

            control = 4;
        }

        public void Mensaje6()
        {
            values_tx.Enqueue("\r\nQue tipo de traccion es necesaria para hacer drift?");
            values_tx.Enqueue("\r\na. Traccion integral");
            values_tx.Enqueue("\r\nb. Traccion trasera");
            values_tx.Enqueue("\r\nc. Traccion delantera");

            control = 5;
        }

        public void Mensaje7()
        {
            values_tx.Enqueue("\r\nEl supra mk4 de que annio es?");
            values_tx.Enqueue("\r\na. 1994");
            values_tx.Enqueue("\r\nb. 1998");
            values_tx.Enqueue("\r\nc. 2020");

            control = 6;
        }

        public void Mensaje8()
        {
            values_tx.Enqueue("\r\nCuales son los roles en League Of Legends?");
            values_tx.Enqueue("\r\na. bosque, mid y ayudante");
            values_tx.Enqueue("\r\nb. No lo se Rick");
            values_tx.Enqueue("\r\nc. Top, Jungla, Mid, Adc y Supp");

            control = 7;
        }

        public void MensajeF()
        {
            values_tx.Enqueue("\r\nTerminaste este es tu resultado:");
            values_tx.Enqueue("\r\nRespuestas Buenas: " + buenas);
            values_tx.Enqueue("\r\nRespuestas malas: " + malas);
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
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje2();
                    }
                    else
                    {
                        malas += 1;
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
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje3();
                    }
                    else
                    {
                        malas += 1;
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
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje4();
                    }
                    else
                    {
                        malas += 1;
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
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje5();
                    }
                    else
                    {
                        malas += 1;
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje5();
                    }
                }
            }

            else if (control == 4)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("c"))
                    {
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje6();
                    }
                    else
                    {
                        malas += 1;
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje6();
                    }
                }
            }

            else if (control == 5)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("b"))
                    {
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje7();
                    }
                    else
                    {
                        malas += 1;
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje7();
                    }
                }
            }

            else if (control == 6)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("b"))
                    {
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        Mensaje8();
                    }
                    else
                    {
                        malas += 1;
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        Mensaje8();
                    }
                }
            }

            else if (control == 7)
            {
                if (values_rx.Count > 0)
                {
                    string? dato;
                    values_rx.TryDequeue(out dato);

                    if (dato.ToLower().Equals("c"))
                    {
                        buenas += 1;
                        values_tx.Enqueue("\r\n---Respuesta Correcta---");
                        MensajeF();
                    }
                    else
                    {
                        malas += 1;
                        values_tx.Enqueue("\r\n---Respuesta incorrecta---");
                        MensajeF();
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
                while (activo == true)
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
            Conexiones.Text += "--Socket configurado.";
            btn_Apagar.Enabled = true;
        }

        private void p(object sender, EventArgs e)
        {
            Respuesta();
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            activo = false;
            btn_Apagar.Enabled = false;
            button1.Enabled = true;
            Conexiones.Text += "\r\n--Socket desconectado.";
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            activo = false;
        }
    }
}
