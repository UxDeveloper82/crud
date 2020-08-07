using PartsInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPart(Part part)
        {
            _context.Parts.Add(part);
        }

        public List<Part> GetAllParts()
        {
            return _context.Parts.ToList();
        }

        public Part GetPart(int id)
        {
            return _context.Parts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePart(int id)
        {
            _context.Parts.Remove(GetPart(id));
        }

        public void UpdatePart(Part part)
        {
            _context.Parts.Update(part);
        }

        public async Task<bool> SaveChangeAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
