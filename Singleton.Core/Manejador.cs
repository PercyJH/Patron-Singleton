using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Core
{
    public class Manejador
    {
        private static object _lock = new Object();
        //4 guardamos desde una variable estatica la sesión a administrar
        private static Manejador _session;
        public Usuario Usuario { get; set; } //1 no se puede instanciar deliveradamente
        public DateTime FechaInicio { get; set; }

        //5 operacion estatica que nos permite acceder a esta instancia global
        public static Manejador GetInstance
        {
            get //6 acceso a la instancia
            {
                if (_session == null) throw new Exception("Sesión no iniciada");
                //7 si sesion es nulo crea una nueva sesion si no, nos devuelve la sesion actual
                return _session;
            }
        }
        //8 como este es un manejador de sesion definimos algunas funciones
        public static void Login(Usuario usuario)
        {//9 nos asegura la creacion de una instancia y mantenerla
            lock (_lock)
            {
                //control del objeto sesion
                if (_session == null)
                {
                    _session = new Manejador();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                }// al entrar una nueva sesion siempre va a preguntar si hay
                 // una anterior lo cual puede ser un problema
                else
                {
                    throw new Exception("Sesion iniciada");
                }
            }
        } //10 aqui se encapsula el acceso a la instancia de manera global
        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada ");
                }
            }
        }
        private Manejador() //2 constructor privado
                            //3 se garantiza que la clase manejador no se puede hacer "new" desde cualquier lugar
        {
        }
    }
}
