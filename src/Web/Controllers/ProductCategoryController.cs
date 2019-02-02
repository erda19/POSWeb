using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSWeb.Web.Constant;
using POSWeb.Web.Helper;

namespace Web.Controllers
{
    public class ProductCategoryController : Controller
    {

        BreadCumb br = new BreadCumb();
        string headerText = "Kategori Produk";
        public IActionResult Index()
        {
            br.AddBreadCumb(new BreadCumbModel
            {
                DiplayText = "Index",
                Url = "#",
                isActive = true

            });
            ViewBag.HeaderText = headerText;
            ViewBag.Breadcumb = br.GetBreadCumb();
            return View();
        }

        public IActionResult Create()
        {
            br.AddBreadCumb(new BreadCumbModel
            {
                DiplayText = "Index",
                Url = "#",
                isActive = false

            });
            br.AddBreadCumb(new BreadCumbModel
            {
                DiplayText = "Create",
                Url = "#",
                isActive = true

            });
            ViewBag.HeaderText = headerText;
            ViewBag.Breadcumb = br.GetBreadCumb();
            ViewBag.ActionForm = ActionForm.Insert;
            return View("Form");
        }
    }
}