using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Models;
using ServiceBusManager;
using Microsoft.ServiceBus;
using System.Diagnostics;

namespace Topic
{
    public class Messages
    {
        Settings settings = new Settings();

        //public void TestTopic(bool receive)
        //{
        //    ServiceBusManager.Management mgt = new Management();
        //    settings = mgt.CreateNamespaceManagerAndFactory();
        //    //   mgt.DeleteTopic();
        //    //   mgt.CreateTopic();
        //    //   mgt.CreateSubscription();
        //    if (!receive)
        //    {
        //        SendOrdersBatch(settings);
        //    }
        //    else
        //    {
        //        ReceiveTopicStart(settings);
        //    }
        //}

        //public void SendOrdersBatch(Settings settings)
        //{
        //    int messageMax = 100;

        //    for (int i = 0; i < messageMax; i++)
        //    {
        //        SendTopic(new Order()
        //        {
        //            Name = new Guid().ToString(),
        //            Value = i + 6 / 3,
        //            Region = "CHRYSTAL",
        //            Items = i,
        //            HasLoyltyCard = true
        //        }, settings);
        //    }
        //}

        //public void SendOrders(Settings settings)
        //{
        //    // Send five orders with different properties.
        //    SendTopic(new Order()
        //    {
        //        Name = "Loyal Customer",
        //        Value = 19.99,
        //        Region = "USA",
        //        Items = 1,
        //        HasLoyltyCard = true
        //    }, settings);

        //    SendTopic(new Order()
        //    {
        //        Name = "Large Order",
        //        Value = 49.99,
        //        Region = "USA",
        //        Items = 50,
        //        HasLoyltyCard = false
        //    }, settings);

        //    SendTopic(new Order()
        //    {
        //        Name = "High Value Order",
        //        Value = 749.45,
        //        Region = "USA",
        //        Items = 45,
        //        HasLoyltyCard = false
        //    }, settings);

        //    SendTopic(new Order()
        //    {
        //        Name = "Loyal Europe Order",
        //        Value = 49.45,
        //        Region = "EU",
        //        Items = 3,
        //        HasLoyltyCard = true
        //    }, settings);

        //    SendTopic(new Order()
        //    {
        //        Name = "UK Order",
        //        Value = 49.45,
        //        Region = "UK",
        //        Items = 3,
        //        HasLoyltyCard = false
        //    }, settings);

        //    // Close the TopicClient.

        //    settings.LoggingTopicClient.Close();
        //}

        //public void SendTopic(Order order, Settings settings)
        //{

        //    BrokeredMessage brokeredMessage = new BrokeredMessage();
        //    brokeredMessage.Properties.Add("Loyalty", order.HasLoyltyCard);
        //    brokeredMessage.Properties.Add("Items", order.Items);
        //    brokeredMessage.Properties.Add("Value", order.Value);
        //    brokeredMessage.Properties.Add("Region", order.Region);
        //    brokeredMessage.CorrelationId = order.Region;


        //    settings.LoggingTopicClient.Send(brokeredMessage);

        //}

        //public void ReceiveTopicStart(Settings settings)
        //{
        //    string topicPath = settings.TopicPath;
        //    StringBuilder sb = new StringBuilder();

        //    foreach (SubscriptionDescription sDescription in settings.NamespaceMgr.GetSubscriptions(settings.TopicPath))
        //    {
        //        SubscriptionClient subClient = settings.MsgFactory.CreateSubscriptionClient(settings.TopicPath, settings.SubscriptionName);
             
        //        int i = 0;
        //        while (i < 50)
        //        {
        //            if (i == 25)
        //            {
        //                Pause();
        //            }
        //            // Recieve any message with timeout.                    
        //            BrokeredMessage msg = subClient.Receive(TimeSpan.FromSeconds(5));
        //            if (msg != null)
        //            {
        //                Order order = msg.GetBody<Order>();
        //                Console.WriteLine("MESSAGE: " + msg.MessageId.ToString());
        //                // sb.AppendLine(" Order Details: " + order.Name + " " + order.Region + " " + order.Items + " " + order.Value);
        //                msg.Complete();
        //            }
        //            else
        //            {
        //                break;
        //            }
        //            i++;
        //        }
        //        subClient.Close();
        //    }
        //}

        private void Pause()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 999999; i++)
            {
                if (i % 10 == 0)
                { 
                Console.WriteLine("...paused...");
                }
            }
            sw.Stop();

        }

    }

}

