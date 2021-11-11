CREATE TABLE IF NOT EXISTS treballador(
            NIF VARCHAR(9) NOT NULL PRIMARY KEY,
            nom VARCHAR(15) NOT NULL,
            cognoms VARCHAR(40),
            tel VARCHAR(9),
            correu VARCHAR(50)
                      )

CREATE TABLE IF NOT EXISTS tasca(
            codi INT PRIMARY KEY AUTOINCREMENT,
            titol VARCHAR(20) NOT NULL,
            descripcio VARCHAR(150),
            dCreacio DATETIME,
            dFinalitz DATETIME,
            prioritat ENUM("Alta","Mitja","Baixa"),
            representant VARCHAR(9) ,
            estat ENUM("ToDo","Doing","Done"),
            FOREIGN KEY (representant) REFERENCES NIF (treballador)
          )