using System.ComponentModel.DataAnnotations;

namespace ETicaret.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [Display(Name="Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin mi?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Kayıt Tarihi"),ScaffoldColumn(false)]//ScaffoldColumn: oluşturulan crud sayfalarında bu kısım kullanılmamasın.
        public DateTime CreateDate { get; set; }= DateTime.Now;
        [Display(Name = "Anahtar"), ScaffoldColumn(false)]
        
        public Guid? UserGuid { get; set; } = Guid.NewGuid();//Kullanıcıları benzersiz bir şekilde tanımlamak için yazıldı.
        public List<Adress>? Adresses { get; set; }

    }
}
