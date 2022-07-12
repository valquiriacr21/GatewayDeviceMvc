using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceMvc.Models
{
    public class Gateway
    {
        [Key]
        //[BindNever]
        public int SerialNumber { get; set; }
        [Required(ErrorMessage = "Please enter the gateway's name")]
        [Display(Name = "Name")]
        [StringLength(10)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the IPV4")]
        [Display(Name = "IPV4")]
        [StringLength(12)]
        public string IPV4 { get; set; }
        public List<Device> Devices { get; set; }

        public  Gateway()
        {
            Devices = new List<Device>();
        }
    }
}
