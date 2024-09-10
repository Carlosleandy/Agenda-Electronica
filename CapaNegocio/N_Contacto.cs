using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos; // agregada
using CapasEntidad; // agregada
using System.Data; // agregada

namespace CapaNegocio
{
    public class N_Contacto
    {
        D_Contacto objDato = new D_Contacto();

        public DataTable N_listado() 
        {
            return objDato.D_listado();
        }

        public DataTable N_buscar(int id)
        {
            return objDato.D_buscar(id);
        }

        public void N_guardar(E_Contacto contacto)
        {
            objDato.D_guardar(contacto);
        }

        public void N_editar(E_Contacto contacto)
        {
            objDato.D_editar(contacto);
        }

        public void N_eliminar(int id)
        {
            objDato.D_eliminar(id);
        }
    }
}
