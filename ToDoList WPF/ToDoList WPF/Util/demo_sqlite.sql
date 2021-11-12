CREATE TABLE IF NOT EXISTS treballador(
    NIF VARCHAR(9) NOT NULL PRIMARY KEY,
    Nom VARCHAR(15) NOT NULL,
    Cognoms VARCHAR(40),
    Telefon VARCHAR(9),
    Correu VARCHAR(50)
)

CREATE TABLE IF NOT EXISTS tasca(
    Codi INT PRIMARY KEY AUTOINCREMENT,
    Titol VARCHAR(20) NOT NULL,
    Descripcio VARCHAR(150),
    dCreacio DATETIME,
    dFinalitz DATETIME,
    Prioritat ENUM("Alta","Mitja","Baixa"),
    Representant VARCHAR(9) ,
    Estat ENUM("ToDo","Doing","Done"),
    FOREIGN KEY (representant) REFERENCES NIF (treballador)
)