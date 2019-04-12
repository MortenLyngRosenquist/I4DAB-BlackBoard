using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackboardDatabase.Data;
using BlackboardDatabase.DAL;
using BlackboardDatabase.Models;

namespace BlackBoard.Controllers
{
    public class CourseContentsController : Controller
    {
        private readonly BlackboardDbContext _context;

        public CourseContentsController(BlackboardDbContext context)
        {
            _context = context;
        }

        // GET: CourseContents
        public async Task<IActionResult> Index(string courseName)
        {
            var courseContent = await DAL.GetCourseContentByCourseName(courseName, _context);
            return View(courseContent.FirstOrDefault());
        }

        public async Task<IActionResult> Folders(int courseContentId)
        {
            var folders = await DAL.GetFoldersByCourseContentId(courseContentId, _context);
            return View(folders);
        }

        public async Task<IActionResult> ContentAreas(int folderId)
        {
            var contentArea = await DAL.GetContentAreaByFolderId(folderId, _context);
            return View(contentArea);
        }
    }
}
