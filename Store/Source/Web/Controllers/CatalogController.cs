using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.App;



namespace Store.Web.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController
        public ActionResult Index(int page=1 , int pageSize=12 )
        {
            
            // Fetch products 
            var products = ProductFactory.GetProducts();

            // Paginate products
            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count() / pageSize);

            return View(pagedProducts);
        }


       
          public ActionResult Details(int id)
        {
            // Fetch product by id 
            var product = ProductFactory
                          .GetProducts()
                          .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }
    }
}

