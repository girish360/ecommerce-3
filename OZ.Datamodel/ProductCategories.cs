using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DataModel
{
    public class ProductCategories :ModelBase<Guid>
    {
        public Guid ProductID { get; set; }
        public Guid CategroyID { get; set; }
    }
}
