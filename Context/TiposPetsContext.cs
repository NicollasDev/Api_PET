﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPET.Context
{
    public class TiposPetsContext
    {
        SqlConnection con = new SqlConnection();
        public TiposPetsContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-DC44E8T\SQLEXPRESS;Initial Catalog=TiposPets;Persist Security Info=True;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
