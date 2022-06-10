﻿CREATE TABLE IF NOT EXISTS `Verbs` (
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
    Infinitiv VARCHAR(2),
    Presens VARCHAR(50),
    Preteritum VARCHAR(50),
    PreteritumPerfektum VARCHAR(50),
    Active BOOLEAN DEFAULT FALSE,
    Regular BOOLEAN DEFAULT FALSE
    );
CREATE INDEX active_index ON Verbs (Active);

CREATE TABLE IF NOT EXISTS `Verbs_Translations` (
    VerbID INTEGER NOT NULL,
    TranslationID INTEGER NOT NULL,
    PRIMARY KEY(VerbID, TranslationID),
    FOREIGN KEY(VerbID) REFERENCES Verbs(ID) ON DELETE CASCADE,
    FOREIGN KEY (TranslationID) REFERENCES Translations(ID) ON DELETE CASCADE
    );
CREATE INDEX translation_VerbID_index ON Verbs_Translations (VerbID);

CREATE TABLE IF NOT EXISTS `Verbs_Synonyms` (
    VerbID_1 INTEGER NOT NULL,
    VerbID_2 INTEGER NOT NULL,
    PRIMARY KEY(VerbID_1, VerbID_2),
    FOREIGN KEY(VerbID_1) REFERENCES Verbs(ID) ON DELETE CASCADE,
    FOREIGN KEY(VerbID_1) REFERENCES Verbs(ID) ON DELETE CASCADE
    );

CREATE TABLE IF NOT EXISTS `Verbs_Repetitions` (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    VerbID INTEGER NOT NULL,
    UserID INTEGER NOT NULL,
    DifficultyID INTEGER NOT NULL,
    DateRepeated DATE NOT NULL,
    FOREIGN KEY(VerbID) REFERENCES Verbs(ID) ON DELETE CASCADE,
    FOREIGN KEY(UserID) REFERENCES Users(ID) ON DELETE CASCADE
    );
CREATE INDEX date_index ON Verbs_Repetitions (DateRepeated, UserID, DifficultyID);