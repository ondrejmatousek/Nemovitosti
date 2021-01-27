using Dapper;
using Nemovitosti.DataAccessLayer.Interface.Ciselniky;
using Nemovitosti.DomainModel.Model.Ciselniky;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Nemovitosti.DataAccessLayer.Implementation.Ciselniky
{
    public class CiselnikProdejNeboPronajemDao : ICiselnikProdejNeboPronajemDao
    {
        private ConnectionStringSettings _connString;

        public CiselnikProdejNeboPronajemDao(ConnectionStringSettings connString)
        {
            _connString = connString ?? throw new ArgumentNullException(nameof(connString)); ;
        }

        public List<CiselnikProdejNeboPronajem> GetAll()
        {
            string query = @"SELECT * FROM Nemovitosti.dbo.CiselnikProdejNeboPronajem";
            using (DbConnection conn = new SqlConnection(_connString.ConnectionString))
            {
                return conn.Query<CiselnikProdejNeboPronajem>(query).ToList();
            }
        }
    }
}
