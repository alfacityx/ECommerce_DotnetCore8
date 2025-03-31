using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ETicaret.Core.Entities
{
    public class Adress:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adres Başlığı"), StringLength(75), Required(ErrorMessage = "{0} Alanı Zorunludur!")]
        public string Title { get; set; }
        [Display(Name = "Şehir"), StringLength(25), Required(ErrorMessage = "{0} Alanı Zorunludur!")]
        public string City { get; set; }
        [Display(Name = "İlçe"), StringLength(25), Required(ErrorMessage = "{0} Alanı Zorunludur!")]
        public string District { get; set; }
        [Display(Name = "Açık Adres"),DataType(DataType.MultilineText), Required(ErrorMessage = "{0} Alanı Zorunludur!")] //Data.Type.Multiline çoklu satır demek.
        public string OpenAdress { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Fatura Adresi"), Required(ErrorMessage = "{0} Alanı Zorunludur!")]
        public bool IsBillingAdress { get; set; }
        [Display(Name ="Teslimat Adresi"), Required(ErrorMessage = "{0} Alanı Zorunludur!")]
        public bool IsDeliveryAdress { get; set; }

        [Display(Name = "Oluşturma Tarihi"), ScaffoldColumn(false)]//ScaffoldColumn: oluşturulan crud sayfalarında bu kısım kullanılmamasın.
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Anahtar"), ScaffoldColumn(false)]
        public Guid? AdressGuid { get; set; } = Guid.NewGuid();//Adreslerin benzersiz bir şekilde tanımlamak için yazıldı.
        [Display(Name = "Kullanıcı Numarası")]
        public int? AppUserId { get; set; }
        [Display(Name = "Kullanıcı")]
        public AppUser? appUser { get; set; }

    }
}
