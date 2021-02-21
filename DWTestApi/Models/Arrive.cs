using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWTestApi.Models
{
    public class Arrive
    {
        public string ArriveId { get; set; }
        public string ORDERLID { get; set; }
        public string DELIVER_ID { get; set; }
        public string DELIVERY_FIN { get; set; }
        public DateTime CREATE_DT { get; set; }
    }
}
