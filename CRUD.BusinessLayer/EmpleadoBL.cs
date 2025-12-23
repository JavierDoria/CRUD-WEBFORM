using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DaraLayer;
using CRUD.EntityLayer;

namespace CRUD.BusinessLayer
{
    public class EmpleadoBL
    {
        EmpleadoDL empleadoDL = new EmpleadoDL();
        public List<Empleado> lista()
        {
            try
            {
                return empleadoDL.lista();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public Empleado obtener(int idEmpleado)
        {
            try
            {
                return empleadoDL.obtener(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool crear(Empleado entidad)
        {
            try
            {
                if(entidad.NombreCompleto=="")
                    throw new OperationCanceledException("El nombnre no puede ser vacio");
                return empleadoDL.crear(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool editar(Empleado entidad)
        {
            try
            {
                var encontrar = empleadoDL.obtener(entidad.IdEmpleado);
                if (encontrar.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe empleado");
                return empleadoDL.editar(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool eliminar(int idEmpleado)
        {
            try
            {
                var encontrar = empleadoDL.obtener(idEmpleado);
                if (encontrar.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe empleado");
                return empleadoDL.eliminar(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
