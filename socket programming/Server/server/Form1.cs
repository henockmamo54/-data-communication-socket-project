using System;
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

namespace server
{
    public partial class Form1 : Form
    {
        static byte[] Buffer { get; set; }
        static Socket sock;
        string conversation="";

        //IPAddress myIP = IPAddress.Parse("117.17.157.125");
        IPAddress myIP = IPAddress.Parse("127.0.0.1");
        int myPort = 1234;
        IPEndPoint myEndPoint;

        public Form1()
        {
            InitializeComponent();
            myEndPoint = new IPEndPoint(myIP, myPort);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(myEndPoint);

            txtbox_serverMessage.Text += "Ther server is started at IP Adress: " + myIP + " Port : " + myPort + "\n";

            this.Refresh();
            this.Invalidate();
                        

            Thread t = new Thread(listenForMessage);
            t.Start();

        }

        private void listenForMessage()
        {
            while (true)
            {
                try
                {
                    Buffer = new byte[sock.SendBufferSize];
                    int bytesRead = sock.Receive(Buffer);

                    byte[] formatted = new byte[bytesRead];

                    for (int i = 0; i < bytesRead; i++)
                    {
                        formatted[i] = Buffer[i];
                    }

                    string strData = Encoding.ASCII.GetString(formatted);
                    Console.Write(strData + "\r\n");
                    Console.Read();
                    

                    conversation += @"<div style='color: cornflowerblue;font-size: 12px;font-family: cursive; margin: 0px; padding: 0px;'  align='left'><b> C: </b>" + strData + " </div>";
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
            byte[] data = Encoding.ASCII.GetBytes(txt_msg.Text);
            sock.SendTo(data, myEndPoint);
            
            conversation += @"<div style='color: forestgreen;font-size: 12px;font-family: cursive;margin: 0px; padding: 0px;' align='right'><b> S: </b>" + txt_msg.Text + " </div>";
            webBrowser1.DocumentText = conversation;
            txt_msg.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sock.Close();
        }

        private void txt_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_send_Click(this, new EventArgs());
            }
        }
    }
}
