using OZ.DataModel;
using OZ.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DomainModel
{
    public class OrderDomainModel
    {
        public void SaveOrder(Order o)
        {
            SqlRepository<Order> rep = new SqlRepository<Order>(new SqlServerDefaultContext());

            rep.Insert(o);

        }
    }
}
