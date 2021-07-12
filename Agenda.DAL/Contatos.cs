using Npgsql;
using System;
using Agenda.Domain;
using System.Collections.Generic;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        NpgsqlConnection _conn;

        public Contatos()
        {
            _strCon = "Host=localhost;Port=5450;Database=pgsqltests;Username=pguser;Password=pgpassword;";
            _conn = new NpgsqlConnection(_strCon);
        }

        public void Adicionar(Contato contato)
        {
            _conn.Open();

            var sql = String.Format("INSERT INTO public.contato (id, nome) VALUES('{0}', '{1}');", contato.Id, contato.Nome);

            var cmd = new NpgsqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public Contato Obter(Guid id)
        {
            _conn.Open();

            var sql = String.Format("SELECT * FROM public.contato WHERE id = '{0}';", id);

            var cmd = new NpgsqlCommand(sql, _conn);

            var dataReader = cmd.ExecuteReader();
            dataReader.Read();

            var contato = new Contato()
            {
                Id = Guid.Parse(dataReader["id"].ToString()),
                Nome = dataReader["nome"].ToString()
            };

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            _conn.Open();

            var sql = "SELECT * FROM public.contato;";

            var cmd = new NpgsqlCommand(sql, _conn);

            var dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                contatos.Add(
                    new Contato()
                    {
                        Id = Guid.Parse(dataReader["id"].ToString()),
                        Nome = dataReader["nome"].ToString()
                    }
                );
            }

            return contatos;
        }
    }
}
