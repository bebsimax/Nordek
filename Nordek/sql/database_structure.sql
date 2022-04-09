DROP DATABASE IF EXISTS `Nordek`;
CREATE DATABASE IF NOT EXISTS `Nordek`;
USE `Nordek`;

CREATE TABLE IF NOT EXISTS `Nouns` (
                                       ID INT PRIMARY KEY AUTO_INCREMENT,
                                       Artikkel INT NOT NULL,
                                       EntallU VARCHAR(50) NOT NULL,
    EntallB VARCHAR(50) NOT NULL,
    FlertallU VARCHAR(50) NOT NULL,
    FlertallB VARCHAR(50) NOT NULL
    );

CREATE TABLE IF NOT EXISTS `Languages` (
                                           ID INT PRIMARY KEY AUTO_INCREMENT,
                                           Lang VARCHAR(30)
    );

CREATE TABLE IF NOT EXISTS `Translations` (
                                              ID INT AUTO_INCREMENT,
                                              NounID INT NOT NULL,
                                              LangID INT NOT NULL,
                                              Translation VARCHAR(50) NOT NULL,
    PRIMARY KEY(ID, NounID, LangID, Translation),
    FOREIGN KEY(NounID) REFERENCES Nouns(ID),
    FOREIGN KEY(LangID) REFERENCES Languages(ID)
    );

INSERT INTO `Nouns` (Artikkel, EntallU, EntallB, FlertallU, FlertallB) VALUES
                                                                           ('2', 'and', 'anda', 'ender', 'endene'),
                                                                           ('2', 'bok', 'boka', 'bøker', 'bøkene'),
                                                                           ('3', 'barn', 'barnet', 'barn', 'barna'),
                                                                           ('3', 'bein', 'beinet', 'bein', 'beina'),
                                                                           ('3', 'besøk', 'besøket', 'besøk', 'besøkene'),
                                                                           ('1', 'bonde', 'bonden', 'bønder', 'bøndene'),
                                                                           ('1', 'bror', 'broren', 'brødre', 'brødrene'),
                                                                           ('2', 'datter', 'dattera', 'døtre', 'døtrene'),
                                                                           ('3', 'eventyr', 'eventyret', 'eventyr', 'eventyrene'),
                                                                           ('1', 'far', 'faren', 'fedre', 'fedrene'),
                                                                           ('1', 'forelder', 'forelderen', 'foreldre', 'foreldrene'),
                                                                           ('3', 'forsøk', 'forsøket', 'forsøk', 'forsøkene'),
                                                                           ('1', 'fot', 'foten', 'føtter', 'føttene'),
                                                                           ('2', 'gulrot', 'gulrota', 'gulrøtter', 'gulrøttene'),
                                                                           ('2', 'gås', 'gåsa', 'gjess', 'gjessene');

INSERT INTO `Languages` (Lang) VALUES
                                   ('english'),
                                   ('polish');

SELECT COUNT(1) FROM Nouns;

INSERT INTO `Translations` (NounID, LangID, Translation) VALUES
                                                             ('1', '1', 'duck'),
                                                             ('1', '2', 'kaczka'),
                                                             ('2', '1', 'book'),
                                                             ('2', '2', 'ksiazka'),
                                                             ('3', '1', 'child'),
                                                             ('3', '2', 'dziecko'),
                                                             ('4', '1', 'leg'),
                                                             ('4', '2', 'noga'),
                                                             ('5', '1', 'visit'),
                                                             ('5', '2', 'wizyta'),
                                                             ('6', '1', 'farmer'),
                                                             ('6', '2', 'rolnik'),
                                                             ('7', '1', 'brother'),
                                                             ('7', '2', 'brat'),
                                                             ('8', '1', 'daugther'),
                                                             ('8', '2', 'córka'),
                                                             ('9', '1', 'adventure'),
                                                             ('9', '2', 'przygoda'),
                                                             ('10', '1', 'father'),
                                                             ('10', '2', 'ojciec'),
                                                             ('11', '1', 'parent'),
                                                             ('11', '2', 'rodzic'),
                                                             ('12', '1', 'attempt'),
                                                             ('12', '2', 'próba'),
                                                             ('13', '1', 'foot'),
                                                             ('13', '2', 'stopa'),
                                                             ('14', '1', 'carrot'),
                                                             ('14', '2', 'marchew'),
                                                             ('15', '1', 'goose'),
                                                             ('15', '2', 'gęś');


SELECT n.EntallU, l.lang, t.translation FROM Nouns n
                                                 JOIN Translations t ON t.NounID=n.ID
                                                 JOIN Languages l ON t.LangID=l.ID
WHERE l.lang = "polish";