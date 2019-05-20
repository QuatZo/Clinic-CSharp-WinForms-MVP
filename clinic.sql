-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 20 Maj 2019, 13:55
-- Wersja serwera: 10.1.36-MariaDB
-- Wersja PHP: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `clinic`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dawki`
--

CREATE TABLE `dawki` (
  `idd` int(11) NOT NULL,
  `ile` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `dawki`
--

INSERT INTO `dawki` (`idd`, `ile`) VALUES
(5, '3x dziennie'),
(6, '1x dziennie'),
(7, 'po posiłku'),
(8, 'rano'),
(9, 'co 3 dni');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dawki_i_leki`
--

CREATE TABLE `dawki_i_leki` (
  `iddl` int(11) NOT NULL,
  `idd` int(11) NOT NULL,
  `idl` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `dawki_i_leki`
--

INSERT INTO `dawki_i_leki` (`iddl`, `idd`, `idl`) VALUES
(1, 6, 5),
(2, 7, 4),
(4, 6, 3),
(44, 7, 3),
(45, 9, 4),
(46, 6, 1),
(47, 6, 4),
(48, 7, 5),
(49, 9, 3),
(50, 7, 2),
(51, 8, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `doktorzy`
--

CREATE TABLE `doktorzy` (
  `idd` int(11) NOT NULL,
  `imie` varchar(20) NOT NULL,
  `nazwisko` varchar(35) NOT NULL,
  `pesel` varchar(11) NOT NULL,
  `telefon` varchar(9) NOT NULL,
  `gabinet` tinyint(3) UNSIGNED NOT NULL,
  `godziny` enum('poranne','popoludniowe','wieczorowe') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `doktorzy`
--

INSERT INTO `doktorzy` (`idd`, `imie`, `nazwisko`, `pesel`, `telefon`, `gabinet`, `godziny`) VALUES
(13, 'Dawid', 'Mrosek', '97090605938', '290010010', 1, 'poranne');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dok_i_spec`
--

CREATE TABLE `dok_i_spec` (
  `idd` int(11) NOT NULL,
  `ids` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `dok_i_spec`
--

INSERT INTO `dok_i_spec` (`idd`, `ids`) VALUES
(13, 2),
(13, 4),
(13, 5);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `leki`
--

CREATE TABLE `leki` (
  `idl` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `leki`
--

INSERT INTO `leki` (`idl`, `nazwa`) VALUES
(2, 'Apap'),
(5, 'Aspiryna'),
(4, 'Dezaftan'),
(3, 'Etopiryna'),
(1, 'Rutinoscorbin'),
(6, 'Tantum Verde');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pacjenci`
--

CREATE TABLE `pacjenci` (
  `idp` int(11) NOT NULL,
  `imie` varchar(20) NOT NULL,
  `nazwisko` varchar(35) NOT NULL,
  `pesel` varchar(11) NOT NULL,
  `plec` enum('Kobieta','Mężczyzna') NOT NULL,
  `data_urodzenia` date NOT NULL,
  `adres` varchar(60) NOT NULL,
  `telefon` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `pacjenci`
--

INSERT INTO `pacjenci` (`idp`, `imie`, `nazwisko`, `pesel`, `plec`, `data_urodzenia`, `adres`, `telefon`) VALUES
(1, 'Dawid', 'Mrosek', '97090605938', 'Mężczyzna', '1997-09-06', 'Pilsudskiego 2121', '123'),
(2, 'Zdzisław', 'Kręcina', '74030372954', 'Mężczyzna', '2019-05-15', 'Jakas tam ulica 22/222', '123123123'),
(3, 'Maciej', 'Kowik', '97090605921', 'Kobieta', '1973-06-13', 'Jakas tam fajna uliczka 223/32', '111222333'),
(4, 'Andrii', 'Shevchenko', '91082828837', 'Kobieta', '2019-05-08', 'Lwów Polski tak mówia Putina/Miedwiediewa', '989090909');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `specjalizacje`
--

CREATE TABLE `specjalizacje` (
  `ids` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `specjalizacje`
--

INSERT INTO `specjalizacje` (`ids`, `nazwa`) VALUES
(1, 'Alergologia'),
(2, 'Chirurgia'),
(4, 'Geriatria'),
(5, 'Hematologia'),
(8, 'Neurologia'),
(9, 'Seksuologia'),
(10, 'Urologia');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wizyty`
--

CREATE TABLE `wizyty` (
  `idw` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `opis` varchar(512) NOT NULL,
  `idd` int(11) NOT NULL,
  `idp` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `wizyty`
--

INSERT INTO `wizyty` (`idw`, `data`, `opis`, `idd`, `idp`) VALUES
(1, '2019-05-01 11:00:00', 'Tutaj jest jakiś opis, który został wpisany w bazie danych. Jakieś rozeznanie albo, że dawki leku X mają być brane co Y godzin.', 13, 1),
(2, '2019-05-01 06:18:25', 'No i jakiś inny opis, j/w', 13, 1),
(3, '2019-05-21 00:00:00', 'Moim zdaniem to nie ma tak, ze dobrze albo ze nie dobrze. Gdybym mial powiedziec, co cenie w zyciu najbardziej, powiedzialbym, ze ludzi. Ekhm... Ludzi, którzy podali mi pomocna dlon, kiedy sobie nie radzilem, kiedy bylem sam. I co ciekawe, to wlasnie przypadkowe spotkania wplywaja na nasze zycie. Chodzi o to, ze kiedy wyznaje sie pewne wartosci, nawet pozornie uniwersalne, bywa, ze nie znajduje sie zrozumienia, które by tak rzec, które pomaga sie nam rozwijac. Ja mialem szczescie, by tak rzec, poniewaz je z', 13, 1),
(6, '2019-05-05 16:37:43', 'Czy w koncu ta data zadziala?!', 13, 1),
(7, '2019-05-02 16:11:43', 'Data w koncu dziala... Ale czy po zmianie godziny znikna sekundy?', 13, 1),
(8, '2019-05-02 18:37:37', 'Opis (nadpisywany pózniej przez lekarza)', 13, 1),
(9, '2019-05-15 13:01:21', 'Opis (nadpisywany pózniej przez lekarza)', 13, 1),
(10, '2019-05-18 16:05:13', 'Opis (nadpisywany pózniej przez lekarza)', 13, 1),
(11, '2019-05-18 16:06:26', 'Opis (nadpisywany pózniej przez lekarza)', 13, 2),
(12, '2019-05-07 16:10:51', 'Jakis se tam opis jest', 13, 2),
(13, '2019-06-12 16:15:48', 'Opis (nadpisywany pózniej przez lekarza)', 13, 2),
(14, '2019-05-18 16:21:05', 'asdniej przez lekarza)', 13, 1),
(15, '2019-05-18 17:02:50', '123ózniej przez lekarza)', 13, 1),
(16, '2019-06-01 17:03:00', 'Dupa', 13, 1),
(17, '2019-05-28 17:03:36', '23123zxczdasdany pózniej przez lekarza)', 13, 1),
(18, '2019-05-18 17:41:25', 'Ty no ja nie wiem', 13, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wiz_i_dawki_i_leki`
--

CREATE TABLE `wiz_i_dawki_i_leki` (
  `idw` int(11) NOT NULL,
  `iddl` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `wiz_i_dawki_i_leki`
--

INSERT INTO `wiz_i_dawki_i_leki` (`idw`, `iddl`) VALUES
(16, 4),
(16, 46),
(16, 49),
(16, 50);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `dawki`
--
ALTER TABLE `dawki`
  ADD PRIMARY KEY (`idd`),
  ADD UNIQUE KEY `idrecepty_UNIQUE` (`idd`);

--
-- Indeksy dla tabeli `dawki_i_leki`
--
ALTER TABLE `dawki_i_leki`
  ADD PRIMARY KEY (`iddl`),
  ADD UNIQUE KEY `iddl_UNIQUE` (`iddl`),
  ADD KEY `fk_recepta_has_leki_leki1_idx` (`idl`),
  ADD KEY `fk_recepta_has_leki_recepta1_idx` (`idd`);

--
-- Indeksy dla tabeli `doktorzy`
--
ALTER TABLE `doktorzy`
  ADD PRIMARY KEY (`idd`),
  ADD UNIQUE KEY `idlekarz_UNIQUE` (`idd`),
  ADD UNIQUE KEY `pesel_UNIQUE` (`pesel`),
  ADD UNIQUE KEY `gabinet_UNIQUE` (`gabinet`);

--
-- Indeksy dla tabeli `dok_i_spec`
--
ALTER TABLE `dok_i_spec`
  ADD PRIMARY KEY (`idd`,`ids`),
  ADD KEY `fk_lekarz_has_specjalizacja_specjalizacja1_idx` (`ids`),
  ADD KEY `fk_lekarz_has_specjalizacja_lekarz1_idx` (`idd`);

--
-- Indeksy dla tabeli `leki`
--
ALTER TABLE `leki`
  ADD PRIMARY KEY (`idl`),
  ADD UNIQUE KEY `idleki_UNIQUE` (`idl`),
  ADD UNIQUE KEY `nazwa_UNIQUE` (`nazwa`);

--
-- Indeksy dla tabeli `pacjenci`
--
ALTER TABLE `pacjenci`
  ADD PRIMARY KEY (`idp`),
  ADD UNIQUE KEY `idpacjent_UNIQUE` (`idp`),
  ADD UNIQUE KEY `pesel_UNIQUE` (`pesel`);

--
-- Indeksy dla tabeli `specjalizacje`
--
ALTER TABLE `specjalizacje`
  ADD PRIMARY KEY (`ids`),
  ADD UNIQUE KEY `idSpecjalizacja_UNIQUE` (`ids`),
  ADD UNIQUE KEY `nazwa_UNIQUE` (`nazwa`);

--
-- Indeksy dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  ADD PRIMARY KEY (`idw`),
  ADD UNIQUE KEY `idwizyty_UNIQUE` (`idw`),
  ADD KEY `fk_wizyty_lekarz1_idx` (`idd`),
  ADD KEY `fk_wizyty_pacjent1_idx` (`idp`);

--
-- Indeksy dla tabeli `wiz_i_dawki_i_leki`
--
ALTER TABLE `wiz_i_dawki_i_leki`
  ADD PRIMARY KEY (`idw`,`iddl`),
  ADD KEY `fk_wizyty_has_dawki_i_leki_dawki_i_leki1_idx` (`iddl`),
  ADD KEY `fk_wizyty_has_dawki_i_leki_wizyty1_idx` (`idw`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `dawki`
--
ALTER TABLE `dawki`
  MODIFY `idd` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT dla tabeli `dawki_i_leki`
--
ALTER TABLE `dawki_i_leki`
  MODIFY `iddl` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT dla tabeli `doktorzy`
--
ALTER TABLE `doktorzy`
  MODIFY `idd` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT dla tabeli `leki`
--
ALTER TABLE `leki`
  MODIFY `idl` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `pacjenci`
--
ALTER TABLE `pacjenci`
  MODIFY `idp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `specjalizacje`
--
ALTER TABLE `specjalizacje`
  MODIFY `ids` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `idw` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `dawki_i_leki`
--
ALTER TABLE `dawki_i_leki`
  ADD CONSTRAINT `fk_recepta_has_leki_leki1` FOREIGN KEY (`idl`) REFERENCES `leki` (`idl`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_recepta_has_leki_recepta1` FOREIGN KEY (`idd`) REFERENCES `dawki` (`idd`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograniczenia dla tabeli `dok_i_spec`
--
ALTER TABLE `dok_i_spec`
  ADD CONSTRAINT `fk_lekarz_has_specjalizacja_lekarz1` FOREIGN KEY (`idd`) REFERENCES `doktorzy` (`idd`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_lekarz_has_specjalizacja_specjalizacja1` FOREIGN KEY (`ids`) REFERENCES `specjalizacje` (`ids`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograniczenia dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  ADD CONSTRAINT `fk_wizyty_lekarz1` FOREIGN KEY (`idd`) REFERENCES `doktorzy` (`idd`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_wizyty_pacjent1` FOREIGN KEY (`idp`) REFERENCES `pacjenci` (`idp`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograniczenia dla tabeli `wiz_i_dawki_i_leki`
--
ALTER TABLE `wiz_i_dawki_i_leki`
  ADD CONSTRAINT `fk_wizyty_has_dawki_i_leki_dawki_i_leki1` FOREIGN KEY (`iddl`) REFERENCES `dawki_i_leki` (`iddl`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_wizyty_has_dawki_i_leki_wizyty1` FOREIGN KEY (`idw`) REFERENCES `wizyty` (`idw`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
