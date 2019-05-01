-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 01 Maj 2019, 13:10
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
  `idl` int(11) NOT NULL,
  `od_kiedy` date DEFAULT NULL,
  `do_kiedy` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `dawki_i_leki`
--

INSERT INTO `dawki_i_leki` (`iddl`, `idd`, `idl`, `od_kiedy`, `do_kiedy`) VALUES
(2, 6, 2, '2019-05-09', '2019-05-30'),
(3, 5, 1, '2019-05-01', '2019-05-31'),
(4, 7, 6, '2019-07-12', '2019-10-18'),
(5, 8, 4, '2019-05-02', '2019-05-04');

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
(13, 'Dawid', 'Mrosek', '97090605938', '123', 123, 'poranne');

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
(1, 'Dawid', 'Mrosek', '97090605938', 'Mężczyzna', '1997-09-06', 'Mrosek', '502609296');

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
  `idp` int(11) NOT NULL,
  `iddl` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Zrzut danych tabeli `wizyty`
--

INSERT INTO `wizyty` (`idw`, `data`, `opis`, `idd`, `idp`, `iddl`) VALUES
(1, '2019-05-01 11:00:00', 'Tutaj jest jakiś opis, który został wpisany w bazie danych. Jakieś rozeznanie albo, że dawki leku X mają być brane co Y godzin.', 13, 1, 3),
(2, '2019-05-01 06:18:25', 'No i jakiś inny opis, j/w', 13, 1, 5);

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
  ADD UNIQUE KEY `idrecepta_has_leki_UNIQUE` (`iddl`),
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
  ADD KEY `fk_wizyty_pacjent1_idx` (`idp`),
  ADD KEY `fk_wizyty_recepta_i_leki1_idx` (`iddl`);

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
  MODIFY `iddl` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

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
  MODIFY `idp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `specjalizacje`
--
ALTER TABLE `specjalizacje`
  MODIFY `ids` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `idw` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

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
  ADD CONSTRAINT `fk_wizyty_pacjent1` FOREIGN KEY (`idp`) REFERENCES `pacjenci` (`idp`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_wizyty_recepta_i_leki1` FOREIGN KEY (`iddl`) REFERENCES `dawki_i_leki` (`iddl`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
