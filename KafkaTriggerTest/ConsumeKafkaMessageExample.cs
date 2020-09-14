using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.Kafka;

namespace KafkaTriggerTest
{
    public static class ConsumeKafkaMessageExample
    {
        [FunctionName("ConsumeKafkaMessage")]
        public static void ConsumeKafkaMessage(
            [KafkaTrigger("kafka-26b55b43-sifisoshabalala173-36cd.aivencloud.com:27704",
            "EVT_GITHUB_COMMITS",
            Protocol = BrokerProtocol.SaslSsl, 
            AuthenticationMode = BrokerAuthenticationMode.Plain,
            ConsumerGroup = "KAFKA_CONSUMER_EXAMPLE",
            Username = "",
            SslCaLocation = "ca.pem",
            SslCertificateLocation = "service.cert",
            SslKeyLocation = "service.key",
            Password = "")] KafkaEventData<string> message,
            ILogger log)
        {
            log.LogInformation(message.Value);
        }
    }
}
