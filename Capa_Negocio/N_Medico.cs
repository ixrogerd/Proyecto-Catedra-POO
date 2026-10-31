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
    // Lógica de los médicos (el CRUD que usa el administrador).
    public class N_Medico
    {
        // La capa de datos, que es la única que habla con SQL Server.
        D_Medico datos = new D_Medico();

        // Médicos activos que coinciden con el texto de búsqueda (nombre, usuario, correo o especialidad).
        public DataTable Listar(string filtro) { return datos.Listar(filtro); }

        // Médicos activos de una especialidad. Se usa para llenar el combo de médicos al agendar una cita.
        public DataTable PorEspecialidad(int idEspecialidad) { return datos.PorEspecialidad(idEspecialidad); }

        // Registra un médico nuevo: crea su cuenta de usuario y su ficha en una sola operación.
        public void Registrar(E_Medico m)
        {
            // exigirClave = true: al crear una cuenta la contraseña es obligatoria.
            Validar.Cuenta(m.Username, m.Clave, true);
            ValidarDatos(m);

            // La contraseña nunca viaja a la BD en texto normal: se convierte en hash aquí.
            try { datos.Registrar(m, Seguridad.Sha256(m.Clave)); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }   // usuario o correo repetidos
        }

        // Modifica los datos personales y la especialidad. El usuario y la contraseña no se tocan aquí
        // (eso se hace desde la pantalla de Usuarios).
        public void Actualizar(E_Medico m)
        {
            if (m.Id <= 0) throw new Exception("Seleccione un médico.");
            ValidarDatos(m);
            try { datos.Actualizar(m); }
            catch (SqlException ex) { throw Validar.Traducir(ex); }
        }


        // Reglas de los datos del médico, comunes para registrar y para editar.
        private void ValidarDatos(E_Medico m)
        {
            Validar.Requerido(m.Nombre, "nombre", 60);
            Validar.Requerido(m.Apellido, "apellido", 60);
            if (m.IdEspecialidad <= 0) throw new Exception("Seleccione una especialidad.");
            Validar.Telefono(m.Telefono);
            Validar.Correo(m.Correo);
        }

        // "Eliminar" un médico en realidad es inhabilitar su cuenta (baja lógica):
        // sus citas pendientes se cancelan, pero el historial de citas atendidas y recetas se conserva.
        public void Eliminar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione un médico.");
            new D_Usuario().Desactivar(id);
        }

        // Revisa si ya existe un médico con ese nombre de usuario (sin importar mayúsculas), para avisar antes de intentar guardar.
        // Listar solo trae médicos activos y solo médicos, así que no ve cuentas inhabilitadas ni de pacientes.
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
