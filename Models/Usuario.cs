using System.Collections.Generic;
using System.Linq;
namespace UsandoViews.Models
{
    public class Usuario
    {
        public int IdUsuario {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}

        private static List<Usuario> _listagem = new List<Usuario>();
        public static IQueryable<Usuario> Listagem
        {
            get
            {
                return _listagem.AsQueryable();
            }
        }

        static Usuario()
        {
            Usuario._listagem.Add(new Usuario{IdUsuario = 1, Nome = "Fulano" , Email = "Fulano@gmail.com"} );
            Usuario._listagem.Add(new Usuario{IdUsuario = 2, Nome = "Ciclano" , Email = "Ciclano@gmail.com"} );
            Usuario._listagem.Add(new Usuario{IdUsuario = 3, Nome = "Beltrano" , Email = "Beltrano@gmail.com"} );
            Usuario._listagem.Add(new Usuario{IdUsuario = 4, Nome = "Jose" , Email = "Jose@gmail.com"} );
            Usuario._listagem.Add(new Usuario{IdUsuario = 5, Nome = "Maria" , Email = "Maria@gmail.com"} );
        }

        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = Usuario._listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome= usuario.Nome;
                usuarioExistente.Email= usuario.Email;
            }
            else
            {
                int NovoID = 0;
                if (Usuario.Listagem.AsQueryable().Count()>0)
                {
                    NovoID = Usuario.Listagem.Max(u => u.IdUsuario);
                }
                 
                //if (Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = NovoID + 1;
                Usuario._listagem.Add(usuario);
            }
        }
        public static bool Excluir(int idUsuario)
        {
            var usuarioExistente = Usuario._listagem.Find(u => u.IdUsuario == idUsuario);
            if (usuarioExistente != null)
            {
                return Usuario._listagem.Remove(usuarioExistente);
            }
            return false;
        }



    }
}