using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TreeViewProject.Models;

namespace TreeViewProject.Controllers
{
    public class NoteApiController : ApiController
    {
        TreeViewDbEntities db = new TreeViewDbEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetNote()
        {
            List<tbl_notes> note = db.tbl_notes.ToList();
            return Ok(note);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetNoteById(int id)
        {
            var note = db.tbl_notes.Where(model => model.Note_Id == id).FirstOrDefault();
            return Ok(note);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult NoteInsert(tbl_notes note)
        {
            db.tbl_notes.Add(note);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult NoteDelete(tbl_notes note)
        {
            var emp = db.tbl_notes.Where(model => model.Note_Id == note.Note_Id).FirstOrDefault();
            if (emp != null)
            {
                List<tbl_notes> notes = db.tbl_notes.Where(model => model.Note_IsActive == 1).ToList();
                foreach (var item in notes)
                {
                    if (item.Note_ParentId == note.Note_Id)
                    {
                        item.Note_IsActive = 0;
                    }
                }
                emp.Note_Id = note.Note_Id;
                emp.Note_IsActive = 0;
                emp.Note_Name = note.Note_Name;
                emp.Note_ParentId = note.Note_ParentId;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }
    }
}