using DataService;
using DataService.DataModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataService.Models;

namespace AlefVinalServices.Services
{
    public interface IValueService
    {
        public Task CreateAsync(Value value);

        public Task<Value> GetAsync(int id);

        public Task<IEnumerable<Value>> GetAllAsync();

        public Task UpdateAsync(Value value);

        public Task<Value> DeleteAsync(int id);
    }
}

