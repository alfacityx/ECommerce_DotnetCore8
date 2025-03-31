using ETicaret.Core.Entities;

namespace ETicaret.WebUI.Models
{
    public class CheckOutViewModel
    {
        public List<CartLine>? CartProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Adress>? Adresses { get; set; }
    }
}
