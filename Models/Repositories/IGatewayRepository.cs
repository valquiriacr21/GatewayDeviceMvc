namespace GatewayDeviceMvc.Models.Repositories
{
    public interface IGatewayRepository
    {
        void CreateGateway(Gateway gateway);
        void DeleteGateway(Gateway gateway);
        Gateway GetGatewayById(int gId);
        void UpdateGateway(Gateway gateway);
    }
}