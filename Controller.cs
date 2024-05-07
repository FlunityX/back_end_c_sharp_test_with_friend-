using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using back_end_c_sharp_test_with_friend_.Entities;
using System.Linq;

namespace book.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DbAa8167Nguyenmanh1203Context _context;

        public BookController(DbAa8167Nguyenmanh1203Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Sach> saches = _context.Saches.ToList();
            return Ok(saches);
        }
        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return Ok(sach);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            Sach sach = _context.Saches.FirstOrDefault(s => s.Masach == id);

            if (sach != null)
            {
                return Ok(sach);
            }
            else
            {
                return NotFound();
            }
        }
    }
}