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
        public string namePaqute { get; set; }
        [MaxLength(100)]
        public string unoPaqute { get; set; }
        [MaxLength(100)]
        public string dosPaqute { get; set; }
        [MaxLength(100)]
        public string tresPaqute { get; set; }
        [MaxLength(100)]
        public string fechaVenPaqute { get; set; }
        [MaxLength(100)]
        public string descripcionPaqute { get; set; }
        [MaxLength(100)]
        public string precioPaqute { get; set; }
    }
}
