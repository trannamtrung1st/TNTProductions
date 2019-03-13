using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace TNT.Core.SignalR.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Waiting");
            Console.ReadLine();
            HubConnection conn = new HubConnectionBuilder()
                .WithUrl($"https://localhost:44396/chatHub", opt =>
                {
                    opt.AccessTokenProvider = () => Task.FromResult("abcd");
                    opt.Credentials = new NetworkCredential("TNT", "123");
                })
                .Build();

            conn.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await conn.StartAsync();
            };

            conn.On<string, string>("ReceiveMessage", (user, message) =>
            {
                try
                {
                    var newMessage = $"{user}: {message}";
                    Console.WriteLine(newMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            try
            {
                conn.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            int i = 0;
            while (i < 50)
            {
                i++;
                try
                {
                    conn.InvokeAsync("SendMessage",
                       "TNT", "Mess no " + i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(5000);
            }
        }
    }

}
