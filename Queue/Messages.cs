using System;
using System.Collections.Generic;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;
using ServiceBusManager;

namespace Queue
{
    public class Messages
    {
        readonly Settings settings = new Settings();

        public List<string> ListQueues()
        {
            List<string> retList = null;
            IEnumerable<QueueDescription> queueDescriptions = settings.NamespaceMgr.GetQueues();
            foreach (QueueDescription queueDescription in queueDescriptions)
            {
                retList.Add(queueDescription.Path);
            }
            return retList;
        }

        public void SendMessageToQueue(BrokeredMessage brokeredMessage, string queuePath)
        {
            QueueClient queueClient = settings.MsgFactory.CreateQueueClient(queuePath);
            string msgText = "Test message text";
            BrokeredMessage msg = brokeredMessage;
            queueClient.Send(msg);
            msg.Complete();
        }

        public BrokeredMessage ReceiveMessageFromQueue(string queuePath)
        {
           QueueClient queueClient = settings.MsgFactory.CreateQueueClient(queuePath, ReceiveMode.PeekLock);
            BrokeredMessage msg = queueClient.Receive(TimeSpan.FromSeconds(5));
            if (msg != null)
            {
                return msg;
            }
            else return null;
        }

        public List<string> ReceiveBatchMessagesFromQueue(string queuePath)
        {
            List<string> batchMessages = null;

                QueueClient queueClient = settings.MsgFactory.CreateQueueClient(queuePath);
                IEnumerable<BrokeredMessage> receivedBatchMessage = queueClient.ReceiveBatch(5, TimeSpan.FromSeconds(5));
                foreach (BrokeredMessage bm in receivedBatchMessage)
                {
                    batchMessages.Add(bm.GetBody<string>());
                }
            return batchMessages;
        }






    }
}
