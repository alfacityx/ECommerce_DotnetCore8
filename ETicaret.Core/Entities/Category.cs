using System.ComponentModel.DataAnnotations;

namespace ETicaret.Core.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kategori")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Üst Menüde Göster")]
        public bool IsTopMenu { get; set; }//Üst menü de gözükmesi için
        [Display(Name = "Üst Kategori")]
        public int ParentId { get; set; }//Üst kategori ne olacak
        [Display(Name = "Sıra Numarası")]
        public int OrderNo { get; set; }//Özel bir sıralama için kullanacağız( 1 de şu categori gözüksün veya şu ürün gözüksün)
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public List<Product>? Products { get; set; }
    }
}
