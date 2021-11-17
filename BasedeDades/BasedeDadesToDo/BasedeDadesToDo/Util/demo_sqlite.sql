CREATE TABLE IF NOT EXISTS treballador(
    NIF VARCHAR(9) NOT NULL PRIMARY KEY,
    Nom VARCHAR(15) NOT NULL,
    Cognoms VARCHAR(40),
    Telefon VARCHAR(9),
    Correu VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS tasca(
    Codi INTEGER PRIMARY KEY AUTOINCREMENT,
    Titol VARCHAR(20) NOT NULL,
    Descripcio VARCHAR(150),
    dCreacio DATETIME,
    dFinalitz DATETIME,
    Prioritat VARCHAR(5),
    Representant VARCHAR(9),
    Estat VARCHAR(5),
    FOREIGN KEY (representant) REFERENCES NIF (treballador)
);