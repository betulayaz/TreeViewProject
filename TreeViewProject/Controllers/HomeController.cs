using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeViewProject.Models;

namespace TreeViewProject.Controllers
{
    public class HomeController : Controller
    {
        TreeViewDbEntities db = new TreeViewDbEntities();
        public ActionResult Index()
        {
            List<tbl_notes> all = new List<tbl_notes>();
            all = db.tbl_notes.Where(model => model.Note_IsActive == 1).OrderBy(a => a.Note_ParentId).ToList();
            return View(all);
        }
    }
}