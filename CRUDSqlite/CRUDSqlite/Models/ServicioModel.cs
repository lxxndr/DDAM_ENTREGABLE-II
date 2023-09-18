using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDSqlite.Models
{
    public class ServicioModel
    {
        [PrimaryKey, AutoIncrement]
        public int idServicios { get; set; }
        [MaxLength(100)]
        public string pais { get; set; }
        [MaxLength(100)]
        public string destino { get; set; }
        [MaxLength(100)]
        public DateTime fechaPartida { get; set; }
        [MaxLength(100)]
        public decimal precio { get; set; }
        [MaxLength(100)]
        public string detalles { get; set; }
        [MaxLength(100)]
        public DateTime horaLlegada { get; set; }
        [MaxLength(100)]
        public DateTime fechaHoraPartida { get; set; }
        [MaxLength(100)]
        public DateTime fechaHoraLlegada { get; set; }
    }
}
