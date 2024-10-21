using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23DH114365_MyStore.Models.ViewModel
{
    public class ProductSearchMV
    {
        //theo tên, mô tả, loại sản phẩm
        public string SearchTerm {  get; set; }
        //theo giá
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        //thứ tự sắp xếp
        public string SortOrder { get; set; }
        //thuộc tính hỗ trợ phân trang
        public int PageNumber { get; set; } //trang hiện tại
        public int PageSize { get; set; } = 10; // Số sản phẩm mỗi trang
        //Danh sách sản phẩm đã phân trang
        public PagedList.IPagedList<Product> Products { get; set; }
        //danh sách thỏa đl tìm kiếm
        //public List<Product> Products { get; set; }
        
    }
}