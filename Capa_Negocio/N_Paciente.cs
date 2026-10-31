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
    // Lógica de los pacientes (el CRUD que usa el administrador). Funciona igual que la de los médicos.
    public class N_Paciente
    {
        // La capa de datos, que es la única que habla con SQL Server.
        D_Paciente datos = new D_Paciente();

        // Pacientes activos que coinciden con el texto de búsqueda (nombre, usuario o correo).
        public DataTable Listar(string filtro) { return datos.Listar(filtro); }

        // Registra un paciente nuevo: crea su cuenta de usuario y su ficha en una sola operación.
        public void Registrar(E_Paciente p)
        {
            // exigirClave = true: al crear una cuenta la contraseña es obligatoria.
            Validar.Cuenta(p.Username, p.Clave, true);
            ValidarDatos(p);

            // La contraseña nunca viaja a la BD en texto normal: se convierte en hash aquí.
            try { datos.Registrar(p, Seguridad.Sha256(p.Clave)); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }   // usuario o correo repetidos
        }

        // Modifica los datos personales. El usuario y la contraseña no se tocan aquí
        // (eso se hace desde la pantalla de Usuarios).
        public void Actualizar(E_Paciente p)
        {
            if (p.Id <= 0) throw new Exception("Seleccione un paciente.");
            ValidarDatos(p);
            try { datos.Actualizar(p); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }

        // Reglas de los datos del paciente, comunes para registrar y para editar.
        private void ValidarDatos(E_Paciente p)
        {
            Validar.Requerido(p.Nombre, "nombre", 60);
            Validar.Requerido(p.Apellido, "apellido", 60);

            // La fecha de nacimiento no puede estar en el futuro ni ser absurdamente antigua.
            if (p.FechaNacimiento.Date > DateTime.Today || p.FechaNacimiento.Year < 1900)
                throw new Exception("La fecha de nacimiento no es válida.");
            Validar.Telefono(p.Telefono);
            Validar.Correo(p.Correo);
        }

        // "Eliminar" un paciente en realidad es inhabilitar su cuenta (baja lógica):
        // sus citas pendientes se cancelan, pero su historial de citas atendidas y recetas se conserva.
        public void Eliminar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione un paciente.");
            new D_Usuario().Desactivar(id);
        }

        // Revisa si ya existe un paciente con ese nombre de usuario (sin importar mayúsculas), para avisar antes de intentar guardar.
        // Listar solo trae pacientes activos y solo pacientes, así que no ve cuentas inhabilitadas ni de médicos.
        // Si el usuario se repite en esos casos, igual lo frena la BD y Validar.Traducir muestra el mensaje.
        public bool UsuarioExiste(string username)
        {
            foreach (DataRow row in datos.Listar("").Rows)
            {
                if (row["Username"].ToString().Equals(username, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}