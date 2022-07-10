using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceMvc.Models.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _appDbContext;

        public DeviceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        IEnumerable<Device> AllDevices()
        {
            return _appDbContext.Devices;
        }

        public Device GetDeviceById(int dId)
        {
            return _appDbContext.Devices.FirstOrDefault(d => d.UID == dId);
        }

        public void UpdateDevice(Device device)
        {
            _appDbContext.Devices.Update(device);
            _appDbContext.SaveChanges();
        }

        public void CreateDevice(Device device)
        {
            _appDbContext.Devices.Add(device);
            _appDbContext.SaveChanges();
        }

        public void DeleteDevice(Device device)
        {
            _appDbContext.Devices.Remove(device);
            _appDbContext.SaveChanges();
        }
    }
}
