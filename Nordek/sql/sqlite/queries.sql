SELECT N.EntallU, L.Lang, t.Translation FROM Translations AS T
JOIN Nouns_Translations NT on T.ID = NT.TranslationID
JOIN Nouns N on NT.NounID = N.ID
JOIN Languages L on T.LangID = L.ID;

SELECT n.ID, n.EntallU, n.EntallB, n.FlertallU, n.FlertallB, n.Active, n.Regular FROM Nouns n
    JOIN Nouns_Repetitions NR on n.ID = NR.NounID
    JOIN Difficulties D ON D.ID=NR.DifficultyID WHERE NR.DateRepeated;

SELECT * FROM Nouns WHERE ID IN (
SELECT NR.NounID as ID FROM Nouns_Repetitions NR 
JOIN Difficulties D ON NR.DifficultyID=D.ID
GROUP BY NounID
HAVING D.Difficulty='hard' AND DateRepeated =MAX(DateRepeated));