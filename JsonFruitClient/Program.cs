using JsonFruit;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

namespace JsonFruitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fruit client");
            TcpClient socket = new TcpClient("localhost", 10002);
            Console.WriteLine("Hvilken type frugt?");
            string typeOfFruit = Console.ReadLine();

            Fruit myFruit = new Fruit(typeOfFruit);
            string serializedFruit = JsonSerializer.Serialize(myFruit);

            NetworkStream ns = socket.GetStream();
            StreamWriter writer = new StreamWriter(ns);
            StreamReader reader = new StreamReader(ns);
            writer.WriteLine(serializedFruit);
            writer.Flush();
            string response = reader.ReadLine();
            Console.WriteLine(response);

            socket.Close();
        }
    }
}
