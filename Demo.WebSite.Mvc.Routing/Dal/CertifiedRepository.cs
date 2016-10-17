using System.Collections.Generic;
using System.Data;
using Dapper;
using Demo.WebSite.Mvc.Routing.Models;

namespace Demo.WebSite.Mvc.Routing.Dal
{
	public class CertifiedRepository : BaseRepository
	{
		public IEnumerable<CertifiedBatch> GetCertifiedBatches()
		{
			using (var connection = GetOpenConnection())
			{
				const string spName = "spGetCertifiedBatches";
				return connection.Query<CertifiedBatch>(spName, commandType: CommandType.StoredProcedure);
			}
		}

		public IEnumerable<CertifiedItem> GetCertifiedItems()
		{
			using (var connection = GetOpenConnection())
			{
				const string spName = "spGetCertifiedItems";
				return connection.Query<CertifiedItem>(spName, commandType: CommandType.StoredProcedure);
			}
		}
	}
}