﻿using Microsoft.AspNetCore.Mvc;
using SampleMVC.Services;
using SampleMVC.ViewModels;


namespace SampleMVC.Controllers;


public class CategoriesController : Controller
{
	//private readonly ICategoryBLL _categoryBLL;
	private readonly ICategoryService _categoryService;

	//public CategoriesController(ICategoryBLL categoryBLL)
	//{
	//    _categoryBLL = categoryBLL;
	//}

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	//public IActionResult Index(int pageNumber = 1, int pageSize = 5, string search = "", string act = "")
	//{
	//	////pengecekan session username
	//	//if (HttpContext.Session.GetString("user") == null)
	//	//{
	//	//    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
	//	//    return RedirectToAction("Login", "Users");
	//	//}

	//	//if (TempData["message"] != null)
	//	//{
	//	//    ViewData["message"] = TempData["message"];
	//	//}

	//	//ViewData["search"] = search;
	//	//var models = _categoryBLL.GetWithPaging(pageNumber, pageSize, search);
	//	//var maxsize = _categoryBLL.GetCountCategories(search);
	//	////return Content($"{pageNumber} - {pageSize} - {search} - {act}");

	//	//if (act == "next")
	//	//{
	//	//    if (pageNumber * pageSize < maxsize)
	//	//    {
	//	//        pageNumber += 1;
	//	//    }
	//	//    ViewData["pageNumber"] = pageNumber;
	//	//}
	//	//else if (act == "prev")
	//	//{
	//	//    if (pageNumber > 1)
	//	//    {
	//	//        pageNumber -= 1;
	//	//    }
	//	//    ViewData["pageNumber"] = pageNumber;
	//	//}
	//	//else
	//	//{
	//	//    ViewData["pageNumber"] = 2;
	//	//}

	//	//ViewData["pageSize"] = pageSize;
	//	////ViewData["action"] = action;


	//	//return View(models);

	//	throw new NotImplementedException();
	//}

	public async Task<IActionResult> GetFromServices()
	{
		var categories = await _categoryService.GetAll();
		List<Category> categorylist = new();
		foreach (var category in categories)
		{
			categorylist.Add(new Category
			{
				categoryID = category.CategoryID,
				categoryName = category.CategoryName

			});
		}
		return View(categorylist);
	}

	public IActionResult Detail(int id)
	{
		var model = _categoryService.GetById(id);
		return View(model);

	}

	public IActionResult Delete(int id)
	{
		var model = _categoryService.GetById(id);
		if (model == null)
		{
			TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
			return RedirectToAction("Index");
        }
		return View(model);
	}

	//{
	//    var model = _categoryBLL.GetById(id);
	//    return View(model);





	//public IActionResult Create()
	//{
	//	return PartialView("_CreateCategoryPartial");
	//}

	//[HttpPost]
	//public IActionResult Create(CategoryCreateDTO categoryCreate)
	//{
	//	try
	//	{
	//		_categoryBLL.Insert(categoryCreate);
	//		//ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
	//		TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
	//	}
	//	catch (Exception ex)
	//	{
	//		//ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
	//		TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
	//	}
	//	return RedirectToAction("Index");
	//}

	//public IActionResult Edit(int id)
	//{
	//	var model = _categoryBLL.GetById(id);
	//	if (model == null)
	//	{
	//		TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
	//		return RedirectToAction("Index");
	//	}
	//	return View(model);
	//}

	//[HttpPost]
	//public IActionResult Edit(int id, CategoryUpdateDTO categoryEdit)
	//{
	//	try
	//	{
	//		_categoryBLL.Update(categoryEdit);
	//		TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Edit Data Category Success !</div>";
	//	}
	//	catch (Exception ex)
	//	{
	//		ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
	//		return View(categoryEdit);
	//	}
	//	return RedirectToAction("Index");
	//}



	//public IActionResult Delete(int id)
	//{
	//	var model = _categoryBLL.GetById(id);
	//	if (model == null)
	//	{
	//		TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
	//		return RedirectToAction("Index");
	//	}
	//	return View(model);
	//}

	//[HttpPost]
	//public IActionResult Delete(int id, CategoryDTO category)
	//{
	//	try
	//	{
	//		_categoryBLL.Delete(id);
	//		TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Delete Data Category Success !</div>";
	//	}
	//	catch (Exception ex)
	//	{
	//		TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
	//		return View(category);
	//	}
	//	return RedirectToAction("Index");
	//}

	//public IActionResult DisplayDropdownList()
	//{
	//	var categories = _categoryBLL.GetAll();
	//	ViewBag.Categories = categories;
	//	return View();
	//}

	//[HttpPost]
	//public IActionResult DisplayDropdownList(string CategoryID)
	//{
	//	ViewBag.CategoryID = CategoryID;
	//	ViewBag.Message = $"You selected {CategoryID}";

	//	ViewBag.Categories = _categoryBLL.GetAll();

	//	return View();
	//}

}
