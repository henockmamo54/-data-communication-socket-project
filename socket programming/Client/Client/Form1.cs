﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        static Socket sock;

        //IPAddress serverIP = IPAddress.Parse("117.17.157.125");
        IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        int serverPort = 1234;

        string conversation = "";

        public Form1()
        {
            InitializeComponent();

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(serverIP, serverPort);

            try {
                sock.Connect(localEndPoint);
                byte[] data = Encoding.ASCII.GetBytes("Client one is connected");
                sock.Send(data);

                lbl_connected.Text = "Client is connected to " + "127.0.0.1" + " & Port: "+ serverPort;
            }
            catch (Exception) {
                Console.Write("unable to connect");
                
            }

            Thread t = new Thread(listenForMessage);
            t.Start();
            //txt_conversationHistory.Text = conversation;
        }


        private void listenForMessage()
        {
            while (true)
            {
                try
                {
                    byte[] Buffer = new byte[sock.ReceiveBufferSize];
                    int bytesRead = sock.Receive(Buffer);

                    byte[] formatted = new byte[bytesRead];

                    for (int i = 0; i < bytesRead; i++)
                    {
                        formatted[i] = Buffer[i];
                    }

                    string strData = Encoding.ASCII.GetString(formatted);
                    Console.Write(strData + "\r\n");
                    Console.Read();

                    conversation += @"<div style='color: cornflowerblue;font-size: 12px;font-family: cursive; margin: 0px; padding: 0px;'  align='left'><b> S: </b>" + strData + " </div>";
                    this.Invoke(new MethodInvoker(delegate
                    {
                        webBrowser1.DocumentText = conversation;
                    }));
                }
                catch (Exception e) { }
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {

            byte[] data = Encoding.ASCII.GetBytes(txt_message.Text);
            sock.Send(data);

            conversation += @"<div style='color: forestgreen;font-size: 12px;font-family: cursive;margin: 0px; padding: 0px;' align='right'><b> C: </b>" + txt_message.Text + " </div>";
            webBrowser1.DocumentText = conversation;
            txt_message.Text = "";
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            sock.Close();
        }

        private void txt_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_send_Click(this, new EventArgs());
            }
        }
    }
}
