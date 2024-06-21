using AdManage.Application.Interfaces;
using AdManage.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Domain.Entities
{
    public class SilverPackages : PackagesEntityBase
    {
        public List<Reservation> Reservations { get; set; }

        private List<ISilverPackageObserver> observers = new List<ISilverPackageObserver>();//TODO BEHAVIOURAL- OBSERVER METHOD USAGE 1

        public void Attach(ISilverPackageObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(ISilverPackageObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }
    }
}
