using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23DH114365_MyStore.Models;
using _23DH114365_MyStore.Models.ViewModel;
using PagedList;

namespace _23DH114365_MyStore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        //get admin/products
        public ActionResult Index(string searchterm, int? page)
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Tìm kiếm sản phẩm dựa trên từ khóa
            if (!string.IsNullOrEmpty(searchterm))
            {
                model.SearchTerm = searchterm;
                products = products.Where(p => p.ProductName.Contains(searchterm) ||
                                    p.ProductDecription.Contains(searchterm) ||
                                    p.Category.CategoryName.Contains(searchterm));
            }

            //đoạn code liên quan đến phần trang
            //lấy số trang hiện tại (mặc định là 1 nếu như ko có giá trị)
            int pageNumber = page ?? 1;
            int pageSize = 6; // số SP mỗi trang

            // lấy top 10 SP bán chạy nhất nhất
            model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
            // lấy 20 sản phẩm bán ế nhát và phần trang
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);

            return View(model);
        }
    }
}