using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2clase1ejemplo.Models;
using System.Threading.Tasks;

namespace PM2clase1ejemplo.Controllers
{
    public class EmpleController
    {
        readonly SQLiteAsyncConnection _connection;
        public EmpleController(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<Models.Empleado>().Wait();
        }
        //CRUD -create -delete -update -read
        //Create

        public Task<int> StoreEmple(Models.Empleado emple)
        {
            if (emple.id != 0)
            {
                return _connection.UpdateAsync(emple);
            }
            else
            {
                return _connection.InsertAsync(emple); 
            }
        }

        public Task<List<Models.Empleado>> ListaEmpleados()
        {
            return _connection.Table<Models.Empleado>().ToListAsync();
        }
        public Task<Models.Empleado> ObtenerEmpleados(int pid)
        {
            return _connection.Table<Models.Empleado>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }
        public Task<int> DeleteEmple(Models.Empleado emple)
        {
            return _connection.DeleteAsync(emple);
        }

    } 
}
