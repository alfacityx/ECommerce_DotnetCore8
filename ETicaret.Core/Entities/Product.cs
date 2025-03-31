using System.ComponentModel.DataAnnotations;

namespace ETicaret.Core.Entities
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Fiyat")]
        public Decimal Price { get; set; }
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfa da mı?")]
        public bool IsHome { get; set; }//Anasayfa da göstermek için
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        //Bir ürün ekleme formunda, kullanıcı kategori seçimini yapmamış olabilir. Category özelliği nullable değilse, bu durumda model doğrulama hatası oluşur ve ürün ekleme işlemi başarısız olur. Category özelliğini nullable yaparak, bu durumu önleyebilir ve ürün ekleme işleminin başarılı olmasını sağlayabilirsiniz.
        public Category? Category { get; set; }
        [Display(Name = "Marka")]
        public int BrandId { get; set; }
        [Display(Name = "Marka")]
        public Brand? Brand { get; set; }
        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }//Özel bir sıralama için kullanacağız( 1 de şu categori gözüksün veya şu ürün gözüksün)
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }= DateTime.Now;

    }
}
