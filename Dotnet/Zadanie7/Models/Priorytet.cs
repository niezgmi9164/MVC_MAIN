using System.ComponentModel.DataAnnotations;

namespace ZadaniaZespolu.Models
{
    // Priorytet zadania.
    public enum Priorytet
    {
        [Display(Name = "Niski")]
        Niski,

        [Display(Name = "Średni")]
        Sredni,

        [Display(Name = "Wysoki")]
        Wysoki
    }
}
