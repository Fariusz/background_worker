using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace AsynchServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string port = textBoxPort.Text;
           backgroundWorker1.RunWorkerAsync(port);

           button1.Enabled = false;
           textBoxPort.Enabled = false;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            // pobierz numer portu TCP/IP
            string str = (string)e.Argument;
            int port = 1410;
            try
            {
                port = int.Parse(str);
            } catch (Exception err)
            {

            }

            // Nasłuchiwanie 
            TcpListener listener = new TcpListener(port);
            listener.Start();
            backgroundWorker1.ReportProgress(1, "Listener start: "+Environment.NewLine);
            while (true)
            {
                Socket client = listener.AcceptSocket();
                backgroundWorker1.ReportProgress(1, "Get Message: " + Environment.NewLine);
                byte[] buf = new byte[100];
                int size = client.Receive(buf);
                string strMsg = "";
                for (int i = 0; i < size; i++)
                    strMsg = strMsg + Convert.ToChar(buf[i]);

                backgroundWorker1.ReportProgress(1, strMsg + Environment.NewLine);

                client.Close();
            }
        
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string str = (string)e.UserState;
            textBoxMessages.Text += str;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
