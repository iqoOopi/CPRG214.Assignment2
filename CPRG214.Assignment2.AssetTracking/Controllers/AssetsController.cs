using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
using CPRG214.Assignment2.BLL;

namespace CPRG214.Assignment2.AssetTracking.Controllers
{
    public class AssetsController : Controller
    {


        // GET: Assets
        public async Task<IActionResult> Index(int? assetTypeId)
        {
            var assetTypes = AssetTypeManager.GetAll();
            var list = new SelectList(assetTypes, "Id", "Name");
            ViewBag.AssetTypes = list;
            if (assetTypeId == null)
            {
                var assets = AssetManager.GetAll().ToList();
                return View(assets);
            }
            else
            {
                var assets = AssetManager.GetAllByAssetType((int)assetTypeId);
                return View(assets);
            }
            
        }

        public async Task<IActionResult> Search(int? assetTypeId)
        {
            var assetTypes = AssetTypeManager.GetAll();
            var list = new SelectList(assetTypes, "Id", "Name");
            ViewBag.AssetTypes = list;
            if (assetTypeId == null)
            {
                var assets = AssetManager.GetAll().ToList();
                return View(assets);
            }
            else
            {
                var assets = AssetManager.GetAllByAssetType((int)assetTypeId);
                return View(assets);
            }

        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assets = AssetManager.GetAll().ToList();
            var asset = assets.FirstOrDefault(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["AssetTypeId"] = new SelectList(AssetTypeManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagNumber,AssetTypeId,Manufacturer,Model,Description,SerialNumber")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    AssetManager.Add(asset);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(asset);
                }
            }
            ViewData["AssetTypeId"] = new SelectList(AssetTypeManager.GetAll(), "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = AssetManager.Find((int)id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["AssetTypeId"] = new SelectList(AssetTypeManager.GetAll(), "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TagNumber,AssetTypeId,Manufacturer,Model,Description,SerialNumber")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AssetManager.Update(asset);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetTypeId"] = new SelectList(AssetTypeManager.GetAll(), "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        //// GET: Assets/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var asset = await _context.Assets
        //        .Include(a => a.AssetType)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (asset == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(asset);
        //}

        //// POST: Assets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var asset = await _context.Assets.FindAsync(id);
        //    _context.Assets.Remove(asset);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


        private bool AssetExists(int id)
        {
            bool result = AssetManager.Find(id) == null ? false : true;
            return result;
        }
    }
}


