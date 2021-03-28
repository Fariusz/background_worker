using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ConsoleApplicationClient
{
    class Program
    {
        static void Main(string[] args)
        {

            string respuser = "";
            do
            {
                string adres;
                int port;
                string komunikat = "";
                Console.WriteLine("Podaj adres IP serwera");
                adres = Console.ReadLine();

                Console.WriteLine("Podaj port");
                port = int.Parse(Console.ReadLine());

                Console.ReadLine();
                Console.WriteLine("Wpisz komunikat: ");
                komunikat = Console.ReadLine();

                TcpClient client = new TcpClient(adres, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(komunikat);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                client.Close();

                Console.WriteLine("Czy chcesz wysłać następną wiadomość? (T/N)");
                respuser = Console.ReadLine();

            } while (!respuser.Equals("N"));
        }
    }
}
