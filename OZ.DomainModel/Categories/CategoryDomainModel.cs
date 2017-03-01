using OZ.DataModel;
using OZ.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DomainModel.Categories
{
    public class CategoryDomainModel
    {
        public IEnumerable<Category> GetAll()
        {
            SqlRepository<Category> rep = new SqlRepository<Category>(new SqlServerDefaultContext());
            return rep.GetAll();
        }
        public Category GetBySku(string name)
        {
            SqlRepository<Category> rep = new SqlRepository<Category>(new SqlServerDefaultContext());
            IEnumerable<Category> prods = rep.GetByProperty(x => x.Name == name);
            return prods.First();
        }
    }
}
