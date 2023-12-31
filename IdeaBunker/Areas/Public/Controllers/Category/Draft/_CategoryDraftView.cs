﻿using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Category.Create)]
public partial class CategoryDraftController : Controller
{
    public async Task<IActionResult> Index()
    {
        var projects = await GetCategoriesAsync();
        var viewModels = new List<CategoryViewModel>();
        foreach (var project in projects)
        {
            var viewModel = await SetCategoryViewModelAsync(project.Id);
            viewModels.Add(viewModel);
        }
        return View(viewModels);
    }
}