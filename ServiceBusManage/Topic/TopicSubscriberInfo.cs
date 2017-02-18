using System;

namespace ServiceBusManager
{
    public class TopicSubscriberInfo
    {
        public string TopicPath { get; set; }
        public string TopicAuth { get; set; }
        public long TopicActiveMsgCount { get; set; }
        public long TopicDlMsgCount { get; set; }
        public int TopicSubscriptionCount { get; set; }
        public TopicSubscriptionDetails TopicSubDetail { get; set; }
        public string Subscription { get; set; }
        public int MessageCount { get; set; }

        public class TopicSubscriptionDetails
        {
            public string SubName { get; set; }
            public string SubStatus { get; set; }
            public string TopicPath { get; set; }
            public TimeSpan DefaultTimeToLive { get; set; }
            public long TotalMessageCount { get; set; }
            public long ActiveMessageCount { get; set; }
            public long SubDlMsgCount { get; set; }
            public long ScheduledMsgCount { get; set; }

        }
    }
}
