using PersonalPlannerLib.DAL;
using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.BLL
{
    public class BoUsuario
    {
        public void Incluir(string pNome, string pEmail, string pSenha)
        {
            DispatcherUsuario dsp = new DispatcherUsuario();

            dsp.Incluir(pNome, pEmail, ConverterSenha(pSenha));
        }

        public Usuario Consultar(string pNomeEmail)
        {
            DispatcherUsuario dsp = new DispatcherUsuario();
            Usuario usuario = dsp.Consultar(pNomeEmail);
            return usuario;
        }

        public bool ExisteUsuario(string pNomeEmail)
        {
            Usuario usuario = Consultar(pNomeEmail);

            if (usuario != null && !string.IsNullOrEmpty(usuario.Login))
                return true;

            return false;
        }

        public bool IsUsuarioValido(string pNomeEmail, string pSenha)
        {
            Usuario usuario = Consultar(pNomeEmail);

            if (usuario == null || string.IsNullOrEmpty(usuario.Login) || ConverterSenha(pSenha) != usuario.Senha)
                return false;

            return true;
        }

        private string ConverterSenha(string pSenha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pSenha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
