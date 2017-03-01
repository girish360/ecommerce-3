using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DataModel
{
    public class Order : ModelBase<Guid>
    {
        [Required(ErrorMessage="Please enter Family Name")]
        [StringLength(10,MinimumLength =2)]
        public string FamilyName { get; set; }
        [Required(ErrorMessage = "Please enter Given Name")]
        public string GivenName { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email{ get; set; }
        [ForeignKey("OrderID")]
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem : ModelBase<Guid>
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Guid OrderID { get; set; }
    }
}
