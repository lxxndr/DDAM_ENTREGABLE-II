using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDSqlite.Models
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int idUsuario { get; set; }
        [MaxLength(10)]
        public string usuario { get; set; }
        [MaxLength(50)]
        public string documento { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(50)]
        public string celular { get; set; }
        [MaxLength(9)]
        public string contraseña { get; set; }
    } 
}
