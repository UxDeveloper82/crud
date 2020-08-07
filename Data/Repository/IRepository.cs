using PartsInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsInventory.Data.Repository
{
    public interface IRepository
    {
        Part GetPart(int id);
        List<Part> GetAllParts();

        void AddPart(Part part);

        void UpdatePart(Part part);

        void RemovePart(int id);

        Task<bool> SaveChangeAsync();

    }
}
