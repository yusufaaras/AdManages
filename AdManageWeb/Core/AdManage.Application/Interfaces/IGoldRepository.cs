using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Interfaces
{
    public interface IGoldRepository
    {
        Task<List<GoldPackages>> GetGoldListWithPackages();
        Task<List<GoldPackages>> GetGoldListWithPackages2();
        List<GoldPackages> GetLast5GoldWithPackages();
        int GetGoldCount();
    }
}
