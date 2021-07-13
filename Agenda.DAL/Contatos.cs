using Npgsql;
using System;
using Agenda.Domain;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;

        public Contatos()
        {
            //_strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            _strCon = "Host=localhost;Port=5450;Database=pgsqltests;Username=pguser;Password=pgpassword;";
        }

        public void Adicionar(Contato contato)
        {
            using (var conn = new NpgsqlConnection(_strCon))
            {
                conn.Execute("INSERT into public.contato (id, nome) values (@Id, @Nome)", contato);
                //conn.Open();

                //var sql = String.Format("SELECT * FROM public.contato WHERE id = '{0}';", contato.Id, contato.Nome);

                //var cmd = new NpgsqlCommand(sql, conn);
                //cmd.ExecuteNonQuery();
            }

        }

        public Contato Obter(Guid id)
        {
            Contato contato;

            using (var conn = new NpgsqlConnection(_strCon)) {
                contato = conn.QueryFirst<Contato>("SELECT * FROM public.contato WHERE id = @Id", new { Id = id });
                //conn.Open();

                //var sql = String.Format("SELECT * FROM public.contato WHERE id = '{0}';", id);

                //var cmd = new NpgsqlCommand(sql, conn);

                //var dataReader = cmd.ExecuteReader();
                //dataReader.Read();

                //contato = new Contato()
                //{
                //    Id = Guid.Parse(dataReader["id"].ToString()),
                //    Nome = dataReader["nome"].ToString()
                //};
            }

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            using (var conn = new NpgsqlConnection(_strCon))
            {
                contatos = conn.Query<Contato>("SELECT * FROM public.contato").ToList();
                //conn.Open();

                //var sql = "SELECT * FROM public.contato;";

                //var cmd = new NpgsqlCommand(sql, conn);

                //var dataReader = cmd.ExecuteReader();

                //while (dataReader.Read())
                //{
                //    contatos.Add(
                //        new Contato()
                //        {
                //            Id = Guid.Parse(dataReader["id"].ToString()),
                //            Nome = dataReader["nome"].ToString()
                //        }
                //    );
                //}
            }

            return contatos;
        }
    }
}
