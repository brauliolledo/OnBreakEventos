using Persistencia.OnBreakDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;



namespace Persistencia.lib.dao
{
    public class LoginDAO
    {
        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }


        public bool ValidarUsuario(string usuario, string contrasenia)
        {
            // Encriptamos el input y lo comparamos con el hash en la base de datos

            QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter();

            string hashContrasenia = GetSHA1(contrasenia);

            if (queriesTableAdapter.ValidarUsuario(usuario, hashContrasenia) != null)
            {
                return true;
            }
            else
            {
                return false;

            }

        }
    }


}
