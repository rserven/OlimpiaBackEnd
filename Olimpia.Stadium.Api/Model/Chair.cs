using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Olimpia.Stadium.Api.Model.Base;

namespace Olimpia.Stadium.Api.Model
{
    public class Chair : StadiumBaseClass
    {
        public Chair()
        {
            IsDeleted = false;
            Id = 0;
        }

        public Gate Gate { get; set; }
        public ICollection<Person> Persons { get; set; }

    }
}
