using Booteq.Infrastructure.Common;
using BooteqPointOfSale.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BooteqPointOfSale.Data.Repository
{
    public class GenericRespoistory<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, new()
    {
        private readonly string ConnectionString = "Data Source=.;Initial Catalog=Booteq;User ID=sa;Password=7867";
        private SqlConnection SqlCon;

        public List<TEntity> Get()
        {
            List<TEntity> list;
            using (SqlCon = new SqlConnection(ConnectionString))
            {
                list = new List<TEntity>();
                SqlCommand cm = new SqlCommand("Select * from Worker", SqlCon); // we can make generic table name instead hardcoded
                SqlCon.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    var obj = new TEntity();
                    sdr.MapDataToObject(obj);
                    list.Add(obj);
                }
                return list;
            }
        }

    }
}
