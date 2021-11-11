CREATE TABLE IF NOT EXISTS treballador(
            nom TEXT CHECK(LENGTH(nom)>20) PRIMARY KEY,
            NIF TEXT CHECK(LENGTH(NIF)>10) NOT NULL,
            cognoms TEXT CHECK(LENGTH(cognoms)>40),
            tel TEXT CHECK(LENGTH(tel)>15),
            correu TEXT CHECK(LENGTH(correu)>30)
                      )

CREATE TABLE  IF NOT EXISTS tasca(
            codi INTEGER PRIMARY KEY AUTOINCREMENT,
            titol TEXT CHECK( LENGTH(titol)>30) NOT NULL,
            descripcio TEXT CHECK( LENGTH(descripcio)>150),
            dCreacio DATETIME,
            dFinalitz DATETIME,
            prioritat TEXT CHECK(prioritat IN ("Alta","Mitja","Baixa")),
            representant TEXT,
            estat TEXT CHECK(estat IN ("ToDo","Doing","Done")),
            FOREIGN KEY (representant) REFERENCES nom (treballador)
          )