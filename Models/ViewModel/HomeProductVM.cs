using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;

namespace _23DH114365_MyStore.Models.ViewModel
{
    public class HomeProductVM
    {
        //tiêu chí để search theo tên, mô tả SP hoặc loại sản phẩm
        public string SearchTerm { get; set; }

        //các thuộc tính hỗ trợ phân trang
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

        // danh sách sản phẩm nổi bặt
        public List<Product> FeaturedProducts { get; set; }

        // danh sách sản phẩm mới đã phân trang
        public PagedList.IPagedList<Product> NewProducts { get; set; }
    }
}