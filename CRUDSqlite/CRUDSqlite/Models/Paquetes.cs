using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDSqlite.Models
{
    public class Paquetes
    {
        [PrimaryKey, AutoIncrement]
        public int idPaquetes { get; set; }
        [MaxLength(100)]
        public string destino { get; set; }
        [MaxLength(100)]
        public string local { get; set; }
        [MaxLength(20)]
        public string pais { get; set; }
        [MaxLength(100)]
        public string precio { get; set; }
        [MaxLength(100)]
        public string dias { get; set; }
        
    }
}
