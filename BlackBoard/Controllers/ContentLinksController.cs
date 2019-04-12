using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackBoard.Models;
using BlackboardDatabase.Data;

namespace BlackBoard.Controllers
{
    public class ContentLinksController : Controller
    {
        private readonly BlackboardDbContext _context;

        public ContentLinksController(BlackboardDbContext context)
        {
            _context = context;
        }

        // GET: ContentLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentLink.ToListAsync());
        }

        // GET: ContentLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentLink = await _context.ContentLink
                .FirstOrDefaultAsync(m => m.ContentLinkId == id);
            if (contentLink == null)
            {
                return NotFound();
            }

            return View(contentLink);
        }

        // GET: ContentLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentLinkId,Link,Type")] ContentLink contentLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentLink);
        }

        // GET: ContentLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentLink = await _context.ContentLink.FindAsync(id);
            if (contentLink == null)
            {
                return NotFound();
            }
            return View(contentLink);
        }

        // POST: ContentLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContentLinkId,Link,Type")] ContentLink contentLink)
        {
            if (id != contentLink.ContentLinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentLinkExists(contentLink.ContentLinkId))
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
            return View(contentLink);
        }

        // GET: ContentLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentLink = await _context.ContentLink
                .FirstOrDefaultAsync(m => m.ContentLinkId == id);
            if (contentLink == null)
            {
                return NotFound();
            }

            return View(contentLink);
        }

        // POST: ContentLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentLink = await _context.ContentLink.FindAsync(id);
            _context.ContentLink.Remove(contentLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentLinkExists(int id)
        {
            return _context.ContentLink.Any(e => e.ContentLinkId == id);
        }
    }
}
