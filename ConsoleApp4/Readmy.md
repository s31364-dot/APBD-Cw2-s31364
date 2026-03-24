# System Wypożyczalni Sprzętu Uczelnianego

Aplikacja realizująca system obsługi wypożyczalni sprzętu.

## Właściwości projektu i zakres funkcjonalności

Aplikacja symuluje działanie pełnoprawnego systemu zarządzania zasobami i oferuje następujące mechanizmy:
1. Zarządzanie asortymentem: dodawanie oraz ewidencja sprzętu o różnej specyfikacji (np. laptopy, projektory, aparaty fotograficzne).
2. Zarządzanie użytkownikami: obsługa różnych profili (studenci, pracownicy uczelni) posiadających odmienne limity wypożyczeń.
3. Obsługa procesu wypożyczania i zwrotów: walidacja dostępności sprzętu, sprawdzanie limitów przypisanych do użytkownika oraz automatyczne naliczanie kar finansowych za przekroczenie terminu zwrotu.
4. Raportowanie: generowanie podsumowań dotyczących aktualnego stanu systemu (ilość sprzętu dostępnego, wypożyczonego, uszkodzonego oraz lista przeterminowanych wypożyczeń).

## Architektura i decyzje projektowe

1. Podział na warstwy (Modele i Serwisy)
   Rozdzielono definicje struktur danych od logiki biznesowej. Klasy w folderach Equipment i Users odpowiadają wyłącznie za reprezentację stanu obiektów.

2. Dziedziczenie i Polimorfizm
   Zastosowano abstrakcyjne klasy bazowe, po których dziedziczą wyspecjalizowane podklasy.
