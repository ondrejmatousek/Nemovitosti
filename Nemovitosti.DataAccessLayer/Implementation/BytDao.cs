using Dapper;
using Microsoft.Extensions.Configuration;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Nemovitosti.DataAccessLayer.Implementation
{
    public class BytDao : IBytDao
    {
        private readonly IConfiguration Configuration;
        public BytDao(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void Insert(Byt byt)
        {
            string query = @"INSERT INTO Nemovitosti.dbo.Byt (NazevInzeratu, Cena, VelikostBytu)
                             VALUES (@NazevInzeratu, @Cena, @VelikostBytu)
                             SELECT IdByt FROM Nemovitosti.dbo.Byt WHERE Byt.IdByt = Scope_Identity()";

            using (DbConnection dbConnection = new SqlConnection(Configuration.GetConnectionString("ConnectionString")))
            {
                Byt bytZdb = dbConnection.Query<Byt>(query, new { byt.IdByt, byt.NazevInzeratu, byt.Cena, byt.VelikostBytu }).SingleOrDefault();
                byt.IdByt = bytZdb.IdByt;
            }

        }
    }
}
