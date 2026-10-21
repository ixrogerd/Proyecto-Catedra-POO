using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class N_Paciente
    {
        D_Paciente datos = new D_Paciente();

        public DataTable Listar(string filtro) { return datos.Listar(filtro); }

        public void Registrar(E_Paciente p)
        {
            Validar.Cuenta(p.Username, p.Clave, true);
            ValidarDatos(p);
            try { datos.Registrar(p, Seguridad.Sha256(p.Clave)); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        public void Actualizar(E_Paciente p)
        {
            if (p.Id <= 0) throw new Exception("Seleccione un paciente.");
            ValidarDatos(p);
            try { datos.Actualizar(p); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        private void ValidarDatos(E_Paciente p)
        {
            Validar.Requerido(p.Nombre, "nombre", 60);
            Validar.Requerido(p.Apellido, "apellido", 60);
            if (p.FechaNacimiento.Date > DateTime.Today || p.FechaNacimiento.Year < 1900)
                throw new Exception("La fecha de nacimiento no es válida.");
            Validar.Telefono(p.Telefono);
            Validar.Correo(p.Correo);
        }
        public void Eliminar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione un paciente.");
            new D_Usuario().Desactivar(id);
        }
    }
}
