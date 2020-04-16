using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace PaymentCreditCard
{
    class PayPurchase
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pay service start! Wainting for payments, to exit press CTLR+C!");

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
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        Purchase purchase = JsonConvert.DeserializeObject<Purchase>(message);
                        Console.WriteLine($"Purchase with Id: {purchase.PurchaseId} - Amount: {purchase.Amount} was payd, AuthCode: {purchase.AuthorizatonCode}.");
                    };

                    channel.BasicConsume(queue: "CaptureCreditCard",
                        autoAck: true,
                        consumer: consumer);
                    Console.ReadLine();
                }
            }


        }
    }
}
