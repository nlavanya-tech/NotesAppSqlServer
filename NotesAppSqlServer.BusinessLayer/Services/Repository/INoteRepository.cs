using NotesAppSqlServer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAppSqlServer.BusinessLayer.Services.Repository
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> ReadAsync();
        Task<Note> CreateAsync(Note notes);
        Task<Note> UpdateAsync(Note note);
        Task<Note> DeleteAsync(Note notes);
    }
}
