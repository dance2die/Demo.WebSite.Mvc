using System.Data.SqlClient;

namespace Demo.WebSite.Mvc.Routing.Dal
{
	public abstract class BaseRepository
	{
		protected const string CONNECTION_STRING = @"Server=GODDESS\SQL2014;Initial Catalog=Test;Integrated Security=SSPI";

		protected SqlConnection GetOpenConnection()
		{
			SqlConnection result = new SqlConnection(CONNECTION_STRING);
			result.Open();

			return result;
		}
	}
}