using Domain.Entities.CustomerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ExternalServices
{
    public interface ICheckService
    {
        Task<bool> IsUserValid(Customer customer);
    }
}
