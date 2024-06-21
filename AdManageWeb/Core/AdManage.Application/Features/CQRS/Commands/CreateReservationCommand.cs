using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Commands
{
    public class CreateReservationCommand
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }=DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; } 
        public AppUser AppUser { get; set; }
        public int? BronzePackagesId { get; set; }
        public int? GoldPackagesId { get; set; }
        public int? SilverPackagesId { get; set; }
        public BronzePackages BronzePackages { get; set; }
        public GoldPackages GoldPackages { get; set; }
        public SilverPackages SilverPackages { get; set; }
    }
}
