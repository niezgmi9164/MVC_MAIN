# System zarządzania zadaniami zespołu

Aplikacja webowa ASP.NET Core MVC (.NET 10) do zarządzania zadaniami w zespole programistycznym. Każde zadanie ma tytuł, opis, przypisaną osobę, projekt, status oraz priorytet. Dane przechowywane są w bazie SQL Server (LocalDB) z wykorzystaniem Entity Framework Core. Projekt zaliczeniowy z przedmiotu dotyczącego wzorca MVC (zadanie 7).

## Spis treści

1. [Opis](#opis)
2. [Technologie](#technologie)
3. [Funkcjonalności](#funkcjonalności)
4. [Struktura projektu](#struktura-projektu)
5. [Wymagania](#wymagania)
6. [Uruchomienie](#uruchomienie)
7. [Dane przykładowe](#dane-przykładowe)

## Opis

Aplikacja pozwala dodawać, przeglądać, edytować i usuwać zadania zespołu (operacje CRUD). Listę zadań można przeszukiwać po tytule oraz filtrować po projekcie i statusie. Zbudowana jest w oparciu o wzorzec MVC (model, widok, kontroler) oraz Entity Framework Core jako warstwę dostępu do bazy danych.

## Technologie

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core 10 (Microsoft.EntityFrameworkCore.SqlServer)
- Baza danych SQL Server LocalDB
- Bootstrap 5 oraz jQuery Validation (biblioteki zewnętrzne w `wwwroot/lib`)

## Funkcjonalności

Podstawowe:

- Lista zadań z kolumnami: tytuł, projekt, osoba, status, priorytet, termin.
- Dodawanie, edycja, szczegóły i usuwanie zadań (CRUD).

Dodatkowe (rozszerzenia ponad ocenę podstawową):

- Wyszukiwanie i filtrowanie zadań po tytule, projekcie i statusie.
- Walidacja danych po stronie serwera (atrybuty na modelu) oraz po stronie klienta (jQuery Validation), na przykład wymagany tytuł czy minimalna długość opisu.

## Struktura projektu

- `Models/Zadanie.cs` - model główny (z atrybutami walidacji).
- `Models/Status.cs`, `Models/Priorytet.cs` - typy wyliczeniowe (enum) używane w zadaniu.
- `Models/ZadanieFiltrViewModel.cs` - model widoku listy z polami do filtrowania.
- `Models/SeedData.cs` - dane przykładowe wczytywane przy pierwszym uruchomieniu.
- `Data/ZadaniaZespoluContext.cs` - kontekst Entity Framework Core (DbContext).
- `Controllers/ZadaniaController.cs` - kontroler zadań (CRUD oraz wyszukiwanie/filtrowanie).
- `Controllers/HomeController.cs` - strona startowa.
- `Views/Zadania/` - widoki: Index, Create, Edit, Details, Delete.
- `Migrations/` - migracje bazy danych Entity Framework Core.

## Wymagania

- .NET SDK 10.0
- SQL Server LocalDB (instalowany razem z Visual Studio)
- Visual Studio 2022/2026 lub nowsze (zalecane)

## Uruchomienie

1. Otwórz plik `ZadaniaZespolu.slnx` w Visual Studio.
2. Uruchom aplikację przyciskiem Start (lub `dotnet run` w katalogu projektu).

Baza danych tworzy się automatycznie przy pierwszym uruchomieniu (migracje są stosowane w kodzie startowym), a następnie wypełniana jest danymi przykładowymi.

Gdyby baza nie utworzyła się automatycznie, można ją utworzyć ręcznie z poziomu Package Manager Console:

```
Update-Database
```

## Dane przykładowe

Przy pierwszym uruchomieniu do bazy dodawanych jest pięć przykładowych zadań w dwóch projektach. Aby wygenerować je ponownie, usuń bazę danych (Package Manager Console: `Drop-Database`) i uruchom aplikację jeszcze raz.
