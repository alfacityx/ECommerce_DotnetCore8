using System.ComponentModel.DataAnnotations;

namespace ETicaret.Core.Entities
{
   public  class Brand:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        public string? Logo { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Sıra Numarası")]
        public int OrderNo { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public List<Product>? Products { get; set; }

    }
}
