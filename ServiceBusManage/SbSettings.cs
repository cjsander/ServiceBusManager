using System;
using System.Configuration;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;


namespace ServiceBusManager
{
    public class SbSettings
    {
        public int? MaxDeliveryCount { get; set; }
        public bool RequireDuplicateDetection { get; set; }
        public TimeSpan? DuplicateDetectionHistoryTimeWindow { get; set; }

        public SbNamespaceManager SbNamespaceManager;
        public MessagingFactory SbMsgFactory;
        public string SbConnStr = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
        public string SbTopicPath = ConfigurationManager.AppSettings["TopicPath"];
        public TopicClient SbTopicClient;
        public TopicDescription SbTopicDescrition;
        public string SbSubscriptionName = ConfigurationManager.AppSettings["SubscriptionName"];
        public bool UseHttpCnnMode = Convert.ToBoolean(ConfigurationManager.AppSettings["UseHttpConnMode"]);
        public string SbQueueName = ConfigurationManager.AppSettings["QueueName"];
        public Filter SbFilter;




    }
}
