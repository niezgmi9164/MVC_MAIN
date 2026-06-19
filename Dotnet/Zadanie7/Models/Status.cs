using System.ComponentModel.DataAnnotations;

namespace ZadaniaZespolu.Models
{
    public enum Status
    {
        [Display(Name = "Do zrobienia")]
        DoZrobienia,

        [Display(Name = "W trakcie")]
        WTrakcie,

        [Display(Name = "Do testów")]
        DoTestow,

        [Display(Name = "Zakończone")]
        Zakonczone
    }
}
