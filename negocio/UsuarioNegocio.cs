﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
	public class UsuarioNegocio
	{
		public bool Loguear(Usuario user)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearQuery("SELECT id, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
				datos.setearParametro("@email", user.Email);
				datos.setearParametro("@pass", user.Pass);

				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					user.Id = (int)datos.Lector["id"];
					user.Admin = (bool)datos.Lector["admin"];
					user.UrlImagenPerfil = datos.Lector["urlImagenPerfil"].ToString();
					user.Nombre = datos.Lector["nombre"].ToString();
					user.Apellido = datos.Lector["apellido"].ToString();
                    return true;
				}
				return false;

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
            }
		}
	}
}
