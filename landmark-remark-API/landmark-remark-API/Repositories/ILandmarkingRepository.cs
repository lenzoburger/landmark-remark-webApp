using System.Collections.Generic;
using System.Threading.Tasks;
using landmark_remark_API.Models;

namespace landmark_remark_API.Repositories
{
    // Interface for User & MarkerNote queries repository
    public interface ILandmarkingRepository
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        Task<User> GetUserAsync(int id);
        Task<bool> SaveAll();
        Task<MarkerNote> GetMarkerNoteAsync(int id);
        Task<IEnumerable<MarkerNote>> GetMarkerNotesAsync(string searchString);        
        Task<IEnumerable<MarkerNote>> GetMarkerNotesAsync();
    }
}