using Microsoft.AspNetCore.Mvc.ModelBinding;
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
       // [BindNever]
        public int UID { get; set; }
        [Required(ErrorMessage = "Please enter the gateway's name")]
        [Display(Name = "Vendor")]
        [StringLength(15)]
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Please enter the Status")]
        [Display(Name = "Status")]
        [StringLength(10)]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please enter the gateway's Serial Number")]
        [Display(Name = "GatewaySerialNumber")]
        public int GatewaySerialNumber { get; set; }
        Gateway Gateway { get; set; }
    }
}
