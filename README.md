# Konfigurator Samochodu (.NET MAUI)

## Opis zadania  
Należy przygotować **aplikację mobilną** umożliwiającą konfigurację samochodu poprzez wybór **koloru lakieru**, **rodzaju felg** oraz **dodatkowego wyposażenia**.  
Aplikacja ma dynamicznie aktualizować i wyświetlać łączną cenę samochodu na podstawie dokonanych wyborów.  

Projekt należy wykonać w środowisku programistycznym dostępnym na stanowisku egzaminacyjnym z wykorzystaniem archiwum `konfigurator.zip`, które zawiera grafikę pojazdów oraz plik `ceny.txt` z wartościami używanymi w obliczeniach.

---

## Wymagane elementy aplikacji  

- **Obraz samochodu** – w stanie początkowym wyświetla grafikę `szary.png`  
- **Nagłówek aplikacji** – Label z tekstem: „Konfigurator wyposażenia”  
- **Sekcja wyboru koloru lakieru**  
  - Label z tekstem: „Wybierz kolor lakieru”  
  - Lista rozwijana (ComboBox / Picker) z wartościami:  
    `szary`, `czerwony`, `zielony`, `żółty`, `granatowy`  
  - Zmiana koloru powoduje podmianę obrazu na odpowiednią grafikę  

- **Separator** – linia pozioma  

- **Sekcja wyboru felg**  
  - Label z tekstem: „Felgi”  
  - Grupa przycisków jednokrotnego wyboru (RadioButton):  
    - „Stalowe” – domyślnie zaznaczony  
    - „Aluminiowe” – opcjonalny wybór  

- **Separator** – linia pozioma  

- **Sekcja wyposażenia dodatkowego**  
  - Label z tekstem: „Wybierz dodatkowe wyposażenie”  
  - Pola wyboru (CheckBox):  
    - Czujniki parkowania  
    - Climatronic  
    - Nawigacja  

- **Separator** – linia pozioma  

- **Sekcja wyceny**  
  - Label z tekstem: „Wycena”  
  - Pole tekstowe (Label / TextBox, tylko do odczytu) zawierające dynamicznie aktualizowaną listę wybranych opcji z cenami i łączną kwotę  

---

## Klasa `Auto`  

Klasa odpowiedzialna za przechowywanie konfiguracji i obliczanie ceny.  

### Pola prywatne:
- `kolor` – tekstowy, kolor lakieru  
- `felgi` – tekstowy, rodzaj felg  
- `wyposazenie` – tablica typu `bool[3]`, reprezentująca zaznaczenie opcji dodatkowych  

### Konstruktory:
- **Bezparametrowy** – ustawia wartości początkowe:  
  `kolor = "szary"`, `felgi = "stalowe"`, `wyposazenie = [false, false, false]`  
- **Parametrowy** – przyjmuje: kolor, rodzaj felg i tablicę wartości logicznych  

### Metody:
- **ObliczCene()** – zwraca `int`, oblicza cenę auta na podstawie konfiguracji  
- **Opis()** – zwraca `string`, generuje opis wyposażenia oraz sumę do wyświetlenia w polu wyceny  
- **Gettery / Settery** – pozwalają na odczyt i modyfikację pól  

---

## Logika działania aplikacji  

1. **Stan początkowy:**  
   - Kolor: `szary`  
   - Obraz: `szary.png`  
   - Felgi: `stalowe`  
   - Dodatkowe wyposażenie: brak  
   - Wycena:  
     ```
     Cena bazowa: 75000 PLN
     RAZEM: 75000 PLN
     ```

2. **Interakcje użytkownika:**  
   - Zmiana koloru lakieru → aktualizacja obrazu i ceny  
   - Zmiana rodzaju felg → przeliczenie ceny  
   - Zaznaczenie / odznaczenie wyposażenia → natychmiastowa aktualizacja wyceny  

3. **Cennik (na podstawie pliku ceny.txt):**  
   - Kolor lakieru inny niż szary → +9000 PLN  
   - Felgi aluminiowe → +7000 PLN  
   - Czujniki parkowania → +6500 PLN  
   - Climatronic → +8500 PLN  
   - Nawigacja → +5000 PLN  


## Założenia interfejsu użytkownika  

- Interfejs zdefiniowany w **XAML / XML**  
- Układ: **StackLayout / LinearLayout (wertykalny)**  
- Margines wewnętrzny: **10 jednostek**  
- Tło główne: `#E8F5E9`  
- Wysokość obrazu: **150dp**  

### Styl nagłówka:  
- Tekst: „Konfigurator wyposażenia”  
- Kolor tekstu: **biały**  
- Czcionka: **25**, pogrubiona  
- Tło: `#1B5E20`  
- Tekst wyśrodkowany, padding: 5  

### Styl etykiet sekcji:  
- Kolor tekstu: `#5D9B5D`  
- Czcionka: **18**, pogrubiona  
- Tekst wyśrodkowany  
- Margines: 5  

### Lista rozwijana:  
- Wycentrowana, z marginesami bocznymi  

### Grupa przycisków radiowych (felgi):  
- Kolor tła: `#9AEB9A`  
- Układ poziomy (podział szerokości 50/50)  
- „Stalowe” – domyślnie zaznaczone  

### Pole wyceny:  
- Wyrównane do prawej strony  
- Zawiera listę wybranych opcji i końcową sumę  

---

## Wymagania jakościowe  

- Kod zapisany **czytelnie**, zgodnie z zasadami **czystego formatowania**  
- Stosowanie **znaczących nazw zmiennych i metod**  
- Poprawna obsługa zdarzeń  
- Walidacja danych (np. brak błędów przy pustych polach)  
- Dane konfiguracyjne (ceny) wczytywane z pliku `ceny.txt`  
