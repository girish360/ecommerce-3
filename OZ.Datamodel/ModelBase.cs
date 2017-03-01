using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DataModel
{
    public abstract class ModelBase<T>
    {
        public virtual T ID { get; set; }
        public virtual Byte Status { get; set; }
        public virtual DateTime CreateDatetime { get; set; }
        public virtual DateTime UpdateDatetime { get; set; }
    }
}
