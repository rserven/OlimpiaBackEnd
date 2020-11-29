using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olimpia.Stadium.Api.Response
{
    public class Person
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string FullName { get; set; }
        public string Gate { get; set; }
        public string Chair { get; set; }
    }
}
