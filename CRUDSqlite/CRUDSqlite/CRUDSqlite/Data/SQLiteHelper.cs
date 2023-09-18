using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CRUDSqlite.Models;
using System.Threading.Tasks;

namespace CRUDSqlite.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection _connection;
        public SQLiteHelper(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Registro>().Wait();
        }
        // ya lo dijiste mas de dos veces 👆
        // voy a cenar mientras veo como va la vaina del login...
        public Task<int> SaveUsuarioAsync(Registro registro)
        {
            if (registro.idUsuario == 0)
            {
                return _connection.InsertAsync(registro);
            }
            else
            {
                return null;
            }

        }
        // toy viendo como hacer el login >:v
        /// <summary>
        /// Recuperar  alumno por id
        /// </summary>
        /// <param > id del registro </param>
        /// <returns></returns>
        /// 

        public Task<List<Registro>> GetRegistros()
        {
            return _connection.Table<Registro>().ToListAsync();
        }

        // toy viendo como hacer el login >:v
        /// <summary>
        /// Recuperar  alumno por id
        /// </summary>
        /// <param > id del registro </param>
        /// <returns></returns>
        /// 

        // create o insert
        public Task<List<Registro>> GetRegistrosAsync() 
        {
            return _connection.Table<Registro>().ToListAsync();
        }

        // GET
        public Task<Registro> GetRegistroByIdAsync(int idUsuario) 
        {
            return _connection.Table<Registro>().Where(a => a.idUsuario == idUsuario).FirstOrDefaultAsync();
        }

        // busca el usuario
        public Task<Registro> GetUsuarioByNombreUsuarioAsync(string Usuario)
        {
            return _connection.Table<Registro>().Where(u => u.usuario == Usuario).FirstOrDefaultAsync();
        }

    }
}
