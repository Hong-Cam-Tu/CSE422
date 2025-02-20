using Library_Lab4.Data;
using Library_Lab4.Models;
using Library_Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Library_Lab4.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public IActionResult Index()
        {
            return View(_memberService.GetAllMembers());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberService.AddMember(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public IActionResult Edit(int id)
        {
            var book = _memberService.GetMemberById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberService.UpdateMember(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public IActionResult Delete(int id)
        {
            _memberService.DeleteMember(id);
            return RedirectToAction("Index");
        }

        public IActionResult SearchMembers(string key)
        {
            var book = _memberService.SearchMembers(key);
            return View("Index", book);
        }
    }
}
