using OZ.DataModel;
using OZ.DomainModel.Categories;
using OZ.WebController.SharedBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OZ.WebController.Default
{
    public class CategoryController : FrontendControllerBase
    {
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            CategoryDomainModel cat = new CategoryDomainModel();
            IEnumerable<Category> cats = cat.GetAll();
            return PartialView(cats);
        }
    }
}
