using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Controllers
{
    public class ComplexModelBindingController : Controller
    {
        //
        // GET: /ComplexModelBinding/

        [HttpGet]
        public ActionResult BindComplexModel()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult BindComplexModel(Person person)
        {
            return View(person);
        }

        [HttpGet]
        public ActionResult NumericAndicatorList()
        {
            return View(new List<Person>() {new Person(){BirthDate = DateTime.MinValue, Role = Role.Admin}, new Person(){BirthDate = DateTime.MinValue, Role = Role.Admin}});
        }

        [HttpPost]
        public ActionResult NumericAndicatorList(IList<Person> people)
        {
            return View(people);
        }

        [HttpGet]
        public ActionResult NonNumericAndicatorList()
        {
            return View(new List<Person>() { new Person() {BirthDate = DateTime.MinValue, Role = Role.Admin }, new Person() { BirthDate = DateTime.MinValue, Role = Role.Admin } });
        }

        [HttpPost]
        public ActionResult NonNumericAndicatorList(IList<Person> people)
        {
            return View(people);
        }

        [HttpGet]
        public ActionResult DictionaryBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DictionaryBinding(IDictionary<string, Person> people)
        {
            return View();
        }

        [ActionName("UpdateModelInCode")]
        [HttpGet]
        public ActionResult GetUpdateModelInCode()
        {
            return View();
        }

        [ActionName("UpdateModelInCode")]
        [HttpPost]
        public ActionResult PostUpdateModelInCode(string id)
        {
            //FormValueProvider()
            //RouteDataValueProvider()
            //QueryStringValueProvider()
            //HttpFileCollectionValueProvider()
            UpdateModel(id, new FormValueProvider(ControllerContext));
            return View();
        }

        [ActionName("BindFileModel")]
        [HttpGet]
        public ActionResult GetBindFileModel()
        {
            return View();
        }

        [ActionName("BindFileModel")]
        [HttpPost]
        public ActionResult PostBindFileMode(HttpPostedFileBase file)
        {
            //first Scenario
            //string fileName = @"~/Files/" + Guid.NewGuid().ToString();
            //file.SaveAs(fileName);

            //Second Scenario
            byte[] uploadedBytes = new byte[file.ContentLength];
            file.InputStream.Read(uploadedBytes, 0, file.ContentLength);
            System.IO.FileStream fs = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + Guid.NewGuid().ToString() + ".htm" , System.IO.FileMode.Create, System.IO.FileAccess.Write);
            fs.Write(uploadedBytes, 0, file.ContentLength);
            fs.Close();
            return View();
        }





    }
}
