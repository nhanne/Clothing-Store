﻿using Clothings_Store.Data;
using Clothings_Store.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothings_Store.Controllers;
public class HomeController : Controller
{
    private readonly StoreContext _db;
    private readonly ILogger<HomeController> _logger;
    public HomeController(StoreContext context, ILogger<HomeController> logger)
    {
        _db = context;
        _logger = logger;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            ViewData["Products"] = await _db.Products.OrderByDescending(p => p.Sold).Take(3).ToListAsync();
            _logger.LogInformation("Connected to database.");
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Connected.");
            throw;
        }
    }
    public IActionResult Store()
    {
        return View();
    }
    [HttpGet]
    public async Task<JsonResult> getData( string? search, string? category, string sort, 
                                           int page = 1, int pageSize = 8)
    {
        var query = _db.Products.AsQueryable();
        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category.Name.ToLower()
                                                    .Contains(category.Trim().ToLower()));
        }
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Name.ToLower()
                                           .Contains(search.Trim().ToLower()));
        }

        query = Sort(sort, query);

        int totalItems = await query.CountAsync();
        int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        var products = await query.Select(p => new { p,cateName = p.Category.Name} )
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .AsNoTracking()
                                  .ToListAsync();
        return Json(new{ products, TotalPages = totalPages, CurrentPage = page });
    }
    public async Task<JsonResult> getCategories()
    {
        var categories = await _db.Categories.Select(p => p).ToListAsync();
        return Json(new { categories, totalItems = categories.Count });
    }

    private IQueryable<Product> Sort(string sort, IQueryable<Product> query)
    {
        switch (sort)
        {
            case "Giá: thấp đến cao":
                query = query.OrderBy(c => c.UnitPrice);
                break;
            case "Giá: cao đến thấp":
                query = query.OrderByDescending(c => c.UnitPrice);
                break;
            case "Mới nhất":
                query = query.OrderByDescending(c => c.StockInDate);
                break;
            case "Bán chạy":
                query = query.OrderByDescending(c => c.Sold);
                break;
            case "Khuyến mãi":
                query = query.OrderByDescending(c => c.Sale);
                break;
            default:
                break;
        }
        return query;
    }
    //
    public async Task<JsonResult> Product(int Id)
    {
        var stock = await _db.Stocks.Where(p => p.ProductId == Id)
                               .Select(s => new
                               {
                                   size = new
                                   {
                                       id = s.SizeId,
                                       name = s.Size.Name
                                   },
                                   color = new
                                   {
                                       id = s.ColorId,
                                       name = s.Color.Name
                                   },
                                   product = new
                                   {
                                       id = s.ProductId,
                                       image = s.Product.Picture,
                                       name = s.Product.Name,
                                       costPrice = s.Product.CostPrice,
                                       unitPrice = s.Product.UnitPrice,
                                       sale = s.Product.Sale,
                                       category = s.Product.Category.Name
                                   }
                               }).ToListAsync();
        var sizes = stock.Select(item => item.size).Distinct().ToList();
        var colors = stock.Select(item => item.color).Distinct().ToList();
        var product = stock.Select(item => item.product).Distinct().ToList();
        return Json(new
        {
            product,
            sizes,
            colors
        });
    }
    //
    [HttpGet]
    public async Task<JsonResult> getStock(int productId, int sizeId, int colorId)
    {
        var stock = await _db.Stocks.Where(p => p.ProductId == productId
                                            && p.ColorId == colorId
                                            && p.SizeId == sizeId)
                                    .FirstOrDefaultAsync();

        int quantity = stock == null ? 0 : (int)stock.Quantity!;
        return Json(new { quantity });
    }

    
}