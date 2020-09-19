//using NotesAppSqlServer.BusinessLayer.Interface;
using NotesAppSqlServer.BusinessLayer.Interface;
using NotesAppSqlServer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NotesAppSqlServer.Controllers
{
    public class NoteController : ApiController
    {
        //create local instance
        private readonly INoteService Service;

        public NoteController(INoteService service)
        {
            this.Service = service;
        }

        // GET: api/Note
        //This Method Gets Request Call from User to Read Notes.
        [HttpGet]
        public Task<IEnumerable<Note>> GetAllNotes()
        {
            var notes = this.Service.ReadAsync();
            return notes;
        }

        // POST: api/Notes
        //This Method Gets Request Call from User to Create Notes.
        [HttpPost]
        public void SubmitNotes([FromBody] Note notes)
        {
             this.Service.CreateAsync(notes);
        }

        // PUT: api/Notes/5
        //This Method Gets Request Call from User to Update Notes.
        [HttpPut]
        public async void UpdateNotes([FromBody] Note notes)
        {
            await this.Service.UpdateAsync(notes);
        }

        // DELETE: api/ApiWithActions/5
        //This Method Gets Request Call from User to Delete Notes.
        [HttpDelete]
        public async void DeleteNotes([FromBody] Note notes)
        {
            await this.Service.DeleteAsync(notes);
        }
    }
}
