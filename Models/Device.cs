using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceMvc.Models
{
    public class Device
    {
        [Key]
        public int UID { get; set; }
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public int GatewaySerialNumber { get; set; }
        Gateway Gateway { get; set; }
    }
}
