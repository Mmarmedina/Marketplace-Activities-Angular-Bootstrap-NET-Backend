using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Domain.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ReviewText { get; set; }


        // MMM La propiedad ActividadId puede ser nula cuando la opinión sea sobre la empresa Sprencia y no sobre una actividad en particular.
        
        [ForeignKey("ActivityId")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
