using GatewayDeviceMvc.Models;
using GatewayDeviceMvc.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace GatewayDeviceMvc.Controllers
{
    public class GatewayController : Controller
    {
        private readonly IGatewayRepository _gatewayRepository;
        private readonly IDeviceRepository _deviceRepository;

        public GatewayController(IGatewayRepository gatewayRepository, IDeviceRepository deviceRepository)
        {
            _gatewayRepository = gatewayRepository;
            _deviceRepository = deviceRepository;
        }
        public ViewResult List(string name)
        {
            IEnumerable<Gateway> gateways;
            if (string.IsNullOrEmpty(name))
            {
                gateways = _gatewayRepository.AllGateways.OrderBy(g => g.SerialNumber);
            }
            else
            {
                gateways = _gatewayRepository.AllGateways.Where(g => g.Name == name).OrderBy(g => g.SerialNumber);
            }

            return View(gateways);
        }
    }
}
