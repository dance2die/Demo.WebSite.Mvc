using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Demo.WebSite.Mvc.Routing.Models;

namespace Demo.WebSite.Mvc.Routing.Dal
{
	public class CertifiedRepository
	{
		private const string CONNECTION_STRING = @"Server=GODDESS\SQL2014;Initial Catalog=Test;Integrated Security=SSPI";

		public IEnumerable<CertifiedItem> GetCertifiedItems()
		{
			using (var connection = GetOpenConnection())
			{
				const string spName = "spGetCertifiedItems";
				return connection.Query<CertifiedItem>(spName, commandType: CommandType.StoredProcedure);
			}
		}

		private SqlConnection GetOpenConnection()
		{
			SqlConnection result = new SqlConnection(CONNECTION_STRING);
			result.Open();

			return result;
		}
	}
}