using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWTestApi.Models
{
    public class DeliveryHis
    {
        public string DeliveryHisId { get; set; }
        public string ORDERLID { get; set; }
        public string DELIVER_ID { get; set; }
        public string LOCATION { get; set; }
        public string DELIVERY_STATUS { get; set; }
        public DateTime CREATE_DT { get; set; }
    }
}
