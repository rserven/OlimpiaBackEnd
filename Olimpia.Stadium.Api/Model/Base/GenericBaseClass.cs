using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olimpia.Stadium.Api.Model.Base
{
    public class GenericBaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? Deleted { get; set; }
    }
}
