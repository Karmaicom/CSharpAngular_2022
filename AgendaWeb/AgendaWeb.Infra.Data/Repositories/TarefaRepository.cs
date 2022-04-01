using AgendaWeb.Infra.Data.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWeb.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {

        private string _connectionString;

        public TarefaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Tarefa obj)
        {
            var query = @"insert into tarefa(id, nome, data, hora, descricao, prioridade)
                            values (@id, @nome, @data, @hora, @descricao, @prioridade)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Delete(Tarefa obj)
        {
            var query = @"delete from tarefa where id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Tarefa> FindAll()
        {
            var query = @"select * from tarefa order by data";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Tarefa>(query).ToList();
            }
        }

        public List<Tarefa> FindByDate(DateTime dataMin, DateTime dataMax)
        {
            var query = @"select * from tarefa where data between @dataMin and @dataMax order by data";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Tarefa>(query, new { dataMin, dataMax }).ToList();
            }
        }

        public Tarefa? FindById(Guid id)
        {
            var query = @"select * from tarefa where id=@id order by data";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Tarefa>(query, new { id }).FirstOrDefault();
            }
        }

        public void Update(Tarefa obj)
        {
            var query = @"update tarefa set nome=@nome, data=@data, hora=@hora, 
                                            descricao=@descricao, prioridade=@prioridade
                          where id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, obj);
            }
        }
    }
}
