CREATE TABLE IF NOT EXISTS treballador(
codiT INT PRIMARY KEY NOT NULL AUTOINCREMENT,
nom VARCHAR(20) NOT NULL,
NIF VARCHAR(10) NOT NULL,
cognoms VARCHAR(40),
tel VARCHAR(15),
correu VARCHAR(30)
)

CREATE TABLE  IF NOT EXISTS tasca(
codi INTEGER PRIMARY KEY,
titol TEXT CHECK( LENGTH(titol)>30) NOT NULL,
descripcio TEXT CHECK( LENGTH(descripcio)>150),
dCreacio DATETIME,
dFinalitz DATETIME,
prioritat TEXT CHECK(prioritat IN ("Alta","Mitja","Baixa")),
representant VARCHAR(),
estat TEXT CHECK(estat IN ("ToDo","Doing","Done")),
FOREIGN KEY (representant) REFERENCES nom (treballador)
          )