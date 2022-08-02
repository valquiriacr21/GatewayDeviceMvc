using System.Collections;
using System.Collections.Generic;

namespace GatewayDeviceMvc.Models.Repositories
{
    public interface IGatewayRepository
    {
        IEnumerable<Gateway> AllGateways { get; }
        void CreateGateway(Gateway gateway);
        void DeleteGateway(Gateway gateway);
        Gateway GetGatewayById(string gId);
        void UpdateGateway(Gateway gateway);
    }
}