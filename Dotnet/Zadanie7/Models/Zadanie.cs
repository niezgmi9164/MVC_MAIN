using System.ComponentModel.DataAnnotations;

namespace ZadaniaZespolu.Models
{
    // Model główny aplikacji 
    public class Zadanie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć od 3 do 100 znaków.")]
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Opis musi mieć od 5 do 500 znaków.")]
        [Display(Name = "Opis")]
        public string Opis { get; set; } = string.Empty;

        [Required(ErrorMessage = "Podaj osobę odpowiedzialną.")]
        [StringLength(60, ErrorMessage = "Maksymalnie 60 znaków.")]
        [Display(Name = "Przypisana osoba")]
        public string Osoba { get; set; } = string.Empty;

        [Required(ErrorMessage = "Podaj nazwę projektu.")]
        [StringLength(80, ErrorMessage = "Maksymalnie 80 znaków.")]
        [Display(Name = "Projekt")]
        public string Projekt { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Display(Name = "Priorytet")]
        public Priorytet Priorytet { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Termin wykonania")]
        public DateTime? TerminWykonania { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data utworzenia")]
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;
    }
}
