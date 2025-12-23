using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.EntityLayer
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string ApellidoCompleto { get; set; }
        [Required]
        public Departamento Departamento { get; set; }
        [Required]
        public decimal sueldo { get; set; }
        [Required]
        public string FechaContrato { get; set; }
    }
}
