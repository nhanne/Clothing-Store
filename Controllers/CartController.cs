﻿using Clothings_Store.Data;
using Clothings_Store.Identity;
using Clothings_Store.Models;
using Clothings_Store.Patterns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Clothings_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly StoreContext _db;
        public CartController(StoreContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalPrice = TotalPrice();
            ViewBag.TotalItems = TotalItems();
            return View(GetCart());
        }

        public const string CARTKEY = "cart";
        public List<Cart> GetCart()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (!string.IsNullOrEmpty(jsoncart))
            {
                return JsonConvert.DeserializeObject<List<Cart>>(jsoncart);
            }
            return new List<Cart>();
        }
        private double TotalPrice()
        {
            double iTotalPrice = 0;
            var listCart = GetCart();
            if (listCart != null)
            {
                iTotalPrice = listCart.Sum(n => n.totalPrice);
            }
            return iTotalPrice;
        }
        public int TotalItems()
        {
            int iTotalItems = 0;
            var listCart = GetCart(); ;
            if (listCart != null)
            {
                iTotalItems = listCart.Sum(n => n.quantity);
            }
            return iTotalItems;
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        void SaveCartSession(List<Cart> listCart)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(listCart);
            session.SetString(CARTKEY, jsoncart);
        }
        [HttpPost]
        public JsonResult AddToCart(int productId, int colorId, int sizeId)
        {
            var stock = _db.Stocks.Where(p => p.ProductId == productId && p.ColorId == colorId && p.SizeId == sizeId).FirstOrDefault();
            if (stock == null) return Json(false);

            var listCart = GetCart();
            var cartitem = listCart.Find(p => p.IdCart == stock.Id);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cartitem = new Cart(_db, stock.Id);
                listCart.Add(cartitem);
            }

            SaveCartSession(listCart);
            return Json(true);
        }
        public IActionResult RemoveFromCart(int IdCart)
        {
            var listCart = GetCart();
            Cart item = listCart.SingleOrDefault(c => c.IdCart == IdCart);
            if (item != null)
            {
                listCart.RemoveAll(c => c.IdCart == IdCart);
                SaveCartSession(listCart);
                return Json(new { status = true, messege = "Đã xóa sản phẩm khỏi giỏ hàng" });
            }
            if (listCart.Count == 0)
            {
                return RedirectToAction("Store", "Home");
            }
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCart(int IdCart, IFormCollection form)
        {
            List<Cart> listCart = GetCart();
            Cart item = listCart.SingleOrDefault(c => c.IdCart == IdCart);
            if (item != null)
            {
                item.quantity = int.Parse(form["quantity"].ToString());
            }
            SaveCartSession(listCart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            List<Cart> listCart = GetCart();
            if(listCart.Count == 0){
                return RedirectToAction("Store","Home");
            }
            return View(listCart);
        }
        [HttpPost]
        public IActionResult CheckOut(AppUser userModel, Order orderModel, String code)
        {
            Order order = new Order();
            order_Customer(order, userModel);
            order_Info(order, orderModel);
            _db.Orders.Add(order);
            _db.SaveChanges();
            order_Detail(order.Id);
            return Json(new { redirectToUrl = Url.Action("Index", new { Id = order.Id }) });
        }
        void order_Customer(Order order, AppUser userModel)
        {
            AppUser? user = _db.Users.SingleOrDefault(m => m.Email.Equals(userModel.Email));
            if (user != null)
            {
                order.UserId = user.Id;
            }
            else
            {
                Customer noAccount = new Customer();
                noAccount.Email = userModel.Email;
                noAccount.Phone = userModel.PhoneNumber;
                noAccount.FullName = userModel.Name;
                noAccount.Address = userModel.Address;
                noAccount.Password = "Admin123?";
                noAccount.Member = false;
                _db.Customers.Add(noAccount);
                _db.SaveChanges();
            }
        }
        void order_Info(Order order, Order orderModel)
        {
            order.OrdTime = DateTime.Now;
            order.DeliTime = order.OrdTime.AddDays(3);
            order.Status = "Chờ xác nhận";
            order.PaymentId = orderModel.PaymentId;
            order.Address = orderModel.Address;
            order.Note = orderModel.Note;
            order.TotalQuantity = TotalItems();
            order.TotalPrice = TotalPrice();
        }
        void order_Detail(int orderId)
        {
            List<Cart> listCart = GetCart();
            foreach (var item in listCart)
            {
                //OrderDetail detailItem = new OrderDetail();
                //detailItem.OrderId = orderId;
                //detailItem.StockId = item.Stock.Id;
                //detailItem.Quantity = item.quantity;
                //detailItem.UnitPrice = item.unitPrice;
                //_db.OrderDetails.Add(detailItem);
                //detailItem.Stock.Product.Sold++;
                //detailItem.Stock.Stock1--;
                //_db.Entry(detailItem.Stock).State = EntityState.Modified;
                //_db.SaveChanges();
            }
        }
    } 
}
