using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Queue
{
        public class ManagementHelper
        {
            private NamespaceManager m_NamespaceManager;

            public ManagementHelper(string connectionString)
            {
                // using the specified credentials.
                m_NamespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

                // Output the client address.
                Console.WriteLine("Service bus address {0}", m_NamespaceManager.Address);
            }

            public void CreateQueue(string queuePath)
            {
                Console.Write("Creating queue {0}...", queuePath);
                var description = GetQueueDescription(queuePath);
                var createdDescription = m_NamespaceManager.CreateQueue(description);
                Console.WriteLine("Done!");
            }

            public void DeleteQueue(string queuePath)
            {
                Console.Write("Deleting queue {0}...", queuePath);
                m_NamespaceManager.DeleteQueue(queuePath);
                Console.WriteLine("Done!");
            }

            public void ListQueues()
            {
                IEnumerable<QueueDescription> queueDescriptions = m_NamespaceManager.GetQueues();
                Console.WriteLine("Lisitng queues...");
                foreach (QueueDescription queueDescription in queueDescriptions)
                {
                    Console.WriteLine("\t{0}", queueDescription.Path);
                }
                Console.WriteLine("Done!");
            }

            public void GetQueue(string queuePath)
            {
                QueueDescription queueDescription = m_NamespaceManager.GetQueue(queuePath);

                Console.WriteLine("Queue Path:                                   {0}",
                    queueDescription.Path);
                Console.WriteLine("Queue MessageCount:                           {0}",
                    queueDescription.MessageCount);
                Console.WriteLine("Queue SizeInBytes:                            {0}",
                    queueDescription.SizeInBytes);
                Console.WriteLine("Queue RequiresSession:                        {0}",
                    queueDescription.RequiresSession);
                Console.WriteLine("Queue RequiresDuplicateDetection:             {0}",
                    queueDescription.RequiresDuplicateDetection);
                Console.WriteLine("Queue DuplicateDetectionHistoryTimeWindow:    {0}",
                    queueDescription.DuplicateDetectionHistoryTimeWindow);
                Console.WriteLine("Queue LockDuration:                           {0}",
                    queueDescription.LockDuration);
                Console.WriteLine("Queue DefaultMessageTimeToLive:               {0}",
                    queueDescription.DefaultMessageTimeToLive);
                Console.WriteLine("Queue EnableDeadLetteringOnMessageExpiration: {0}",
                    queueDescription.EnableDeadLetteringOnMessageExpiration);
                Console.WriteLine("Queue EnableBatchedOperations:                {0}",
                    queueDescription.EnableBatchedOperations);
                Console.WriteLine("Queue MaxSizeInMegabytes:                     {0}",
                    queueDescription.MaxSizeInMegabytes);
                Console.WriteLine("Queue MaxDeliveryCount:                       {0}",
                    queueDescription.MaxDeliveryCount);
                Console.WriteLine("Queue IsReadOnly:                             {0}",
                    queueDescription.IsReadOnly);
            }


            public void CreateTopic(string topicPath)
            {
                Console.Write("Creating topic {0}...", topicPath);
                var description = m_NamespaceManager.CreateTopic(topicPath);
                Console.WriteLine("Done!");
            }


            public void CreateSubscription(string topicPath, string subscriptionName)
            {
                Console.Write("Creating subscription {0}/subscriptions/{1}...", topicPath, subscriptionName);
                var description = m_NamespaceManager.CreateSubscription(topicPath, subscriptionName);
                Console.WriteLine("Done!");
            }


            public void ListTopicsAndSubscriptions()
            {
                IEnumerable<TopicDescription> topicDescriptions = m_NamespaceManager.GetTopics();
                Console.WriteLine("Lisitng topics and subscriptions...");
                foreach (TopicDescription topicDescription in topicDescriptions)
                {
                    Console.WriteLine("\t{0}", topicDescription.Path);
                    IEnumerable<SubscriptionDescription> subscriptionDescriptions = m_NamespaceManager.GetSubscriptions(topicDescription.Path);
                    foreach (SubscriptionDescription subscriptionDescription in subscriptionDescriptions)
                    {
                        Console.WriteLine("\t\t{0}", subscriptionDescription.Name);
                    }
                }
                Console.WriteLine("Done!");
            }


        public string GetTopicsAndSubscriptions()
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<TopicDescription> topicDescriptions = m_NamespaceManager.GetTopics();
            sb.AppendLine("Lisitng topics and subscriptions...");
            foreach (TopicDescription topicDescription in topicDescriptions)
            {
                sb.AppendLine("Topic Path: " + topicDescription.Path);
                IEnumerable<SubscriptionDescription> subscriptionDescriptions = m_NamespaceManager.GetSubscriptions(topicDescription.Path);
                foreach (SubscriptionDescription subscriptionDescription in subscriptionDescriptions)
                {
                    sb.AppendLine("Subscription Description:" + subscriptionDescription.Name);
                }
            }
            sb.AppendLine("Done!");
            return sb.ToString();
        }

        public QueueDescription GetQueueDescription(string path)
            {
                return new QueueDescription(path)
                {
                    //RequiresDuplicateDetection = true,
                    //DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(10),
                    //RequiresSession = true,
                    //MaxDeliveryCount = 20,
                    //DefaultMessageTimeToLive = TimeSpan.FromHours(1),
                    //EnableDeadLetteringOnMessageExpiration = true
                };
            }


        }
    }

