using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CaptureCreditCard
{
    class CapturePurchase
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Purchase service start!");

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "CaptureCreditCard",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    bool exit = false;
                    string amount;
                    while (!exit)
                    {
                        Console.Write("Enter the amount or [0] to exit: ");
                        amount = Console.ReadLine();

                        if (decimal.Parse(amount) == 0)
                        {
                            exit = true;
                        }
                        else
                        {
                            Purchase purchase = new Purchase(decimal.Parse(amount));
                            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(purchase));

                            channel.BasicPublish(
                                exchange: "",
                                routingKey: "CaptureCreditCard",
                                basicProperties: null,
                                body: body);
                            Console.WriteLine($"Purchase with Id: {purchase.PurchaseId} - Amount: {purchase.Amount} send to Payment.");
                        }
                    }
                }
            }
        }
    }
}