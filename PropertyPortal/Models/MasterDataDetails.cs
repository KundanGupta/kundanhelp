using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyPortal.Models
{
    public static class MasterDataDetails
    {
        private static propertyportalEntities db = new propertyportalEntities();

        public static List<OwnershipTypeModel> OwnershipData;

        public static List<PropertyCategoryModel> PropertyCategoryData;

        public static List<FurnishMasterModel> FurnishMasterData;

        public static List<PropertyTypeModel> PropertyTypeData;

        public static List<TransactionTypeMaster> TransactionTypeData;

        public static void FillAllData()
        {
            FillOwnershipType();

            FillPropertyCateory();

            FillFurnishMaster();

            FillPropertyType();

            FillTransactionType();
        }

        //tblownershiptypemaster master data
        public static void FillOwnershipType()
        {
            var values = (from c in db.tblownershiptypemasters
                          select new OwnershipTypeModel
                          {
                              Id = c.ID,
                              OwnershipType = c.OwnershipType
                          }).ToList();

            OwnershipData = values;
        }

        //tblpropertycategory
        public static void FillPropertyCateory()
        {
            var values = (from c in db.tblpropertycategories
                          select new PropertyCategoryModel
                          {
                              Id = c.ID,
                              CategoryName = c.CategoryName
                          }).ToList();

            PropertyCategoryData = values;
        }

        //tblfurnishmaster
        public static void FillFurnishMaster()
        {
            var values = (from c in db.tblfurnishmasters
                          select new FurnishMasterModel
                          {
                              Id = c.ID,
                              Name = c.Name
                          }).ToList();

            FurnishMasterData = values;
        }

        //tblpropertytype
        public static void FillPropertyType()
        {
            var values = (from c in db.tblpropertytypes
                          select new PropertyTypeModel
                          {
                              Id = c.ID,
                              PropertyType = c.PropertyType
                          }).ToList();

            PropertyTypeData = values;
        }

        //tbltrantypemaster
        public static void FillTransactionType()
        {
            var values = (from c in db.tbltrantypemasters
                          select new TransactionTypeMaster
                          {
                              Id = c.ID,
                              Name = c.Name
                          }).ToList();

            TransactionTypeData = values;
        }

    }
}