using DataService;
using DataService.DataModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefVinalServices.Services
{
    public class ValueService : IValueService
    {
        private readonly ValuesDbContext _db;

        public ValueService(ValuesDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Value value)
        {
            if (value == null)
            {
                return;
            }

            _db.Values.Add(value);
            await _db.SaveChangesAsync();
        }

        public async Task<Value> GetAsync(int id)
        {
            Value value = await _db.Values.FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
                return null;
            return value;
        }

        public async Task<IEnumerable<Value>> GetAllAsync()
        {
            return await _db.Values.ToListAsync();
        }

        public async Task UpdateAsync(Value value)
        {
            if (value == null)
            {
                return;
            }
            if (!_db.Values.Any(x => x.Id == value.Id))
            {
                return;
            }

            _db.Update(value);
            await _db.SaveChangesAsync();
        }

        public async Task<Value> DeleteAsync(int id)
        {
            Value value = _db.Values.FirstOrDefault(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _db.Values.Remove(value);
            await _db.SaveChangesAsync();
            return value;
        }
    }
}
