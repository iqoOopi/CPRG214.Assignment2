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
    public class AssetTypesController : Controller
    {
        // GET: AssetTypes
        public async Task<IActionResult> Index()
        {
            var assetTypes = AssetTypeManager.GetAll().ToList();
            return View(assetTypes);
        }

        // GET: AssetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assetTypes = AssetTypeManager.GetAll().ToList();
            var assetType = assetTypes.FirstOrDefault(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        // GET: AssetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AssetType assetType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    AssetTypeManager.Add(assetType);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: AssetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = AssetTypeManager.Find((int)id);
            if (assetType == null)
            {
                return NotFound();
            }
            return View(assetType);
        }

        // POST: AssetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AssetType assetType)
        {
            if (id != assetType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AssetTypeManager.Update(assetType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetTypeExists(assetType.Id))
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
            return View(assetType);
        }

        //// GET: AssetTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var assetType = await _context.AssetTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (assetType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assetType);
        //}

        //// POST: AssetTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var assetType = await _context.AssetTypes.FindAsync(id);
        //    _context.AssetTypes.Remove(assetType);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AssetTypeExists(int id)
        {
            bool result = AssetTypeManager.Find(id) == null ? false : true;
            return result;
        }
    }
}

