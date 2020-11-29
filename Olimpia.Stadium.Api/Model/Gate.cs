using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olimpia.Stadium.Api.Model.Base;

namespace Olimpia.Stadium.Api.Model
{
    public class Gate : StadiumBaseClass
    {
        public Gate()
        {
            IsDeleted = false;
            Id = 0;
        }

        public Stadium Stadium { get; set; }
        public ICollection<Chair> Chairs { get; set; }

        public enum CardinalDirection
        {
            North = 0, South, West, East
        }
    }
}
