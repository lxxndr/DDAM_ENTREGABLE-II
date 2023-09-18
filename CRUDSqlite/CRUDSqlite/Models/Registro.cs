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
        [MaxLength(100)]
        public string usuario { get; set; }
        [MaxLength(100)]
        public string nombre { get; set; }
        [MaxLength(100)]
        public string apellidoPaterno { get; set; }
        [MaxLength(100)]
        public string apellidoMaterno { get; set; }
        [MaxLength(100)]
        public string fechNacimiento { get; set; }
        [MaxLength(100)]
        public string documento { get; set; } // opcional???
        [MaxLength(100)]
        public int celular { get; set; }
        [MaxLength(9)]
        public string contraseña { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
    }
}
