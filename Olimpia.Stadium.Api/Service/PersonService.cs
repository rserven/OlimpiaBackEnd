using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olimpia.Stadium.Api.Data;
using Olimpia.Stadium.Api.Model;
using Olimpia.Stadium.Api.Util;

namespace Olimpia.Stadium.Api.Service
{
    public class PersonService
    {
        public static async Task<Response.Person> AddPersonAsync(int documentId, string fullName, string cardinal)
        {
            var context = new Context();

            //Validate Stadium max capacity
            var percent = await StadiumService.GetCapacityAsync();
            var max = (80018 * percent) / 100;
            var persons = await context.Persons.CountAsync(d => !d.IsDeleted);

            if (max == persons)
            {
                throw new Exception("El Estadio ha llegado a su maxima capacidad.");
            }

            var person = context.Persons
            .Include(s => s.Chair)
            .Include(e => e.Chair.Gate)
            .FirstOrDefault(i => i.DocumentId == documentId && !i.IsDeleted);

            //If no exist person
            if (person == null)
            {
                //Add new Person
                var cardinalDirection = (Gate.CardinalDirection)Enum.Parse(typeof(Gate.CardinalDirection), cardinal);
                var chair = await ChairService.GetAsync(cardinalDirection);

                var newPerson = new Person
                {
                    ChairId = chair.Id,
                    Created = DateTime.Now,
                    DocumentId = documentId,
                    FullName = fullName
                };
                await context.Persons.AddAsync(newPerson);
                await context.SaveChangesAsync();
                await context.DisposeAsync();

                //return new Person
                var resp = new Response.Person
                {
                    Id = newPerson.Id,
                    Chair = chair.Name,
                    Gate = chair.Gate.Name,
                    DocumentId = newPerson.DocumentId,
                    FullName = newPerson.FullName
                };

                return resp;
            }
            else
            {
                //return current Person
                var resp = new Response.Person
                {
                    Id = person.Id,
                    Chair = person.Chair.Name,
                    Gate = person.Chair.Gate.Name,
                    DocumentId = person.DocumentId,
                    FullName = person.FullName
                };

                return resp;
            }
        }

        public static async Task<bool> DelPersonAsync(int documentId)
        {
            var context = new Context();
            var person = await context.Persons.FirstOrDefaultAsync(d => d.DocumentId == documentId);
            if (person == null) return false;

            //Delete Person
            person.IsDeleted = true;
            person.Deleted = DateTime.Now;

            //Delete Chair
            var chair = context.Chairs.FirstOrDefault(c => c.Id == person.ChairId);
            if (chair != null)
            {
                chair.IsDeleted = true;
                chair.Deleted = DateTime.Now;
            }

            await context.SaveChangesAsync();
            return true;
        }
    }
}
