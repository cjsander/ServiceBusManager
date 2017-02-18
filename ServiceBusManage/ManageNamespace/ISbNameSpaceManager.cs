using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusManager
{
    public interface ISbNamespaceManager 
    {
        bool QueueExists(string path);
        bool TopicExists(string path);
        bool SubscriptionExists(string path, string subscriptionName);
        QueueDescription CreateQueue(string path, SbSettings settings);
        TopicDescription CreateTopic(string path);
        SubscriptionDescription CreateSubscription(string path, string subscriptionName);
        QueueDescription GetQueue(string path);
        TopicDescription GetTopic(string path);
        void DeleteQueue(string path);
        void DeleteTopic(string path);
        void DeleteSubscription(string path, string subscriptionName);
        string ConnectionString { get; }
    }
}
