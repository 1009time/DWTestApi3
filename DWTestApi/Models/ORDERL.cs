using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWTestApi.Models
{
    public class ORDERL
    {

        public string ORDERLID { get; set; }

        public string BOXID { get; set; }
        public string AREA_ID { get; set; }
        public string ZIP_NO { get; set; }
        public string ADRESS { get; set; }
        public string ADRESS_ADD { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUSTOMER_NM { get; set; }

        public string DELIVER_ID { get; set; }
        public string TASK_DT { get; set; }
        public DateTime CREATE_DT { get; set; }
    }
}
