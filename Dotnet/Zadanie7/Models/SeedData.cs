using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZadaniaZespolu.Data;

namespace ZadaniaZespolu.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ZadaniaZespoluContext(
                serviceProvider.GetRequiredService<DbContextOptions<ZadaniaZespoluContext>>()))
            {
                // Utworzenie bazy i zastosowanie migracji jak baza jeszcze nie istnieje.
                context.Database.Migrate();

                // Jeśli w bazie są już zadania, nie dodajemy ponownie.
                if (context.Zadanie.Any())
                {
                    return;
                }

                context.Zadanie.AddRange(
                    new Zadanie
                    {
                        Tytul = "Logowanie użytkownika",
                        Opis = "Zaimplementować ekran logowania wraz z walidacją.",
                        Osoba = "Anna Kowalska",
                        Projekt = "Sklep internetowy",
                        Status = Status.WTrakcie,
                        Priorytet = Priorytet.Wysoki,
                        TerminWykonania = DateTime.Parse("2025-06-30"),
                        DataUtworzenia = DateTime.Parse("2025-06-01")
                    },
                    new Zadanie
                    {
                        Tytul = "Endpoint API koszyka",
                        Opis = "Przygotować REST API do obsługi koszyka zakupowego.",
                        Osoba = "Piotr Nowak",
                        Projekt = "Sklep internetowy",
                        Status = Status.DoZrobienia,
                        Priorytet = Priorytet.Sredni,
                        TerminWykonania = DateTime.Parse("2025-07-10"),
                        DataUtworzenia = DateTime.Parse("2025-06-03")
                    },
                    new Zadanie
                    {
                        Tytul = "Testy modułu płatności",
                        Opis = "Napisać scenariusze testowe dla modułu płatności.",
                        Osoba = "Marek Wiśniewski",
                        Projekt = "Sklep internetowy",
                        Status = Status.DoTestow,
                        Priorytet = Priorytet.Wysoki,
                        TerminWykonania = DateTime.Parse("2025-07-05"),
                        DataUtworzenia = DateTime.Parse("2025-06-04")
                    },
                    new Zadanie
                    {
                        Tytul = "Ekran startowy aplikacji",
                        Opis = "Zaprojektować i wykonać ekran powitalny aplikacji mobilnej.",
                        Osoba = "Anna Kowalska",
                        Projekt = "Aplikacja mobilna",
                        Status = Status.Zakonczone,
                        Priorytet = Priorytet.Niski,
                        TerminWykonania = DateTime.Parse("2025-06-20"),
                        DataUtworzenia = DateTime.Parse("2025-05-20")
                    },
                    new Zadanie
                    {
                        Tytul = "Powiadomienia push",
                        Opis = "Dodać obsługę powiadomień push w aplikacji mobilnej.",
                        Osoba = "Piotr Nowak",
                        Projekt = "Aplikacja mobilna",
                        Status = Status.DoZrobienia,
                        Priorytet = Priorytet.Sredni,
                        TerminWykonania = DateTime.Parse("2025-07-15"),
                        DataUtworzenia = DateTime.Parse("2025-06-10")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
