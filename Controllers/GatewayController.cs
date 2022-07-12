using GatewayDeviceMvc.Models;
using GatewayDeviceMvc.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;

namespace GatewayDeviceMvc.Controllers
{
    [Authorize]
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

        //GET:Gateway/Details/5
        public IActionResult Details(int id)
        {  
            var gateway = _gatewayRepository.GetGatewayById(id);
            if (gateway==null)
            {
                return NotFound();
            }
            return View(gateway);
        }

        //Get:Gateway/Edit/5
        public  IActionResult Edit(int id)
        {
          
            var gateway = _gatewayRepository.GetGatewayById(id);
            if (gateway==null)
            {
                return NotFound();
            }
            return View(gateway);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind("SerialNumber,Name,IPV4")] Gateway gateway)
        {
            if (id != gateway.SerialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _gatewayRepository.UpdateGateway(gateway);
                return RedirectToAction(nameof(List));
            }
            return View(gateway);
        }

        //GET:Gateway/Delete/5
        public IActionResult Delete(int id)
        {
            var gateway = _gatewayRepository.GetGatewayById(id);
            if (gateway==null)
            {
                return NotFound();
            }
            return View(gateway);
        }

        //POST:Gateway/Delete/5
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var gateway = _gatewayRepository.GetGatewayById(id);
            if (gateway == null)
            {
                return NotFound();
            }
            _gatewayRepository.DeleteGateway(gateway);
            return RedirectToAction(nameof(List));
        }


    }
}
