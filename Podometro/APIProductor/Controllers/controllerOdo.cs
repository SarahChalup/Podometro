

namespace APIProductor.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using APIProductor.Models;
    using Newtonsoft.Json;


    [Route("api/[controller]")]
    [ApiController]
    public class controllerOdo : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            string connectionString = "Endpoint=sb://queuesarah.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=UHdwmXKEHIxAnbfyl4avU6oNS+ypNHaTNrsMYQYsUsg=;EntityPath=cola2";
            string queueName = "cola2";
            String mensaje = JsonConvert.SerializeObject(data);



            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }
            return true;
        }

    }
}
