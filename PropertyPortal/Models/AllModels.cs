﻿using System;
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

    public class OwnershipTypeModel
    {
        public long Id { get; set; }
        public string OwnershipType { get; set; }
    }

    public class PropertyCategoryModel
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class FurnishMasterModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class PropertyTypeModel
    {
        public long Id { get; set; }
        public string PropertyType { get; set; }
    }

    public class TransactionTypeMaster
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}