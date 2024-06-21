using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Interfaces
{
    public interface ISilverPackagesStrategy
    {
        Task<List<SilverPackages>> GetSilverPackages();
    }

}
