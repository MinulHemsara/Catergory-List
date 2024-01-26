using BookListWeb.Data;
using BookListWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookListWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationContext _db;

    public CategoryController(ApplicationContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList= _db.Categories;
        return View(objCategoryList);
    }

    //GET
    public IActionResult Create()
    {
        
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {

        if(obj.Name == obj.DisplayOrder.ToString()) {

            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

        }

        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    
    public IActionResult Edit(int? id)
    {
        if(id == null|| id==0) {
        return NotFound();
                
                }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);

        if(categoryFromDb == null) {
            return NotFound();
                
                }

        return View(categoryFromDb);
    }

    //Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString())
        {

            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

        }

        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Update successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();

        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories.Find(id);

        if (obj==null)
        {

            return NotFound();

        }
        _db.Categories.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        
    }

}
