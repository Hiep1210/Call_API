using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slot_4.Models;

namespace slot_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> list = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Laptop" },
                new Category { CategoryId = 2, CategoryName = "PC" },
                new Category { CategoryId = 3, CategoryName = "Mobile" },
                new Category { CategoryId = 4, CategoryName = "Tablet" },
                new Category { CategoryId = 5, CategoryName = "PC" },
                new Category { CategoryId = 6, CategoryName = "Laptop" },
                new Category { CategoryId = 7, CategoryName = "Mobile" },
                new Category { CategoryId = 8, CategoryName = "Tablet" },
                new Category { CategoryId = 9, CategoryName = "Mobiler" },
                new Category { CategoryId = 10, CategoryName = "string" },
                new Category { CategoryId = 11, CategoryName = "newcat" },
                new Category { CategoryId = 12, CategoryName = null },
                new Category { CategoryId = 13, CategoryName = "abc" },
                new Category { CategoryId = 14, CategoryName = "name" },
                new Category { CategoryId = 15, CategoryName = "new name" }
            };
        public CategoryController()
        {
        }


        [HttpGet]
        public IActionResult Get()
        {
            var categories = list.ToList();
            return Ok(categories);

        }

        // api/get/1



        // Báo not found nếu không có
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var category = list.FirstOrDefault(s => s.CategoryId == id);
            if (category == null) return NotFound("Product is not existed");
            return Ok(category);

        }

        [HttpPost]
        public IActionResult Post(Category cat)
        {
            var c = list.FirstOrDefault(s => s.CategoryName == cat.CategoryName);
            if (c != null) return BadRequest("Existed Category");
            if (cat.CategoryName == "") return BadRequest("Not Empty Name");
            cat.CategoryId = list.Count() + 1;
            list.Add(cat);
            return Created("Created Successfully", cat);
        }

        // api/post/category



        // check name có empty

        [HttpPut]
        public IActionResult Put(Category cat)
        {
            var c = list.FirstOrDefault(s => s.CategoryId == cat.CategoryId);

            if (c == null) return NotFound("No Matched Category");
            c.CategoryName = cat.CategoryName;
            return Ok(c);
        }


        // api/put/category
        // check exists

        // api/delete/id

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var c = list
                .FirstOrDefault(s => s.CategoryId == id);

            if (c == null) return NotFound("No Matched Delete Category");
            if (c.Products.Count > 0) return BadRequest("There's product existed in the category");
            list.Remove(c);
            return Ok(c);
        }

        // check products exist, check categories exists


    }
}
