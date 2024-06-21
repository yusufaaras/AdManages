using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Domain.Common
{
    public class PackagesEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image2 { get; set; }
    }
}
