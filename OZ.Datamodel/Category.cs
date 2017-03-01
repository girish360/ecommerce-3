using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DataModel
{
    public class Category : ModelBase<Guid>
    {
        public String Name { get; set; }
        public String DetailName { get; set; }

        public Guid? ParentID { get; set; }
    }
}
