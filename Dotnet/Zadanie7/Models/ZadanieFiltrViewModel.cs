using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZadaniaZespolu.Models
{
    // Model widoku listy zadań
    public class ZadanieFiltrViewModel
    {
        public List<Zadanie>? Zadania { get; set; }
        public SelectList? Projekty { get; set; }
        public string? Projekt { get; set; }
        public Status? Status { get; set; }
        public string? SzukanyTekst { get; set; }
    }
}
