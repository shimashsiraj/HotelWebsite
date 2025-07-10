using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saint.Data;
using Saint.Models;

namespace Saint.Controllers
{
    public class RoomTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomTypesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomTypes.ToListAsync());
        }

        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Capacity")] RoomType roomType, List<IFormFile> RoomImages)
        //public async Task<IActionResult> Create(RoomType roomType, List<IFormFile> RoomImages)

        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var kvp in ModelState)
        //        {
        //            foreach (var error in kvp.Value.Errors)
        //            {
        //                Console.WriteLine($"❌ Field: {kvp.Key} — Error: {error.ErrorMessage}");
        //            }
        //        }
        //        _context.Add(roomType);
        //        await _context.SaveChangesAsync();

        //        if (RoomImages != null && RoomImages.Count > 0)
        //        {
        //            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "roomtypes", roomType.Id.ToString());
        //            Directory.CreateDirectory(uploadsFolder);

        //            foreach (var image in RoomImages)
        //            {
        //                if (image.Length > 0)
        //                {
        //                    var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
        //                    var filePath = Path.Combine(uploadsFolder, fileName);

        //                    using (var stream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        await image.CopyToAsync(stream);
        //                    }

        //                    var roomImage = new RoomImage
        //                    {
        //                        RoomTypeId = roomType.Id,
        //                        ImageUrl = $"/images/roomtypes/{roomType.Id}/{fileName}"
        //                    };
        //                    _context.RoomImages.Add(roomImage); // or _context.RoomsImages if you didn't rename
        //                }
        //            }

        //            await _context.SaveChangesAsync();
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }

        //    // Log validation errors
        //    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        //        Console.WriteLine(error.ErrorMessage);

        //    return View(roomType);
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(roomType);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //return View(roomType);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,Capacity")] RoomType roomType, List<IFormFile> RoomImages)
        {
            Console.WriteLine("🎯 POST Create hit");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState is invalid");
                foreach (var kvp in ModelState)
                {
                    foreach (var error in kvp.Value.Errors)
                    {
                        Console.WriteLine($"❌ Field: {kvp.Key} — Error: {error.ErrorMessage}");
                    }
                }
                return View(roomType);
            }

            Console.WriteLine("✅ ModelState is valid");

            // Start a transaction
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Save RoomType first to generate ID
                _context.Add(roomType);
                await _context.SaveChangesAsync();

                if (RoomImages != null && RoomImages.Count > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "roomtypes", roomType.Id.ToString());
                    Directory.CreateDirectory(uploadsFolder);

                    foreach (var image in RoomImages)
                    {
                        if (image.Length > 0)
                        {
                            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                            var filePath = Path.Combine(uploadsFolder, fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await image.CopyToAsync(stream);
                            }

                            var roomImage = new RoomImage
                            {
                                RoomTypeId = roomType.Id,
                                ImageUrl = $"/images/roomtypes/{roomType.Id}/{fileName}"
                            };
                            _context.RoomImages.Add(roomImage);
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                // Commit the transaction if all succeeded
                await transaction.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Rollback transaction on error
                await transaction.RollbackAsync();

                Console.WriteLine($"❌ Exception during save: {ex.Message}");
                ModelState.AddModelError("", "An error occurred saving the room type and images.");

                return View(roomType);
            }
        }




        // GET: RoomTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Capacity")] RoomType roomType)
        {
            if (id != roomType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeExists(roomType.Id))
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
            return View(roomType);
        }

        // GET: RoomTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType != null)
            {
                _context.RoomTypes.Remove(roomType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeExists(int id)
        {
            return _context.RoomTypes.Any(e => e.Id == id);
        }
    }
}
