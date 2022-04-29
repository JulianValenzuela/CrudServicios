using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudServicios.Models
{
    public class Servicio
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(100, ErrorMessage ="El {0} debe ser almenos {2} y maximo {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(2000, ErrorMessage = "El {0} debe ser almenos {2} y maximo {1} caracteres")]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        
        public int Precio { get; set; }

        [Required(ErrorMessage = "El tiempo es obligatorio")]
        [Display(Name = "Tiempo de duracion ")]
        public string Tiempo { get; set; }
    }
}
