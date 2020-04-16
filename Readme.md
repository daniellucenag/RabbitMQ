# RabbitMQ

Test RabbitMQ Implementation

# HowTo

* Install docker (windows/linux/mac)
* Run this command, to start RabbitMQ in your machine, and map the ports to make possible call in your brownser http://localhost:15672/
```
    docker run -d -p 15672:15672 -p 5672:5672 --name rabbit-test rabbitmq:3-management
```
* Open the projects folder and run
``` 
    cd CapturePurchase
    dotnet run
    cd PaymentPurchase
    dotnet run
```
* See the magic happens

Thanks to:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [RabbitMQ with Docker on Windows in 30 minutes](https://levelup.gitconnected.com/rabbitmq-with-docker-on-windows-in-30-minutes-172e88bb0808)
- [RabbitMQ in .NET: data serialisation I](https://dotnetcodr.com/2014/06/05/rabbitmq-in-net-data-serialisation/)
- [ME! xD](https://www.linkedin.com/in/daniel-lucena-44957b62/)