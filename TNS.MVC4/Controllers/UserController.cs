using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNS.Db;
using TNS.Db.TestDataService;
using TNS.MVC4.Common;

namespace TNS.MVC4.Controllers
{
    public class UserController : PagingController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            // TNS.Web.Util.ExcelUtil.ToExcel(TNS.Db.TestDataService.PersonService.GetDataSet().Tables[0],Response);
            //List<Person> personList= TNS.Db.TestDataService.PersonService.GetList();
            // TNS.Web.Util.ExcelUtil.ToExcel(ToDataTable(personList),Response);
            return View();
        }

        private DataTable ToDataTable(IEnumerable<Person> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("编号");
            dt.Columns.Add("姓氏");
            dt.Columns.Add("名称");
            dt.Columns.Add("备注");
            foreach (Person person in list)
            {
                dt.Rows.Add(new string[] { person.personId, person.firstName, person.secondName, person.comments });
            }
            return dt;
        }
     
        [HttpPost]
        public ActionResult GetUsers()
        {
            Pager = BuildPageInfo();

            var list = new List<object>();//PersonService.GetList();
            var json = PagingHelper.ConvertJson(list, Pager.Total);
            return Content(json);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
