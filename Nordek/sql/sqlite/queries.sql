SELECT N.EntallU, L.Lang, t.Translation FROM Translations AS T
JOIN Nouns_Translations NT on T.ID = NT.TranslationID
JOIN Nouns N on NT.NounID = N.ID
JOIN Languages L on T.LangID = L.ID;
