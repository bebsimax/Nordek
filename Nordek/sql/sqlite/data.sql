﻿INSERT INTO `Difficulties` (Difficulty, Value, DaysToRepeat) VALUES
    ('trivial', '5', '180'),
    ('easy', '10', '14'),
    ('medium', '15', '5'),
    ('hard', '20', '3');
    
INSERT INTO `Nouns` (Artikkel, EntallU, EntallB, FlertallU, FlertallB, Regular) VALUES
    ('ei', 'and', 'anda', 'ender', 'endene', 'false'),
    ('ei', 'bok', 'boka', 'bøker', 'bøkene', 'false'),
    ('et', 'barn', 'barnet', 'barn', 'barna', 'false'),
    ('et', 'bein', 'beinet', 'bein', 'beina', 'false'),
    ('et', 'besøk', 'besøket', 'besøk', 'besøkene', 'false'),
    ('en', 'bonde', 'bonden', 'bønder', 'bøndene', 'false'),
    ('en', 'bror', 'broren', 'brødre', 'brødrene', 'false'),
    ('ei', 'datter', 'dattera', 'døtre', 'døtrene', 'false'),
    ('et', 'eventyr', 'eventyret', 'eventyr', 'eventyrene', 'false'),
    ('en', 'far', 'faren', 'fedre', 'fedrene', 'false'),
    ('en', 'forelder', 'forelderen', 'foreldre', 'foreldrene', 'false'),
    ('et', 'forsøk', 'forsøket', 'forsøk', 'forsøkene', 'false'),
    ('en', 'fot', 'foten', 'føtter', 'føttene', 'false'),
    ('ei', 'gulrot', 'gulrota', 'gulrøtter', 'gulrøttene', 'false'),
    ('ei', 'gås', 'gåsa', 'gjess', 'gjessene', 'false');

INSERT INTO `Languages` (Lang) VALUES
    ('english'),
    ('polish');

INSERT INTO `Translations` (LangID, Translation) VALUES
    ('1', 'duck'),
    ('2', 'kaczka'),
    ('1', 'book'),
    ('2', 'ksiazka'),
    ('1', 'child'),
    ('2', 'dziecko'),
    ('1', 'leg'),
    ('2', 'noga'),
    ('1', 'visit'),
    ('2', 'wizyta'),
    ('1', 'farmer'),
    ('2', 'rolnik'),
    ('1', 'brother'),
    ('2', 'brat'),
    ('1', 'daugther'),
    ('2', 'córka'),
    ('1', 'adventure'),
    ('2', 'przygoda'),
    ('1', 'father'),
    ('2', 'ojciec'),
    ('1', 'parent'),
    ('2', 'rodzic'),
    ('1', 'attempt'),
    ('2', 'próba'),
    ('1', 'foot'),
    ('2', 'stopa'),
    ('1', 'carrot'),
    ('2', 'marchew'),
    ('1', 'goose'),
    ('2', 'gęś');

INSERT INTO `Users` (login) VALUES 
    ('Janusz'),
    ('Ewelina');

INSERT INTO `Nouns_Translations` (NounID, TranslationID) VALUES 
    ('1', '1'),
    ('1', '2'),
    ('2', '3'),
    ('2', '4'),
    ('3', '5'),
    ('3', '6'),
    ('4', '7'),
    ('4', '8'),
    ('5', '9'),
    ('5', '10'),
    ('6', '11'),
    ('6', '12'),
    ('7', '13'),
    ('7', '14'),
    ('8', '15'),
    ('8', '16'),
    ('9', '17'),
    ('9', '18'),
    ('10', '19'),
    ('10', '20'),
    ('11', '21'),
    ('11', '22'),
    ('12', '23'),
    ('12', '24'),
    ('13', '25'),
    ('13', '26'),
    ('14', '27'),
    ('14', '28'),
    ('15', '29'),
    ('15', '30');

INSERT INTO Nouns_Repetitions (NounID, UserID, DifficultyID, DateRepeated) VALUES 
    ('1', '1', '4', '2021-06-21'),
    ('1', '1', '3', '2021-06-22'),
    ('1', '1', '2', '2021-06-23'),
    ('1', '1', '1', '2021-06-24'),
                                                                                  
    ('2', '1', '4', '2021-06-24'),
                                                                                               
    ('3', '1', '2', '2021-06-21'),
    ('4', '1', '2', '2022-03-21'),
                                                                                               
    ('5', '1', '3', '2022-03-21'),
    ('6', '1', '3', '2022-03-21'),

    ('7', '1', '4', '2022-03-19'),
    ('7', '1', '4', '2022-03-20'),                                                                              
    ('7', '1', '4', '2022-03-21'),
                                                                                  
    ('8', '1', '4', '2022-03-21');
                                                                                               
                                                                                               