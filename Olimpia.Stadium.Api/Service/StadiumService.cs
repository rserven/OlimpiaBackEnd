using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olimpia.Stadium.Api.Data;
using Olimpia.Stadium.Api.Model;

namespace Olimpia.Stadium.Api.Service
{
    public class StadiumService
    {
        public static async Task<int> GetCapacityAsync()
        {
            var context = new Context();
            var stadium = await context.Stadiums.FirstOrDefaultAsync();
            var max = stadium.MaxCapacity;
            return max;
        }

        public static async Task<int> SetCapacityAsync(int capacity)
        {
            var context = new Context();
            var stadium = await context.Stadiums.FirstOrDefaultAsync();
            stadium.MaxCapacity = capacity;
            await context.SaveChangesAsync();
            return stadium.MaxCapacity;
        }
    }
}
