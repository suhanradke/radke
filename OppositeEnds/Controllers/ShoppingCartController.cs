using OppositeEnds.Models;
using OppositeEnds.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OppositeEnds.Controllers
{
    public class ShoppingCartController : Controller
    {
        OppositeEndsContext storeDB = new OppositeEndsContext();
        //

        List<ShoppingCartDetail> shoppingCartDetailsProductList = new List<ShoppingCartDetail>();

        // GET: /ShoppingCart/
        public ActionResult Index()
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
           // Return the view
           return View(viewModel);

        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int? id, string type)
        {

            
            

            Furniture addedFurniture = new Furniture();
            Floral addedFloral = new Floral();

            if (Session["productId"] != null && Session["productType"] != null)
            {
                ShoppingCartDetail shoppingCartDetailModel = new ShoppingCartDetail();
                if (Session["productType"].Equals("floral"))
                {
                    int sessionStoredId = (int)Session["productId"];
                    addedFloral = storeDB.Florals
                   .Single(Floral => Floral.FloralId == sessionStoredId);

                    shoppingCartDetailModel.Name = addedFloral.Name;
                    shoppingCartDetailModel.Price = addedFloral.Price;
                    shoppingCartDetailModel.Type = type;
                    shoppingCartDetailModel.Quantity = 1;
                    shoppingCartDetailModel.RemainingItem = addedFloral.Quantity - 1;

                    shoppingCartDetailsProductList.Add(shoppingCartDetailModel);

                }
                else if (Session["productType"].Equals("furniture"))
                {
                    int sessionStoredId = (int)Session["productId"];
                    addedFurniture = storeDB.furnitures
                   .Single(Furniture => Furniture.FurnitureId == sessionStoredId);

                    shoppingCartDetailModel.Name = addedFurniture.Name;
                    shoppingCartDetailModel.Price = addedFurniture.Price;
                    shoppingCartDetailModel.Type = type;
                    shoppingCartDetailModel.Quantity = 1;

                    shoppingCartDetailsProductList.Add(shoppingCartDetailModel);
                }
            }
            else
            {
                Session["productId"] = id;
                Session["productType"] = type;

            }




            // var addedProduct = new object(); // product can be floral , furniture
            // Retrieve the album from the database

            if (type == "floral")
            {
                ShoppingCartDetail shoppingCartDetailModel = new ShoppingCartDetail();
                addedFloral = storeDB.Florals
               .Single(Floral => Floral.FloralId == id);

                shoppingCartDetailModel.Name = addedFloral.Name;
                shoppingCartDetailModel.Price = addedFloral.Price;
                shoppingCartDetailModel.Type = type;
                shoppingCartDetailModel.Quantity = 1;
                shoppingCartDetailModel.RemainingItem = addedFloral.Quantity - 1;

                shoppingCartDetailsProductList.Add(shoppingCartDetailModel);

            }
            else if(type == "furniture")
            {
                ShoppingCartDetail shoppingCartDetailModel = new ShoppingCartDetail();
                addedFurniture = storeDB.furnitures
                .Single(Furniture => Furniture.FurnitureId == id);

                shoppingCartDetailModel.Name = addedFurniture.Name;
                shoppingCartDetailModel.Price = addedFurniture.Price;
                shoppingCartDetailModel.Type = type;
                shoppingCartDetailModel.Quantity = 1;

                shoppingCartDetailsProductList.Add(shoppingCartDetailModel);
            }


            //// Add it to the shopping cart
            //var cart = ShoppingCart.GetCart(this.HttpContext);

            //cart.AddToCart(addedProduct); // Not two at a time

            // Go back to the main store page for more shopping
            //  return RedirectToAction("Index")
            return View("CartIndex",shoppingCartDetailsProductList);
        }

      
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string FloralName = storeDB.Carts
                .Single(item => item.ItemId == id).Floral.Name;

            string FurnitureName = storeDB.Carts
                .Single(item => item.ItemId == id).Furniture.Name;



            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(FloralName + FurnitureName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        public ActionResult CartIndex()
        {
          

            return View(shoppingCartDetailsProductList);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}