using GatewayDeviceMvc.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceMvc.Components
{
    public class GatewayMenu:ViewComponent
    {
        private readonly IGatewayRepository _gatewayRepository;

        public GatewayMenu(IGatewayRepository gatewayRepository)
        {
            _gatewayRepository = gatewayRepository;
        }

        public IViewComponentResult Invoke()
        {
            var gateways = _gatewayRepository.AllGateways.OrderBy(g => g.Name);
            return View(gateways);
        }
    }
}
