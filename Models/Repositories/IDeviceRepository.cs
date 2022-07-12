using System.Collections;
using System.Collections.Generic;

namespace GatewayDeviceMvc.Models.Repositories
{
    public interface IDeviceRepository
    {
         IEnumerable<Device> AllDevices { get; } 
        void CreateDevice(Device device);
        void DeleteDevice(Device device);
        Device GetDeviceById(int dId);
        void UpdateDevice(Device device);
    }
}