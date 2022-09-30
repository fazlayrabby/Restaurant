using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IUnitOfWork;
using Restaurant.Models.Models;
using Restaurant.Models.ViewModels;


namespace Restaurant.Areas.Order.Controllers
{
    [Area("Order")]
    public class OrderController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostingEnvironment;
        public OrderController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            OrderVM orderVM = new OrderVM();
            orderVM.orders = _unitOfWork.Order.GetAll();
            return View(orderVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            OrderVM vm = new OrderVM()
            {
                Order=new(),
                Products =_unitOfWork.Product.GetAll().Select(x =>
                new SelectListItem()
                {
                    Text = x.ProductName,
                    Value = x.ProductId.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Order = _unitOfWork.Order.GetT(x => x.OrderId == id);
                if (vm.Order == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }

            }
        }

        

        public IActionResult AddedList()
        {
            OrderVM orderVM = new OrderVM();
            orderVM.orders = _unitOfWork.Order.GetAll();

            return View("AddedList", orderVM);
        }


        public IActionResult CreateForm()
        {
            var vm = new OrderVM();
            ViewBag.ProductDw = new SelectList(_unitOfWork.Product.GetAll(), "ProductId", "ProductName");
            return View("CreateForm", vm);
        }


        public IActionResult CreateOrder(OrderVM vm)
        {
            if (ModelState.IsValid)
            {

                OrderVM orderVM = new OrderVM
                {
                    Order = new()
                };
                orderVM.Order.FirstName = vm.FirstName;
                orderVM.Order.LastName = vm.LastName;
                orderVM.Order.State = vm.State;
                orderVM.Order.Date = vm.Date;
                List<OrderProduct> orderProducts = new List<OrderProduct>();
                foreach (var item in vm.ProductList)
                {
                   orderProducts.Add(new OrderProduct { ProductId = Convert.ToInt32(item), Order = orderVM.Order });
                   orderVM.Order.Product += _unitOfWork.Product.GetT(x=>x.ProductId==Convert.ToInt32(item)).ProductName+" ";
                }

                orderVM.Order.OrderProduct = orderProducts;

                if (orderVM.Order.OrderId == 0)
                {
                    _unitOfWork.Order.Add(orderVM.Order);
                    TempData["success"] = "Order Created Done!";
                }
                
                _unitOfWork.Save();

                return Json(new { success = true, Error = TempData["success"] });
            }
            return Json(new { success = false, Error = "Failed!" });
        }


        public IActionResult EditForm(int orderId)
        {
            
            var order = _unitOfWork.Order.GetT(x => x.OrderId == orderId);
            var orderProduct = _unitOfWork.OrderProduct.GetAll().Where(x=>x.OrderId==order.OrderId);
            List<string> productSelected = new List<string>();
            foreach (var item in orderProduct)
            {
                productSelected.Add(item.ProductId.ToString());
            }
            ViewBag.ProdSelected = productSelected;
            ViewBag.ProductList = new SelectList(_unitOfWork.Product.GetAll(), "ProductId", "ProductName");
            return View("EditForm", order);
        }


        public IActionResult EditOrderComplete(OrderVM vm)
        {
           
            if (ModelState.IsValid)
            {

                OrderVM orderVM = new OrderVM
                {
                    Order = new()
                };
                orderVM.Order.OrderId = vm.OrderId;
                orderVM.Order.FirstName = vm.FirstName;
                orderVM.Order.LastName = vm.LastName;
                orderVM.Order.State = vm.State;
                orderVM.Order.Date = vm.Date;
                List<OrderProduct> orderProducts = new List<OrderProduct>();
                foreach (var item in vm.ProductList)
                {
                    orderProducts.Add(new OrderProduct { ProductId = Convert.ToInt32(item), OrderId = vm.OrderId });
                    orderVM.Order.Product += _unitOfWork.Product.GetT(x => x.ProductId == Convert.ToInt32(item)).ProductName + " ";
                }

                orderVM.Order.OrderProduct = orderProducts;

                if (orderVM.Order.OrderId != 0)
                {
                    var currentOrderProduct = _unitOfWork.OrderProduct.GetAll().Where(x => x.OrderId == vm.OrderId);
                    _unitOfWork.OrderProduct.DeleteRange(currentOrderProduct);
                    _unitOfWork.Order.Update(orderVM.Order);

                    TempData["success"] = "Order Update Done!";
                }

                _unitOfWork.Save();

                return Json(new { success = true, Error = TempData["success"] });
            }
            return Json(new { success = false, Error = "Failed!" });
        }

       


        #region DeleteAPICALL
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var order = _unitOfWork.Order.GetT(x => x.OrderId == id);
            if (order == null)
            {
                return Json(new { success = false, Error = "Error in Fatching data" });
            }
            else
            {
               
                _unitOfWork.Order.Delete(order);
                _unitOfWork.Save();
                return Json(new { success = true, Error = "Order Deleted" });
            }
        }
        #endregion
    }
}
