using GatewayDeviceMvc.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceMvc.Controllers
{
    public class GatewayController : Controller
    {
        private readonly IGatewayRepository _gateway;
        private readonly IDeviceRepository _device;

        public GatewayController(IGatewayRepository gateway, IDeviceRepository device)
        {
            _gateway = gateway;
            _device = device;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
