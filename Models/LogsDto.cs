using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    public class LogsDto : IDisposable
    {
   
        public int LOG_ID { get; set; } //IEntity.LOG_ID


        public string cdpName { get; set; }


        public string ip { get; set; }


        public string host { get; set; }

        public IEnumerable<LogDetailDto> details { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
