using NotesAppSqlServer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAppSqlServer.BusinessLayer.Services.Repository
{
    public class NoteRepository : INoteRepository
    {
        private NotesAppContext _dbContext = new NotesAppContext();

        //Get notes from Inmemory db   
        public async Task<IEnumerable<Note>> ReadAsync()
        {
            var notes = _dbContext.Notes.ToList();
            return notes;
        }
        //Add notes into Inmemory Db and return notes
        public async Task<Note> CreateAsync(Note notes)
        {
            _dbContext.Notes.Add(notes);
            _dbContext.SaveChanges();
            return notes;
        }
        //Update Notes into Inmemory Db and return notes 
        public async Task<Note> UpdateAsync(Note note)
        {
            var notes = _dbContext.Notes.FirstOrDefault(e => e.Id == note.Id);
            if (notes != null)
            {
                notes.Id = note.Id;
                notes.Title = note.Title;
                notes.Author = note.Author;
                notes.Description = note.Description;
                notes.Status = note.Status;
                _dbContext.SaveChanges();
            }
            else
            {
                note = null;
            }
            return note;
        }
        //Delete Notes from INmemory Db and return Notes
        public async Task<Note> DeleteAsync(Note notes)
        {
            Note note = _dbContext.Notes.Find(notes.Id);

            if (notes != null)
            {
                _dbContext.Notes.Remove(note);
                _dbContext.SaveChanges();
                return notes;
            }
            else
            {
                return null;
            }
        }
    }
}
