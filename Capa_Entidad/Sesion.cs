using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    // Aquí guardamos "quién inició sesión". Es una clase estática, o sea que hay una sola copia para todo el programa:
    // cualquier formulario o capa puede preguntar Sesion.IdUsuario o Sesion.Rol sin que nadie tenga que pasársela de mano en mano.
    public static class Sesion
    {
        // IDs de los roles. Son los mismos números de la tabla Rol en la BD, así que si algún día cambian, hay que cambiarlos en los dos lados.
        // Usar nombres (Sesion.Medico) en vez de números sueltos (2) hace que el código se entienda mucho mejor.
        public const int Paciente = 1, Medico = 2, Administrador = 3;

        // Datos de la persona logueada. El "private set" hace que solo esta clase pueda modificarlos:
        // desde fuera se pueden leer, pero únicamente se cambian con Iniciar y Limpiar.
        // Así evitamos que algún formulario los altere por accidente.

        // ID de la cuenta. Como el ID del paciente y del médico es el mismo que el de su usuario,
        // este número también sirve para filtrar "mis citas", "mis horarios", etc.
        public static int IdUsuario { get; private set; }

        // Nombre de usuario (el que escribió en el login).
        public static string Username { get; private set; }

        // Rol en número (1, 2 o 3). Es el que usamos para decidir a qué menú entra.
        public static int IdRol { get; private set; }

        // Nombre del rol en texto, para mostrarlo en pantalla.
        public static string Rol { get; private set; }

        // Nombre y apellido de la persona (es el que sale arriba a la derecha).
        public static string NombreCompleto { get; private set; }

        // Cierra la sesión: deja todo vacío para que no queden datos de la persona anterior.
        public static void Limpiar()
        {
            IdUsuario = 0; IdRol = 0;
            Username = Rol = NombreCompleto = null;
        }

        // Abre la sesión con los datos que devolvió el login cuando el usuario y la contraseña fueron correctos.
        public static void Iniciar(int id, string user, int idRol, string rol, string nombre)
        {
            IdUsuario = id;
            Username = user;
            IdRol = idRol;
            Rol = rol;
            NombreCompleto = nombre;
        }
    }
}
