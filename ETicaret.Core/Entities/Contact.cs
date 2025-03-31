using System.ComponentModel.DataAnnotations;

namespace ETicaret.Core.Entities
{
   public class Contact:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"),Required(ErrorMessage ="{0} Alanı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Soyad"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Message { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
      


    }
}
