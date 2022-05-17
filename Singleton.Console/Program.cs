using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singleton;
using Singleton.Core;

namespace Singleton.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario();
            usuario.Username = "Percy";
            usuario.Password = "12345";
            try
            {
                Manejador.Login(usuario);
                Manejador u = Manejador.GetInstance;
                Manejador.Logout();
            }
            catch (Exception)
            {
            }
        }
    }
}
