using System;
using System.Text;

namespace ServiceBusManager
{
    public class SbManage
    {
        private SbSettings _sets;
        private ISbNamespaceManager _nm;

        public bool CreateTopic()
        {
            _sets = new SbSettings();
            _nm = new SbNamespaceManager(_sets.SbConnStr);
            if (!_nm.TopicExists(_sets.SbTopicPath))
            {
                _nm.CreateTopic(_sets.SbTopicPath);
                return true;
            }
            else
            {
                return false;
            }
    }
        public bool CreateSubscription()
        {
            _sets = new SbSettings();
            _nm = new SbNamespaceManager("Endpoint=sb://stl4dwscdp03.corp.mastercard.test/CDPSBNamespace;StsEndpoint=https://stl4dwscdp03.corp.mastercard.test:9355/CDPSBNamespace;RuntimePort=9354;ManagementPort=9355;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=FPEeTnOpWRZ6VXRpisfE6BeBmW9wbBteKiJna/eVjsA=");
            if (!_nm.SubscriptionExists("cdplogging", "allcdpmessages"))
            {
                _nm.CreateSubscription("cdplogging", "allcdpmessages");
                return true;
            }
            else
            {
                return false;
            }
            //_sets = new SbSettings();
            //_nm = new SbNamespaceManager(_sets.SbConnStr);
            //if (!_nm.SubscriptionExists(_sets.SbTopicPath, _sets.SbSubscriptionName))
            //{
            //    _nm.CreateSubscription(_sets.SbTopicPath, _sets.SbSubscriptionName);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public void DeleteTopic()
        {
            _sets = new SbSettings();
            _nm = new SbNamespaceManager(_sets.SbConnStr);
            _nm.DeleteTopic(_sets.SbTopicPath);
        }
        public void DeleteSubscription()
        {
            _sets = new SbSettings();
            _nm = new SbNamespaceManager(_sets.SbConnStr);
            _nm.DeleteSubscription(_sets.SbTopicPath, _sets.SbSubscriptionName);
        }

    }
}
