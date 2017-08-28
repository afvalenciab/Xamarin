using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoForms.Classes
{
    class Tarea
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }

        [MaxLength(150), NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }

        [NotNull]
        public TimeSpan Hora { get; set; }

        public bool Completada { get; set; }
    }
}
