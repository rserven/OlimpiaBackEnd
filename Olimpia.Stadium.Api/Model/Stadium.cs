using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Olimpia.Stadium.Api.Model.Base;

namespace Olimpia.Stadium.Api.Model
{
    public class Stadium : StadiumBaseClass
    {
        public Stadium()
        {
            IsDeleted = false;
            Id = 0;
        }

        public ICollection<Gate> Gates { get; set; }
        public int MaxCapacity { get; set; }
    }
}
