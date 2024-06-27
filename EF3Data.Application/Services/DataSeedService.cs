using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Application.Services
{
    public class DataSeedService
    {
        private readonly IDataSeeder _dataSeeder;

        public DataSeedService(IDataSeeder dataSeeder)
        {
            _dataSeeder = dataSeeder;
        }

        public async Task SeedAsync()
        { 
            await _dataSeeder.SeedDataAsync();
        }
    }
}
