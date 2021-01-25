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
    public class CiselnikTypPozemkuDao : ICiselnikTypPozemkuDao
    {
        private ConnectionStringSettings _connString;

        public CiselnikTypPozemkuDao(ConnectionStringSettings connString)
        {
            _connString = connString ?? throw new ArgumentNullException(nameof(connString));
        }
        public List<CiselnikTypPozemku> GetAll()
        {
            string query = @"SELECT * FROM Nemovitosti.dbo.CiselnikTypPozemku";
            using (DbConnection conn = new SqlConnection(_connString.ConnectionString))
            {
                return conn.Query<CiselnikTypPozemku>(query).ToList();
            }
        }
    }
}
