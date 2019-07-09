using System.Collections.Generic;
using System.Threading.Tasks;
using landmark_remark_API.Data;
using landmark_remark_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace landmark_remark_API.Repositories
{
    // Ef Core repository for User & MarkerNote queries
    public class LandmarkingRepository : ILandmarkingRepository
    {
        //db context
        private readonly LandmarkingContext _context;

        //Constructor to set db context
        public LandmarkingRepository(LandmarkingContext context)
        {
            _context = context;
        }

        //GET User by id
        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.Include(n => n.UserMarkerNotes).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        //Add new entity to database
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        //Remove entity from database
        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //Save all changes to database
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // GET MarkerNote by id
        public async Task<MarkerNote> GetMarkerNoteAsync(int id)
        {
            var markerNote = await _context.MarkerNotes.Include(note => note.User).FirstOrDefaultAsync(note => note.Id == id);
            return markerNote;
        }

        // GET MarkerNote by username Or note content in [searchString]
        public async Task<IEnumerable<MarkerNote>> GetMarkerNotesAsync(string searchString)
        {
            var markerNotes = from m in _context.MarkerNotes.Include(note => note.User)
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                markerNotes = markerNotes.
                Where(note => note.User.Username.
                Contains(searchString) || note.Note.Contains(searchString));
            }

            return await markerNotes.ToListAsync();
        }

        // GET All MarkerNotes
        public async Task<IEnumerable<MarkerNote>> GetMarkerNotesAsync()
        {
            var markerNotes = await _context.MarkerNotes.Include(note => note.User).ToListAsync();
            return markerNotes;
        }

    }
}