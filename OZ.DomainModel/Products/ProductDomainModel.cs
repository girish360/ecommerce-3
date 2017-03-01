using OZ.DataModel;
using OZ.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DomainModel.Products
{
    public class ProductDomainModel
    {
        public IEnumerable<Product> GetAll()
        {
            SqlRepository<Product> rep = new SqlRepository<Product>( new SqlServerDefaultContext());
            return rep.GetAll();
        }
        public Product GetBySku(string sku)
        {
            SqlRepository<Product> rep = new SqlRepository<Product>(new SqlServerDefaultContext());
            IEnumerable<Product> prods = rep.GetByProperty(x => x.Sku == sku);
            return prods.Count()>0? prods.First():null;
        }
        public Product GetById(string id)
        {
            SqlRepository<Product> rep = new SqlRepository<Product>(new SqlServerDefaultContext());
            IEnumerable<Product> prods = rep.GetByProperty(x => x.ID == new Guid( id));
            return prods.Count() > 0 ? prods.First() : null;
        }
        public IEnumerable<Product> GetByCategory(string name)
        {
            SqlServerDefaultContext ctx = new SqlServerDefaultContext();
            IEnumerable<Product> prods = from p in ctx.Products
                                         join pc in ctx.ProductCategories on p.ID equals pc.ProductID
                                         join c in ctx.Categorys on pc.CategroyID equals c.ID
                                         where c.Name == name
                                         select p;

            return prods;
        }
    }
}
