using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.DAL
{
    class DispatcherUsuario : DispatcherBase
    {
        private const string SP_INCLUIR_USUARIO = "SP_IncUsuario";

        private const string SP_CONSULTAR_USUARIO = "SP_SelUsuario";

        public void Incluir(string pNome, string pEmail, string pSenha)
        {
            DataTable tableRetorno = ExecutarProcedure(SP_INCLUIR_USUARIO, new object[] { pNome, pEmail, pSenha, 0 });
        }

        public Usuario Consultar(string pNomeEmail)
        {
            Usuario usuario = new Usuario();
            DataTable tableRetorno = ExecutarProcedure(SP_CONSULTAR_USUARIO, new object[] { pNomeEmail });

            if (tableRetorno.Rows.Count > 0)
            {
                DataRow retorno = tableRetorno.Rows[0];

                if (retorno["UsuarioID"] != DBNull.Value)
                    usuario.Codigo = int.TryParse(retorno["UsuarioID"].ToString(), out int res) ? res : 0;
                if (retorno["LoginName"] != DBNull.Value)
                    usuario.Login = retorno["LoginName"].ToString();
                if (retorno["Email"] != DBNull.Value)
                    usuario.Email = retorno["Email"].ToString();
                if (retorno["Senha"] != DBNull.Value)
                    usuario.Senha = retorno["Senha"].ToString();
            }

            return usuario;
        }
    }
}
