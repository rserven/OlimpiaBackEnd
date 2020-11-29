using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olimpia.Stadium.Api.Data;
using Olimpia.Stadium.Api.Model;
using Olimpia.Stadium.Api.Util;

namespace Olimpia.Stadium.Api.Service
{
    public class ChairService
    {
        //Generate random Chair
        public static async Task<Chair> GetAsync(Gate.CardinalDirection cardinal)
        {
            var context = new Context();
            var gate = context.Gates.FirstOrDefault(l => l.Location == cardinal.ToString());
            var chairId = Generic.RandomNumber(cardinal);
            var chairName = Generic.ReturnFirstLetter(cardinal.ToString()) + chairId;

            //Verify if exist Chair Name
            var chairFound = false;
            while (!chairFound)
            {
                if (context.Chairs.Any(d => d.Name == chairName && !d.IsDeleted))
                {
                    //Create new chairName
                    chairId = Generic.RandomNumber(cardinal);
                    chairName = Generic.ReturnFirstLetter(cardinal.ToString()) + chairId;
                }
                else
                {
                    chairFound = true;
                }
            }

            var chair = new Chair
            {
                Created = DateTime.Now,
                Location = cardinal.ToString(),
                Gate = gate,
                Name = chairName
            };

            await context.Chairs.AddAsync(chair);
            await context.SaveChangesAsync();
            await context.DisposeAsync();
            return chair;
        }


    }
}
