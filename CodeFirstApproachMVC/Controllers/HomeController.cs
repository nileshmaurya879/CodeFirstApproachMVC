using CodeFirstApproachMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Versioning;
using System.Diagnostics;

namespace CodeFirstApproachMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext _studentDBContext;

        public HomeController(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }
        public IActionResult Index()
        {
            var studentData = _studentDBContext.Students.ToList();
            return View(studentData);
        }
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentDBContext.Students.AddAsync(student);
                await _studentDBContext.SaveChangesAsync();
                TempData["inserted_data"] = "Inserted..";
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await _studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if(id != student.Id)
                return NotFound();
            else
            {
                if (ModelState.IsValid)
                {
                    _studentDBContext.Students.Update(student);
                    await _studentDBContext.SaveChangesAsync();
                    TempData["updated_data"] = "Updated..";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var data = await _studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _studentDBContext.Students.Remove(data);
                await _studentDBContext.SaveChangesAsync();
                TempData["deleted_data"] = "Deleted..";

                return RedirectToAction("Index");
            }
            return View(data);
        }
        public IActionResult Privacy() => View();
    }
}