using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using StudApp_AppDev.Models;

namespace StudApp_AppDev.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Student>.GetItemsAsync(d => !d.Stud_Valid || d.Stud_Valid) ;
            return View(items);
        }


        
        
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "ID,FName,LName,Stud_Email,Tel_No,Mobile_No,Stud_Valid")] Student item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Student>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }


        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "ID,FName,LName,Stud_Email,Tel_No,Mobile_No,Stud_Valid")] Student item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Student>.UpdateItemAsync(item.ID, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student item = await DocumentDBRepository<Student>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(Student student)
        {
            if(ModelState.IsValid)
            {
                await DocumentDBRepository<Student>.DeleteItemAsync(student.ID, student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = await DocumentDBRepository<Student>.GetItemAsync(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }














    }
}