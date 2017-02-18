using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusManager
{
    public class SbInfo
    {
        private NamespaceManager _namespaceManager;
        public string SbGeneralInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("TIMESTAMP: " + DateTime.Now.ToShortTimeString());
            List<TopicSubscriberInfo> tsi = GetSbGeneralInfo();
            foreach (var item in tsi)
            {
                sb.AppendLine("--------------------------------------------------------");
                sb.AppendLine("Topic Name: " + item.TopicPath);
                sb.AppendLine("Topic SubscriptionCount: " + item.TopicSubscriptionCount);
                sb.AppendLine("     ----------------------------------------------");
                TopicSubscriberInfo.TopicSubscriptionDetails tsd = new TopicSubscriberInfo.TopicSubscriptionDetails();
                for (int i = 0; i < item.TopicSubscriptionCount; i++)
                {
                    tsd.SubName = item.TopicSubDetail.SubName.ToString();
                    tsd.SubStatus = item.TopicSubDetail.SubStatus.ToString();
                    tsd.ActiveMessageCount = item.TopicSubDetail.ActiveMessageCount;
                    sb.AppendLine("   --Subscription Name: " + tsd.SubName);
                    sb.AppendLine("   ----Subscription Status: " + tsd.SubStatus);
                    sb.AppendLine("   ----Active Msg Count: " + tsd.ActiveMessageCount.ToString());

                }
            }
            sb.AppendLine("--------------------------------------------------------");
            return sb.ToString();

        }

        public string GetQueueInfo(string queuePath)
        {
            StringBuilder sb = new StringBuilder();

            QueueDescription queueDescription = _namespaceManager.GetQueue(queuePath);

            sb.AppendLine($"Queue Path:                                  {queueDescription.Path}");
            sb.AppendLine("Queue MessageCount:                           {queueDescription.MessageCount}");
            sb.AppendLine("Queue SizeInBytes:                            {queueDescription.SizeInBytes}");
            sb.AppendLine("Queue RequiresSession:                        {queueDescription.RequiresSession}");
            sb.AppendLine("Queue RequiresDuplicateDetection:             {queueDescription.RequiresDuplicateDetection}");
            sb.AppendLine("Queue DuplicateDetectionHistoryTimeWindow:    {queueDescription.DuplicateDetectionHistoryTimeWindow}");
            sb.AppendLine("Queue LockDuration:                           {queueDescription.LockDuration}");
            sb.AppendLine("Queue DefaultMessageTimeToLive:               {queueDescription.DefaultMessageTimeToLive}");
            sb.AppendLine("Queue EnableDeadLetteringOnMessageExpiration: {queueDescription.EnableDeadLetteringOnMessageExpiration}",
                );
            sb.AppendLine("Queue EnableBatchedOperations:                {queueDescription.EnableBatchedOperations}",
                );
            sb.AppendLine("Queue MaxSizeInMegabytes:                     {queueDescription.MaxSizeInMegabytes}",
                );
            sb.AppendLine("Queue MaxDeliveryCount:                       {0}",
                queueDescription.MaxDeliveryCount);
            sb.AppendLine("Queue IsReadOnly:                             {0}",
                queueDescription.IsReadOnly); ("Queue Path:                                   {0}",
                   queueDescription.Path);
            sb.AppendLine("Queue MessageCount:                           {0}",
                queueDescription.MessageCount);
            sb.AppendLine("Queue SizeInBytes:                            {0}",
                queueDescription.SizeInBytes);
            sb.AppendLine("Queue RequiresSession:                        {0}",
                queueDescription.RequiresSession);
            sb.AppendLine("Queue RequiresDuplicateDetection:             {0}",
                queueDescription.RequiresDuplicateDetection);
            sb.AppendLine("Queue DuplicateDetectionHistoryTimeWindow:    {0}",
                queueDescription.DuplicateDetectionHistoryTimeWindow);
            sb.AppendLine("Queue LockDuration:                           {0}",
                queueDescription.LockDuration);
            sb.AppendLine("Queue DefaultMessageTimeToLive:               {0}",
                queueDescription.DefaultMessageTimeToLive);
            sb.AppendLine("Queue EnableDeadLetteringOnMessageExpiration: {0}",
                queueDescription.EnableDeadLetteringOnMessageExpiration);
            sb.AppendLine("Queue EnableBatchedOperations:                {0}",
                queueDescription.EnableBatchedOperations);
            sb.AppendLine("Queue MaxSizeInMegabytes:                     {0}",
                queueDescription.MaxSizeInMegabytes);
            sb.AppendLine("Queue MaxDeliveryCount:                       {0}",
                queueDescription.MaxDeliveryCount);
            sb.AppendLine("Queue IsReadOnly:                             {0}",
                queueDescription.IsReadOnly);


            return sb.ToString();

        private List<TopicSubscriberInfo> GetSbGeneralInfo()
        {
            TopicSubscriberInfo tsi = new TopicSubscriberInfo();
            List<TopicSubscriberInfo> listTsi = new List<TopicSubscriberInfo>();
            _namespaceManager = new NamespaceManager(new SbSettings().SbConnStr);
            List<string> properties = new List<string>();
            List<NamespaceManager> listNsm = new List<NamespaceManager>();
            listNsm.Add(_namespaceManager);
            StringBuilder sb = new StringBuilder();
            foreach (NamespaceManager nm in listNsm)
            {
                sb.AppendLine("AbsoluteUri: " + nm.Address.AbsoluteUri);
                sb.AppendLine("Settings.Token: " + nm.Settings.TokenProvider.ToString());
            }
            IEnumerable<TopicDescription> topics = _namespaceManager.GetTopics();
            List<TopicDescription> listTopics = new List<TopicDescription>(topics);

            foreach (var x in listTopics)
            {
                tsi = new TopicSubscriberInfo();
                tsi.TopicPath = x.Path;
                tsi.TopicAuth = x.Authorization.ToString();
                tsi.TopicActiveMsgCount = x.MessageCountDetails.ActiveMessageCount;
                tsi.TopicDlMsgCount = x.MessageCountDetails.DeadLetterMessageCount;
                tsi.TopicSubscriptionCount = x.SubscriptionCount;

                TopicSubscriberInfo.TopicSubscriptionDetails tsd = new TopicSubscriberInfo.TopicSubscriptionDetails();

                IEnumerable<SubscriptionDescription> subscrps = _namespaceManager.GetSubscriptions(x.Path);
                foreach (var item in subscrps)
                {
                    for (int i = 0; i < tsi.TopicSubscriptionCount; i++)
                    {
                        tsd.SubName = item.Name.ToString();
                        tsd.SubStatus = item.Status.ToString();
                        tsd.DefaultTimeToLive = item.DefaultMessageTimeToLive;
                        tsd.TotalMessageCount = item.MessageCount;
                        tsd.ActiveMessageCount = item.MessageCountDetails.ActiveMessageCount;
                        tsd.SubDlMsgCount = item.MessageCountDetails.DeadLetterMessageCount;
                        tsd.ScheduledMsgCount = item.MessageCountDetails.ScheduledMessageCount;
                    }
                }
                tsi.TopicSubDetail = tsd;
                listTsi.Add(tsi);
            }
            return listTsi;
        }
    }
}
