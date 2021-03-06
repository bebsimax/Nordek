CREATE TABLE IF NOT EXISTS `Difficulties`(
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
    Difficulty VARCHAR(20) NOT NULL UNIQUE,
    DaysToRepeat INT NOT NULL,
    Value INTEGER NOT NULL UNIQUE
);



CREATE TABLE IF NOT EXISTS `Languages` (
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
    Lang VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS `Translations` (
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
    LangID INTEGER NOT NULL,
    Translation VARCHAR(50) NOT NULL,
    FOREIGN KEY(LangID) REFERENCES Languages(ID)
);
CREATE INDEX langid_index ON Translations (LangID);






CREATE TABLE IF NOT EXISTS `Users` (
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
    login VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS `Active_User` (
    ID INTEGER PRIMARY KEY NOT NULL UNIQUE,
    FOREIGN KEY(ID) REFERENCES Users(ID)
);

