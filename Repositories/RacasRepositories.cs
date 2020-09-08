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
    public class RacasRepository : IRacas
    {

        // a classe de conexao do banco
        VeterinariaContext conexao = new VeterinariaContext();

        // objeto que poderá receber e executar os comandos do banco 
        SqlCommand cmd = new SqlCommand();



        public Racas Alterar(int id, Racas r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Racas SET" +
                "IdRaca = " + r.IdRaca + ", " +
                "Descricao = @Descricao, " +
                "IdTipoPet = @IdTipoPet WHERE IdRaca = @id ";
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@IdTipoPet", r.IdTipoPet);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return r;
        }

        public Controllers.Racas Alterar(int id, Controllers.Racas r)
        {
            throw new NotImplementedException();
        }

        public Racas BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Racas WHERE IdRaca = @id";

            //  variáveis que vem como argumento
            cmd.Parameters.AddWithValue(@"id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Racas r = new Racas();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoPet = Convert.ToInt32(dados.GetValue(2));
                

            }
            conexao.Desconectar();
            return r;
        }
        public Racas Cadastrar(Racas r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Racas (IdRaca, Descricao, IdTipoPet) " +
                "VALUES" +
                "(@IdRaca, @Descricao, @IdTipoPet)";
            cmd.Parameters.AddWithValue("@IdRaca", r.IdRaca);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@IdTipoPet", r.IdTipoPet);

            
            cmd.ExecuteNonQuery();

            // DML -> ExecuteNonQuery

            conexao.Desconectar();

            return r;
        }

        public Controllers.Racas Cadastrar(Controllers.Racas r)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Racas WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Racas> LerTodos()
        {
            //conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query 
            cmd.CommandText = "SELECT * FROM Racas";

            SqlDataReader dados = cmd.ExecuteReader();

            // lista pra guardar os pets
            List<Racas> racas = new List<Racas>();

            while (dados.Read())
            {
                racas.Add(
                    new Racas()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoPet = Convert.ToInt32(dados.GetValue(2)),

                    }
            ); 
            }

            // Fechando conexao
            conexao.Desconectar();
            return racas;
        }

        Controllers.Racas IRacas.BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<Controllers.Racas> IRacas.LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}