using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VGCApp.Data;
//using VGCApp.Migrations;
using VGCApp.Models;

namespace VGCApp.Controllers
{
    public class VideoGameModelsController : Controller
    {
        private readonly VGCAppContext _context;

        public VideoGameModelsController(VGCAppContext context)
        {
            _context = context;
        }

        // GET: VideoGameModels
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 3;
            var videogames = from s in _context.VideoGameModel
                           select s;
            return _context.VideoGameModel != null ? 
                          View(await PaginatedList<VideoGameModel>.CreateAsync(videogames.AsNoTracking(), pageNumber ?? 1, pageSize)) :
                          Problem("Entity set 'VGCAppContext.VideoGameModel'  is null.");
        }

        // GET: VideoGameModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VideoGameModel == null)
            {
                return NotFound();
            }

            var videoGameModel = await _context.VideoGameModel
                .FirstOrDefaultAsync(m => m.ID == id);

            if (videoGameModel == null)
            {
                return NotFound();
            }
            PopulateReviewList(videoGameModel);
            return View(videoGameModel);
        }

        [HttpPost, ActionName("AddReview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([Bind("ID,VideoGameModelID,UName,PostDate,ReviewText")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return Redirect("Details/"+review.VideoGameModelID);
            }
            return View(review);
        }

        private void PopulateReviewList(VideoGameModel videoGame)
        {
            var reviewQuery = from d in _context.Reviews
                                   where d.VideoGameModelID == videoGame.ID
                                   select d;
            videoGame.Reviews = reviewQuery.ToList();
        }

        // GET: VideoGameModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoGameModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Genre,ReleaseDate,Price")] VideoGameModel videoGameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGameModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoGameModel);
        }

        // GET: VideoGameModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VideoGameModel == null)
            {
                return NotFound();
            }

            var videoGameModel = await _context.VideoGameModel.FindAsync(id);
            if (videoGameModel == null)
            {
                return NotFound();
            }
            return View(videoGameModel);
        }

        // POST: VideoGameModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Genre,ReleaseDate,Price")] VideoGameModel videoGameModel)
        {
            if (id != videoGameModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGameModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameModelExists(videoGameModel.ID))
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
            return View(videoGameModel);
        }

        // GET: VideoGameModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VideoGameModel == null)
            {
                return NotFound();
            }

            var videoGameModel = await _context.VideoGameModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (videoGameModel == null)
            {
                return NotFound();
            }

            return View(videoGameModel);
        }

        // POST: VideoGameModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VideoGameModel == null)
            {
                return Problem("Entity set 'VGCAppContext.VideoGameModel'  is null.");
            }
            var videoGameModel = await _context.VideoGameModel.FindAsync(id);
            if (videoGameModel != null)
            {
                _context.VideoGameModel.Remove(videoGameModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGameModelExists(int id)
        {
          return (_context.VideoGameModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
