using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olimpia.Stadium.Api.Data;
using Olimpia.Stadium.Api.Model;

namespace Olimpia.Stadium.Api.Service
{
    public class GateService
    {
        public static async Task<int> GetChairs(string cardinal)
        {
            var context = new Context();
            var gate = await context.Gates.Include(c => c.Chairs).FirstOrDefaultAsync(d => d.Location == cardinal.ToString());
            var chairs = gate.Chairs;
            return chairs.Count;
        }
    }
}
