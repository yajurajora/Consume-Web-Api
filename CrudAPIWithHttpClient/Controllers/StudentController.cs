using CrudAPIWithHttpClient.ConsumeAPI;
using CrudAPIWithHttpClient.Models;
using Google.Api.Gax.Grpc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CrudAPIWithHttpClient.Controllers
{
    public class StudentController : Controller
    {
        private readonly IExternalHttpClient _externalHttpClient;
        public StudentController(IExternalHttpClient externalHttpClient)
        {
            _externalHttpClient = externalHttpClient;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            List<Student> studentsList = new List<Student>();
            var response = _externalHttpClient.GetExternalAsync(studentsList, "api/Students");
            return View(response);
        }
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var response = _externalHttpClient.PutExternalAsyncGet(id,"api/Students/");
            return View(response);
        }
        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                _externalHttpClient.PostExternalAsync(student, "api/Students");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var response = _externalHttpClient.PutExternalAsyncGet(id,"api/Students/");
            return View(response);
        }
        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                _externalHttpClient.PutExternalAsync(student, "api/Students/");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: StudentController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var response = _externalHttpClient.PutExternalAsyncGet(id,"api/Students/");
            return View(response);
        }
        // POST: StudentController/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student, int id)
        {
             _externalHttpClient.DeleteExternalAsync(student,"api/Students/", id);
            return RedirectToAction(nameof(Index));
        }       
    }
}
