using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LogDetailDto
    {
       
        public int LOG_ID { get; set; }  //IEntity.LOG_ID

        public string timeStamp { get; set; }


        public string metricType { get; set; }


        public string eventType { get; set; }


        public string kvp { get; set; }


        public string sendNotification { get; set; }

    }
}
