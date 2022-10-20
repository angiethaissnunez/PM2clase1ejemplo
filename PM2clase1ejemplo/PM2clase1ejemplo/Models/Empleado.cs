using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2clase1ejemplo.Models
{
    public class Empleado
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public String nombre { get; set; }

        [MaxLength(100)]
        public String apellido { get; set; }

        public String telefono { get; set; }

        public DateTime fechanac { get; set; }
    }
}
