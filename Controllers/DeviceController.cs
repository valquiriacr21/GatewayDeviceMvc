using GatewayDeviceMvc.Models;
using GatewayDeviceMvc.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceMvc.Controllers
{
    
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public ViewResult List(string vendor)
        {
            IEnumerable<Device> devices;
            if (string.IsNullOrEmpty(vendor))
            {
                devices = _deviceRepository.AllDevices.OrderBy(d => d.UID);
            }
            else
            {
                devices = _deviceRepository.AllDevices.Where(d => d.Vendor == vendor).OrderBy(d => d.UID);
            }
            return View(devices);
        }
     
        //GET:Device/Details/5
        public IActionResult Details(int id)
        {
            var device = _deviceRepository.GetDeviceById(id);
            if (device==null)
            {
                return NotFound();
            }
            return View(device);
        }

        //GET:Device/Edit/5
        public IActionResult Edit(int id)
        {
            var device = _deviceRepository.GetDeviceById(id);
            if (device==null)
            {
                return NotFound();
            }
            return View(device);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("UID","Vendor","DateCreated","Status","GatewaySerialNumber")]Device device)
        {
            if (id!=device.UID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _deviceRepository.UpdateDevice(device);
                return RedirectToAction(nameof(List));
            }
            return View(device);
        }

        //GET:Device/Delete/5
        public IActionResult Delete(int id)
        {
            var device = _deviceRepository.GetDeviceById(id);
            if (device==null)
            {
                return NotFound();
            }
            return View(device);
        }
        //POST:Device/Delete/5
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var device = _deviceRepository.GetDeviceById(id);
            if (device==null)
            {
                return NotFound();
            }
            _deviceRepository.DeleteDevice(device);
            return RedirectToAction(nameof(List));
        }



    }
}
