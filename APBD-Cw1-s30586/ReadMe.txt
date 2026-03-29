Opis i struktura projektu
System zarządza uczelnianą wypożyczalnią sprzętu. 
Kod podzieliłem na wyraźne warstwy w osobnych folderach: 
Models (dane), 
Services (logika biznesowa), 
Exceptions (własne błędy) 
i Enums. 
Podział ten, jasno oddziela same obiekty od operacji, które na nich wykonujemy, 
a trzymanie każdej klasy w osobnym pliku ułatwia nawigację.

Kohezja
Klasy realizują jedną odpowiedzialność. 
Modele przechowują wyłącznie dane, a cała logika biznesowa znajduje się w Service.

Coupling
Klasy nie wiedzą o sobie więcej, niż to potrzebne. Zamiast operować na konkretnych typach, główny skrypt używa m.in. interfejsów. 