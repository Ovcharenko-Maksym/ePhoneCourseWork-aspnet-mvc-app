using ePhoneCourseWork.Data.Cart;
using ePhoneCourseWork.Data.Services;
using ePhoneCourseWork.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IProductsService _productsService;
		private readonly ShoppingCart _shoppingCart;
		private readonly IOrdersService _ordersService;

		public OrdersController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService ordersService)
		{
			_productsService = productsService;
			_shoppingCart = shoppingCart;
			_ordersService = ordersService;
		}

		public IActionResult Index()
		{
			string userId = "";
			var orders = _ordersService.GetOrdersByUserId(userId);
			return View(orders);
		}

		public IActionResult ShoppingCart()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};
			return View(response);
		}

		public IActionResult AddItemToShoppingCart(int id)
		{
			var item = _productsService.GetProductById(id);
			if (item != null)
			{
				_shoppingCart.AddItemToCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

		public IActionResult RemoveItemFromShoppingCart(int id)
		{
			var item = _productsService.GetProductById(id);
			if (item != null)
			{
				_shoppingCart.RemoveItemFromCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

		public IActionResult CompleteOrder()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = "";
			string userEmailAddress = "";

			_ordersService.StoreOrder(items, userId, userEmailAddress);
			_shoppingCart.ClearShoppingCart();
			return View("OrderCompleted");
		}
	}

}