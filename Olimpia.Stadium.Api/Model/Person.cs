using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Olimpia.Stadium.Api.Model.Base;

namespace Olimpia.Stadium.Api.Model
{
    public class Person : GenericBaseClass
    {
        public Person()
        {
            IsDeleted = false;
            Id = 0;
        }

        public int DocumentId { get; set; }
        public string FullName { get; set; }

        [ForeignKey("ChairId")]
        public int ChairId { get; set; }
        
        public Chair Chair { get; set; }
    }
}
