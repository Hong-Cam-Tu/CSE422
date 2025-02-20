using Library_Lab4.Data;
using Library_Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Library_Lab4.Controllers
{
    public class MemberController : Controller
    {
        private readonly LibraryContext _context;

        public IActionResult Index()
        {
            var list = _context.Members.ToList();
            return View(list);
        }
       

       
    }
}
