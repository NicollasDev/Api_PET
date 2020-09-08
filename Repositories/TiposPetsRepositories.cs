using ApiPET.Context;
using ApiPET.Domains;
using ApiPET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPET.Repositories
{
    public class TiposPetsRepository : ITiposPets
    {

        
        VeterinariaContext conexao = new VeterinariaContext();

      
        SqlCommand cmd = new SqlCommand();



        public TiposPets Alterar(int id, TiposPets tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TiposPets SET" +
                "IdTipoPet = " + tp.IdTipoPet + ", " +
                "Descricao = @Descricao WHERE IdTipoPet = @id ";

            cmd.Parameters.AddWithValue("@IdTipoPet", tp.IdTipoPet);
            cmd.Parameters.AddWithValue("@Descricao", tp.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return tp;
        }

        public Controllers.TiposPets Alterar(int id, Controllers.Racas tp)
        {
            throw new NotImplementedException();
        }

        public Controllers.TiposPets Alterar(int id, Controllers.TiposPets tp)
        {
            throw new NotImplementedException();
        }

        public TiposPets BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Racas WHERE IdTipoPet = @id";

            
            cmd.Parameters.AddWithValue(@"id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TiposPets tp = new TiposPets();

            while (dados.Read())
            {
                tp.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                tp.Descricao = dados.GetValue(1).ToString();

            }
            conexao.Desconectar();
            return tp;
        }
        public Racas Cadastrar(Racas tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Racas (IdTipoPet, Descricao) " +
                "VALUES" +
                "(@IdTipoPet, @Descricao)";
            cmd.Parameters.AddWithValue("@IdTipoPet", tp.IdTipoPet);
            cmd.Parameters.AddWithValue("@Descricao", tp.Descricao);

            cmd.ExecuteNonQuery();

        

            conexao.Desconectar();

            return tp;
        }

        public Controllers.TiposPets Cadastrar(Controllers.TiposPets tp)
        {
            throw new NotImplementedException();
        }


        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TiposPets WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TiposPets> LerTodos()
        {
         
            cmd.Connection = conexao.Conectar();

            
            cmd.CommandText = "SELECT * FROM TiposPets";

            SqlDataReader dados = cmd.ExecuteReader();

           
            List<TiposPets> tiposPets = new List<TiposPets>();

            while (dados.Read())
            {
                tiposPets.Add(
                    new TiposPets()
                    {
                        IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),

                    }
            );
            }

            
            conexao.Desconectar();
            return tiposPets;
        }

        Controllers.TiposPets ITiposPets.BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<Controllers.TiposPets> ITiposPets.LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}