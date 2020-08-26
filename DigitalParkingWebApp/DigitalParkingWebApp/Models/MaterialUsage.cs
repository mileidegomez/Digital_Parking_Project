using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DigitalParkingWebApp.Models  
{  
    public class MaterialUsage  
    {  
        public List<MaterialUsageDetails> Value { get; set; }  
    }  
  
    public class MaterialUsageDetails  
    {         
        public string PartitionKey { get; set; }  
        public string RowKey { get; set; }  
        public DateTime Timestamp { get; set; }  
        public string A_1 { get; set; }
        public string A_2 { get; set; }

        public string A_3 { get; set; }
        public string A_4 { get; set; }
        public string FORA { get; set; }

    }  
}  