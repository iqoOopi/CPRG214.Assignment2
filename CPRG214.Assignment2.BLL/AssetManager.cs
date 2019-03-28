using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.Assignment2.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAll()
        {
            var context = new AssetContext();
            var assets = context.Assets.Include(a => a.AssetType).ToList();
            return assets;
        }

        public static void Add(Asset ass)
        {
            var context = new AssetContext();
            context.Assets.Add(ass);
            context.SaveChanges();
        }

        public static Asset Find(int id)
        {
            var context = new AssetContext();
            return (context.Assets.Find(id));
        }

        public static void Update(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Update(asset);
            context.SaveChanges();
        }

        public static List<Asset> GetAllByAssetType(int assetTypeId)
        {
            var context = new AssetContext();
            var assets =
                context.Assets.
                Include(a => a.AssetType).Where(a => a.AssetTypeId == assetTypeId).
                ToList();
            return assets;
        }
    }
}
