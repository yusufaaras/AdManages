using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Interfaces
{
    public interface ISilverPackageObserver
    {
        void Update(SilverPackages silverPackage);//TODO BEHAVIOURAL- OBSERVER METHOD USAGE 2
    }

}
