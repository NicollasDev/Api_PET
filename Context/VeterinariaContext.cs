using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPET.Context
{
    public class VeterinariaContext
    {
        SqlConnection con = new SqlConnection();
        // aqui chamamos o objeto em forma de metodo e conectamos o  sql server
        public VeterinariaContext()
        {
            con.ConnectionString = "Data Source = DESKTOP - DC44E8T/SQLEXPRESS; Initial Catalog = Veterinaria; Integrated Security = True";
        }

        // Aqui nós fazemos a verificação, caso o sistema esteja fechado ele abrirá
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        // Aqui fazemos o oposto acima, verificamos se a coenxao esá aberta, caso esteja, nós o fecharemos
        public SqlConnection Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
    }
}
