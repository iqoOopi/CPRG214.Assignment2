using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Assignment2.BLL
{
    public class AssetTypeManager
    {
        public static List<AssetType> GetAll()
        {
            var context = new AssetContext();
            var rentals = context.AssetTypes.ToList();
            return rentals;
        }

        public static void Add(AssetType assType)
        {
            var context = new AssetContext();
            context.AssetTypes.Add(assType);
            context.SaveChanges();
        }

        public static AssetType Find(int id)
        {
            var context = new AssetContext();
            return (context.AssetTypes.Find(id));
        }

        public static void Update(AssetType assetType)
        {
            var context = new AssetContext();
            context.AssetTypes.Update(assetType);
            context.SaveChanges();
        }
    }
}
