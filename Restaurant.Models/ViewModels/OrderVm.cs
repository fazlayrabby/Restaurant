using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Restaurant.Models.ViewModels
{
    public class OrderVM
    {
        [ValidateNever]
        public int OrderId { get; set; }
        [ValidateNever]
        public string State { get; set; }
        [ValidateNever]
        public string Product { get; set; }

        [ValidateNever]
        public string FirstName { get; set; }
        [ValidateNever]
        public string LastName { get; set; }
        [ValidateNever]
        public DateTime Date { get; set; }
        //[ValidateNever]
        //public int ProductId { get; set; }
        [ValidateNever]
        public Order Order { get; set; }
        [ValidateNever]
        public List<string> ProductList { get; set; }
        
        public IEnumerable<Order> orders = new List<Order>();
        
        [ValidateNever]
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
