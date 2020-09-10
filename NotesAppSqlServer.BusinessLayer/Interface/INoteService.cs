using NotesAppSqlServer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAppSqlServer.BusinessLayer.Interface
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> ReadAsync();
        Task<Note> CreateAsync(Note notes);
        Task<Note> UpdateAsync(Note notes);
        Task<Note> DeleteAsync(Note notes);
    }
}
