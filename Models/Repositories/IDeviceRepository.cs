namespace GatewayDeviceMvc.Models.Repositories
{
    public interface IDeviceRepository
    {
        void CreateDevice(Device device);
        void DeleteDevice(Device device);
        Device GetDeviceById(int dId);
        void UpdateDevice(Device device);
    }
}