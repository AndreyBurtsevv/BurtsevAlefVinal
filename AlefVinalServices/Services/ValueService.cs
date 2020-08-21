using AlefVinalServices.Validation;
using AutoMapper;
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

        private readonly IMapper _mapper;

        private readonly ValueValidator _validations;

        public ValueService(ValuesDbContext db, IMapper mapper, ValueValidator validations)
        {
            _db = db;
            _mapper = mapper;
            _validations = validations;
        }

        public async Task CreateAsync(Value value)
        {
            if (!ValidateValue(value))
            {
                return;
            }

            DBValue result = _mapper.Map<DBValue>(value);
            _db.Values.Add(result);
            await _db.SaveChangesAsync();
        }

        public async Task<Value> GetAsync(int id)
        {
            DBValue value = await _db.Values.FirstOrDefaultAsync(x => x.Id == id);
            Value result = _mapper.Map<Value>(value);
            if (value == null)
                return null;
            return result;
        }

        public async Task<IEnumerable<Value>> GetAllAsync()
        {
            var list = await _db.Values.ToListAsync();
                 
            return _mapper.Map<IEnumerable<DBValue>, IEnumerable<Value>>(list).ToList();
        }

        public async Task UpdateAsync(Value value)
        {
            if (!ValidateValue(value))
            {
                return;
            }

            if (!_db.Values.Any(x => x.Id == value.Id))
            {
                return;
            }
            DBValue result = _mapper.Map<DBValue>(value);
            _db.Update(result);
            await _db.SaveChangesAsync();
        }

        public async Task<Value> DeleteAsync(int id)
        {
            DBValue value = _db.Values.FirstOrDefault(x => x.Id == id);
            Value result = _mapper.Map<Value>(value);
            if (value == null)
            {
                return null;
            }
            _db.Values.Remove(value);
            await _db.SaveChangesAsync();
            return result;
        }

        private bool ValidateValue(Value value)
        {
            var result = _validations.Validate(value);

            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }
    }
}
