INSERT INTO `Artikkels` (Artikkel) VALUES
    ('en'),
    ('ei'),
    ('et');

INSERT INTO `Difficulties` (Difficulty, Value) VALUES
    ('trivial', '5'),
    ('easy', '10'),
    ('medium', '15'),
    ('hard', '20');
    
INSERT INTO `Nouns` (ArtikkelID, EntallU, EntallB, FlertallU, FlertallB, Regular) VALUES
    ('2', 'and', 'anda', 'ender', 'endene', 'true'),
    ('2', 'bok', 'boka', 'bøker', 'bøkene', 'true'),
    ('3', 'barn', 'barnet', 'barn', 'barna', 'true'),
    ('3', 'bein', 'beinet', 'bein', 'beina', 'true'),
    ('3', 'besøk', 'besøket', 'besøk', 'besøkene', 'true'),
    ('1', 'bonde', 'bonden', 'bønder', 'bøndene', 'true'),
    ('1', 'bror', 'broren', 'brødre', 'brødrene', 'true'),
    ('2', 'datter', 'dattera', 'døtre', 'døtrene', 'true'),
    ('3', 'eventyr', 'eventyret', 'eventyr', 'eventyrene', 'true'),
    ('1', 'far', 'faren', 'fedre', 'fedrene', 'true'),
    ('1', 'forelder', 'forelderen', 'foreldre', 'foreldrene', 'true'),
    ('3', 'forsøk', 'forsøket', 'forsøk', 'forsøkene', 'true'),
    ('1', 'fot', 'foten', 'føtter', 'føttene', 'true'),
    ('2', 'gulrot', 'gulrota', 'gulrøtter', 'gulrøttene', 'true'),
    ('2', 'gås', 'gåsa', 'gjess', 'gjessene', 'true');

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

INSERT INTO Repetitions (NounID, UserID, DifficultyID, DateCreated, LastUpdated, Count) VALUES 
    ('1', '1', '1', '2021-06-21', '2021-06-21', '5'),
    ('2', '1', '1', '2021-06-21', '2022-03-21', '5'),
                                                                                               
    ('3', '1', '2', '2021-06-21', '2022-01-02', '3'),
    ('4', '1', '2', '2022-03-21', '2022-03-21', '2'),
                                                                                               
    ('5', '1', '3', '2022-03-21', '2022-03-21', '2'),
    ('6', '1', '3', '2022-03-21', '2022-03-21', '5'),
                                                                                               
    ('7', '1', '4', '2022-03-21', '2022-03-21', '5'),
    ('8', '1', '4', '2022-03-21', '2022-03-21', '5');
                                                                                               
                                                                                               