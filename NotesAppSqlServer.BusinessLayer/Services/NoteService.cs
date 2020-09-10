using NotesAppSqlServer.BusinessLayer.Interface;
using NotesAppSqlServer.BusinessLayer.Services.Repository;
using NotesAppSqlServer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAppSqlServer.BusinessLayer.Services
{
    public class NoteService : INoteService
    {
        //create local instance 
        private readonly INoteRepository _repositary;

        public NoteService(INoteRepository repositary)
        {
            _repositary = repositary;
        }

        //private InMemoryDb DbContext;
        //public NoteService(InMemoryDb DbContext)
        //{
        //    this.DbContext = DbContext;
        //}
        //Get Notes and retrun list of notes
        public async Task<IEnumerable<Note>> ReadAsync()
        {
            var notes = await _repositary.ReadAsync();
            // var notes = this.DbContext.notes.ToList();
            return notes;
        }
        //Create notes
        public async Task<Note> CreateAsync(Note notes)
        {
            await _repositary.CreateAsync(notes);
            //this.DbContext.Add(notes);
            //this.DbContext.SaveChanges();
            return notes;
        }
        //Update Notes
        public async Task<Note> UpdateAsync(Note notes)
        {
            var note = await _repositary.UpdateAsync(notes);

            return note;
        }
        //Delete Notes 
        public async Task<Note> DeleteAsync(Note notes)
        {
            var result = await _repositary.DeleteAsync(notes);
            return result;
        }
    }
}
