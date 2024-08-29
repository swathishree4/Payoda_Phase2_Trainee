
using Microsoft.AspNetCore.Mvc;
using MVCADO.Dataacess;
using MVCADO.Models;

namespace MVCADO.Controllers
{
    public class ProductController : Controller
    {
        Productdataacess obj=new Productdataacess();
        public IActionResult Index()
        {
            IEnumerable<Product> products = obj.Fetch();
            return View(products);

        }
    }
}
