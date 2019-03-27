﻿using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
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
            var assets = context.Assets.ToList();
            return assets;
        }

        public static void Add(Asset ass)
        {
            var context = new AssetContext();
            context.Assets.Add(ass);
            context.SaveChanges();
        }
    }
}
