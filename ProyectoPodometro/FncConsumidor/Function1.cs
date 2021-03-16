using System;
using System.Net.Mail;
using System.Threading.Tasks;
using FncConsumidor.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FncConsumidor
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
              [ServiceBusTrigger(
                "cola2",
                Connection = "MyConn"
            )]string myQueueItem,
              [CosmosDB(
                databaseName: "DBUbicua",
                collectionName:"pasos",
                ConnectionStringSetting ="myConStringSetting"
            )]IAsyncCollector<object> datos,
              ILogger log)
        {
            try
            {


                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);
                // await datos.AddAsync(data);
                MailMessage message = new MailMessage();
                message.To.Add(data.Email); //Email from queue
                message.Subject = "ContadorDePasos";
                message.From = new MailAddress("sarahecr2510@outlook.com"); //My Email
                message.Body = $"Hola! {data.Name}, desde la última toma en {data.Datetime}, caminaste {data.Steps} pasos.";

                SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("sarahecr2510@outlook.com", "Password123456");
                smtp.EnableSsl = true;
                smtp.Send(message);



            }
            catch (Exception ex)
            {
                log.LogError($"No fue posible inserttar datos :C : {ex.Message}");
            }
        }

    }
}
