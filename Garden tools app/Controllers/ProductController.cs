using Garden_tools_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden_tools_app.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Бензопила", Description = "Легка та надійна бензопила для саду та побутових завдань.", Price = 6499.00m, Category = "Пили", InStock = true },
            new Product { Id = 2, Name = "Електрична газонокосарка", Description = "Екологічна косарка для рівних газонів.", Price = 4200.00m, Category = "Газонокосарки", InStock = false },
            new Product { Id = 3, Name = "Акумуляторний тример", Description = "Мобільний інструмент для скошування трави у важкодоступних місцях.", Price = 3800.00m, Category = "Тримери", InStock = true },
            new Product { Id = 4, Name = "Мотокультиватор", Description = "Для оранки та розпушування ґрунту на городі.", Price = 12500.00m, Category = "Культиватори", InStock = true },
            new Product { Id = 5, Name = "Повітродувка бензинова", Description = "Швидке прибирання листя та сміття на вулиці.", Price = 5900.00m, Category = "Прибиральна техніка", InStock = true },
            new Product { Id = 6, Name = "Кущоріз електричний", Description = "Для формування кущів.", Price = 2950.00m, Category = "Кущорізи", InStock = true },
            new Product { Id = 7, Name = "Висоторіз", Description = "Для обрізання високих гілок дерев без драбини.", Price = 4600.00m, Category = "Пили", InStock = true },
            new Product { Id = 8, Name = "Садовий подрібнювач гілок", Description = "Подрібнює гілки на органічне добриво (мульчу).", Price = 7100.00m, Category = "Подрібнювачі", InStock = true },
            new Product { Id = 9, Name = "Насос поверхневий для поливу", Description = "Для подачі води з колодязя чи бака.", Price = 2400.00m, Category = "Полив", InStock = false },
            new Product { Id = 10, Name = "Акумуляторний обприскувач садовий", Description = "Зручний розпилювач для добрив та захисту рослин.", Price = 1950.00m, Category = "Обприскувачі", InStock = true },
            new Product { Id = 11, Name = "Лопата штикова сталева", Description = "Класичний інструмент для земляних робіт.", Price = 350.00m, Category = "Ручний інструмент", InStock = true },
            new Product { Id = 12, Name = "Граблі", Description = "Для прибирання листя та сміття.", Price = 280.00m,Category = "Ручний інструмент", InStock = true },
            new Product { Id = 13, Name = "Секатор", Description = "Для обрізання гілок до 25 мм.", Price = 450.00m, Category = "Ручний інструмент", InStock = true },
            new Product { Id = 14, Name = "Шланг поливальний ", Description = "Тришаровий стійкий до заломів шланг.", Price = 1350.00m, Category = "Полив", InStock = true },
            new Product { Id = 15, Name = "Котушка для шланга автоматична", Description = "Зручне зберігання поливального шланга.", Price = 2600.00m, Category = "Полив", InStock = false },
            new Product { Id = 17, Name = "Дощувач круговий імпульсний", Description = "Для автоматичного поливу газону.", Price = 420.00m, Category = "Полив", InStock = true },
            new Product { Id = 18, Name = "Снігоприбирач бензиновий самохідний", Description = "Для швидкого очищення території від снігу.", Price = 28900.00m, Category = "Прибиральна техніка", InStock = false },
            new Product { Id = 19, Name = "Сокира", Description = "Для розколювання полін та дров.", Price = 1150.00m, Category = "Ручний інструмент", InStock = true }
        };

        private static readonly List<Product> Cart = new List<Product>();
        private static readonly List<string> Reviews = new List<string> { "Андрій: Чудові інструменти!" };

        public IActionResult Details(int id = 1)
        {
            var product = Products.FirstOrDefault(p => p.Id == id) ?? Products.First();

            ViewBag.Products = Products;
            ViewBag.Cart = Cart;
            ViewBag.Reviews = Reviews;

            return View("ProductDetails", product);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null) Cart.Add(product);
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id, int currentId)
        {
            var product = Cart.FirstOrDefault(p => p.Id == id);
            if (product != null) Cart.Remove(product);
            return RedirectToAction("Details", new { id = currentId });
        }

        [HttpPost]
        public IActionResult AddReview(int id, string reviewText)
        {
            if (!string.IsNullOrEmpty(reviewText))
            {
                Reviews.Add(reviewText);
            }
            return RedirectToAction("Details", new { id });
        }
    }
}
