using OZ.DataModel;
using OZ.DomainModel.Products;
using OZ.ViewModel;
using OZ.WebController.SharedBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OZ.WebController.Default
{
    public class ProductController : FrontendControllerBase
    {
        public int PageSize = 6;
        public ViewResult Index(int page =1)
        {
            ProductDomainModel domainProduct = new ProductDomainModel();
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = domainProduct.GetAll()
                .OrderBy(x => x.Sku)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = domainProduct.GetAll().Count()
                }
            };
            return View(model);
        }
        public ViewResult Show(string id)
        {
            ProductDomainModel p = new ProductDomainModel();            
            return View(p.GetBySku(id));
        }
        public ViewResult ShowByCategory(string category,int page=1)
        {
            ProductDomainModel p = new ProductDomainModel();
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = p.GetByCategory(category)
                .OrderBy(x => x.Sku)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = p.GetByCategory(category).Count()
                }
            };
            return View(model);
        }

    }
}
