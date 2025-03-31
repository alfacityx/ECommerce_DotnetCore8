using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Sipariş Numarası"), StringLength(40)]
        public string OrderNumber { get; set; }
        [Display(Name = "Sipariş Toplamı")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Kullanıcı Numarası")]
        public int AppUserId { get; set; } //Hangi Kullanıcı verdi
        [Display(Name = "Müşteri Numarası"), StringLength(40)]
        public string CustomerId { get; set; } //Hangi Müşteri verdi
        [Display(Name = "Fatura Adresi"), StringLength(40)]
        public string BillingAddress { get; set; }
        [Display(Name = "Teslimat Adresi"), StringLength(40)]
        public string DeliveryAddress { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        public List<OrderLine>? OrderLines { get; set; }
        [Display(Name = "Müşteri"), StringLength(40)]
        public AppUser? appUser { get; set; }
        [Display(Name = "Sipariş Durumu")]
        public EnumOrderState OrderState { get; set; }


    }
    public enum EnumOrderState //Sipariş aşamaları için Enum kullanıyoruz.
    {
        [Display(Name = "Onay Bekliyor")]
        Waiting,
        [Display(Name = "Onaylandı")]
        Approved,
        [Display(Name = "Kargoya Verildi")]
        Shipped,
        [Display(Name = "Tamamlandı")]
        Completed,
        [Display(Name = "İptal Edildi")]
        Canceled,
        [Display(Name = "İade Edildi")]
        Returned

    }
}
