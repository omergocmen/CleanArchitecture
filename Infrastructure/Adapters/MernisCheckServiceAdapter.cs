using Application.Interfaces.ExternalServices;
using Domain.Entities.CustomerDomain;
using MernisIdentityCheckService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters
{
    public class MernisCheckServiceAdapter : ICheckService
    {
        private readonly KPSPublicSoapClient _mernisService;
        public MernisCheckServiceAdapter()
        {
            _mernisService= new KPSPublicSoapClient(new KPSPublicSoapClient.EndpointConfiguration());
        }
        public async Task<bool> IsUserValid(Customer customer)
        {
            //123456 tc kimlik no yerine yazılmıştır tamamen örnektir
            var result = await _mernisService.TCKimlikNoDogrulaAsync(123456,"Ömer","Göçmen",2000);
            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
