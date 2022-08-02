using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayDeviceMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace GatewayDeviceMvc.Models.Repositories
{
    public class GatewayRepository : IGatewayRepository
    {
        private readonly AppDbContext _appDbContext;

        public GatewayRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Gateway> AllGateways
        {
            get
            {
                return _appDbContext.Gateways.Include(x => x.Devices);
            }

        }

        public Gateway GetGatewayById(string gId)
        {
            return _appDbContext.Gateways.Include(g => g.Devices).FirstOrDefault(g => g.SerialNumber == gId);
        }

        public void UpdateGateway(Gateway gateway)
        {
            _appDbContext.Gateways.Update(gateway);
            _appDbContext.SaveChanges();
        }

        public void CreateGateway(Gateway gateway)
        {
            _appDbContext.Gateways.Add(gateway);
            _appDbContext.SaveChanges();
        }

        public void DeleteGateway(Gateway gateway)
        {
            _appDbContext.Gateways.Remove(gateway);
            _appDbContext.SaveChanges();
        }

    }
}
