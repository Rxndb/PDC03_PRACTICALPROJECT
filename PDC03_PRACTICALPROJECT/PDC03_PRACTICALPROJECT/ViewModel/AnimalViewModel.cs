using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using PDC03_PRACTICALPROJECT.Model;
using System.Threading.Tasks;

namespace PDC03_PRACTICALPROJECT.ViewModel
{
    public class AnimalViewModel
    {
        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        public int InsertAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animals.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
        public async Task<List<AnimalModel>> GetAllAnimal()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Animals.ToListAsync();
            return res;
        }

        public int DeleteAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animals.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public async Task<int> UpdateAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animals.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}
