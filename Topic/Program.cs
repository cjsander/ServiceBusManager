using System;
using System.Collections.Generic;
using System.Text;
using ServiceBusManager;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;


namespace Topic
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Settings s = new Settings();
                ServiceBusEnvironment.SystemConnectivity.Mode = s.UseHttpCnnMode ? ConnectivityMode.Http : ConnectivityMode.Tcp;
                s.NamespaceMgr = NamespaceManager.CreateFromConnectionString(s.ConnectionString);
                s.MsgFactory = MessagingFactory.CreateFromConnectionString(s.ConnectionString);
                s.LoggingTopicClient = s.MsgFactory.CreateTopicClient(s.TopicPath);
                if (!s.NamespaceMgr.TopicExists(s.TopicPath))
                {
                    s.NamespaceMgr.CreateTopic(s.TopicPath);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



            StringBuilder sb = new StringBuilder();
            ServiceBusManager.Management mgt = new Management();
            
            QueueDescription queue = new QueueDescription("cjsTestConnectivity");
            queue.Status = EntityStatus.Disabled;


            //TODO: Topic subscription item not looping through but instead repeating same item.
            List<TopicSubscrInfo> tsi = mgt.GetSbCurrentInfo();

            foreach(var item in tsi)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Topic Name: " + item.topicPath);
               // Console.WriteLine("Topic AuthType: " + item.topicAuth);
                Console.WriteLine("Topic SubscriptionCount: " + item.topicSubscriptionCount);
                TopicSubscriptionDetails tsd = new TopicSubscriptionDetails(); 
                for (int i = 0; i < item.topicSubscriptionCount; i++)
                {                   
                    tsd.subName = item.topicSubDetail.subName.ToString();
                    tsd.subStatus = item.topicSubDetail.subStatus.ToString();
                    tsd.activeMessageCount = item.topicSubDetail.activeMessageCount;
                    Console.WriteLine("--Subscription Name: " + tsd.subName);
                    Console.WriteLine("--Subscription Status: " + tsd.subStatus);
                    Console.WriteLine("--Active Msg Count: " + tsd.activeMessageCount.ToString());                    
                }
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            //m.CreateSubscription("ordertopic", "orders");

           // Messages m = new Messages();
          //  m.TestTopic(false);
         //   Console.WriteLine("Complete!");
           // Console.ReadLine();
        }

        
    }
}
