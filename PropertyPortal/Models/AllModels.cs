using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyPortal.Models
{
    public class MasterMenuClass
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public long Order { get; set; }
        public string IsParent { get; set; }
        public string HasChild { get; set; }
    }
}