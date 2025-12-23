using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUD.DaraLayer;
using CRUD.EntityLayer;

namespace CRUD.BusinessLayer
{
    public class DepartamentoBL
    {
        DepartamentoDL departamentoDL = new DepartamentoDL();
        public List<Departamento> Lista()
        {
            try
            {
                return departamentoDL.lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
