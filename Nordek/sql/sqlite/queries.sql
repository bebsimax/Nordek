SELECT N.EntallU, L.Lang, t.Translation FROM Translations AS T
JOIN Nouns_Translations NT on T.ID = NT.TranslationID
JOIN Nouns N on NT.NounID = N.ID
JOIN Languages L on T.LangID = L.ID;

SELECT n.ID, n.EntallU, n.EntallB, n.FlertallU, n.FlertallB, n.Active, n.Regular FROM Nouns n
    JOIN Nouns_Repetitions NR on n.ID = NR.NounID
    JOIN Difficulties D ON D.ID=NR.DifficultyID WHERE NR.DateRepeated;





SELECT * FROM
    (
    SELECT N.*, T.Translation FROM Nouns N
        JOIN Nouns_Translations NT ON N.ID = NT.NounID
        JOIN Translations T on NT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
    WHERE
        L.Lang='english'
        AND N.Active
        AND N.ID IN (
            SELECT NR.NounID as ID FROM Nouns_Repetitions NR
                JOIN Difficulties D ON NR.DifficultyID=D.ID
            GROUP BY NounID
            HAVING
                D.Difficulty='hard' AND DateRepeated =MAX(DateRepeated)
                AND JULIANDAY(DATE())-JULIANDAY(MAX(DateRepeated))>
                    (SELECT DaysToRepeat FROM Difficulties WHERE Difficulty='hard')
            )
    ORDER BY random()
    )
GROUP BY ID;

SELECT * FROM
    (
        SELECT N.*, T.Translation FROM Nouns N
        JOIN Nouns_Translations NT ON N.ID = NT.NounID
        JOIN Translations T on NT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
        WHERE
                L.Lang='english'
          AND N.Active
          AND N.ID IN (
            SELECT NR.NounID as ID FROM Nouns_Repetitions NR
                                            JOIN Difficulties D ON NR.DifficultyID=D.ID
            GROUP BY NounID
            HAVING
                    D.Difficulty='hard' AND DateRepeated =MAX(DateRepeated)
               AND JULIANDAY(DATE())-JULIANDAY(MAX(DateRepeated))>
                   (SELECT DaysToRepeat FROM Difficulties WHERE Difficulty='hard')
        )
        ORDER BY random()
    )
GROUP BY ID;

SELECT * FROM
    (
        SELECT N.*, T.Translation FROM Nouns N
        JOIN Nouns_Translations NT ON N.ID = NT.NounID
        JOIN Translations T on NT.TranslationID = T.ID
        JOIN Languages L on T.LangID = L.ID
        WHERE
              L.Lang='english'
          AND N.Active
          AND N.ID IN (
              SELECT DISTINCT Nouns.ID FROM Nouns
              LEFT JOIN Nouns_Repetitions NR ON Nouns.ID = NR.NounID
            WHERE
                    NR.ID IS NULL AND UserID
        )
        ORDER BY random()
    )
GROUP BY ID;

SELECT COUNT(*) FROM (
SELECT N.ID FROM Nouns N
JOIN Nouns_Repetitions NR on N.ID = NR.NounID
GROUP BY N.ID
HAVING NR.UserID=1 AND NR.DifficultyID=(SELECT ID FROM Difficulties ORDER BY Value ASC LIMIT 1) AND DateRepeated =MAX(DateRepeated));

SELECT DISTINCT Nouns.ID FROM Nouns
LEFT JOIN Nouns_Repetitions NR ON Nouns.ID = NR.NounID
WHERE
NR.ID IS NULL;



SELECT MAX(DateRepeated) as max_date, DATE() AS curdate, JULIANDAY()-JULIANDAY(MAX(DateRepeated)) AS date FROM Nouns_Repetitions NR
    JOIN Difficulties D ON NR.DifficultyID=D.ID
    GROUP BY NounID
    HAVING D.Difficulty='hard' AND DateRepeated = MAX(DateRepeated) 
    AND JULIANDAY()-JULIANDAY(MAX(DateRepeated))> (SELECT DaysToRepeat FROM Difficulties WHERE Difficulty='hard');

SELECT * FROM
    (
        SELECT V.*, T.Translation FROM Verbs V
                                           JOIN Verbs_Translations VT ON V.ID = VT.VerbID
                                           JOIN Translations T on VT.TranslationID = T.ID
                                           JOIN Languages L on T.LangID = L.ID
        WHERE
                L.Lang='english'
          AND V.Active
          AND V.ID IN (
            SELECT DISTINCT VerbID FROM Verbs
                                            LEFT JOIN Verbs_Repetitions VR ON Verbs.ID = VR.VerbID
            WHERE VR.ID IS NULL
        )
        ORDER BY random()
    )
GROUP BY ID;

SELECT DISTINCT V.ID FROM Verbs v
LEFT JOIN Verbs_Repetitions VR ON V.ID = VR.VerbID
WHERE VR.ID IS NULL;

SELECT Translation FROM Translations T
    JOIN Nouns_Translations NT on T.ID = NT.TranslationID
    WHERE T.LangID=(
        SELECT ID FROM Languages WHERE Lang='english'
        ) 
    AND NT.NounID IN
        (
        SELECT NT.NounID FROM Translations T
            JOIN Languages L on T.LangID = L.ID
            JOIN Nouns_Translations NT on T.ID = NT.TranslationID
            WHERE T.LangID=(
                SELECT ID FROM Languages WHERE Lang='polish'
                )
            AND Translation='kaczka'
        );