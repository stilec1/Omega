create database auto;
use auto;
CREATE TABLE auta (
  id INT NOT NULL AUTO_INCREMENT ,
  Znacka VARCHAR(255) NOT NULL ,
  Rok_vyroby VARCHAR(255) NOT NULL,
  Cena VARCHAR(255) NOT NULL,
  Vykon VARCHAR(255) NOT NULL,
  Historie VARCHAR(255),
  PRIMARY KEY (id));
  
CREATE TABLE motorky (
  id INT NOT NULL AUTO_INCREMENT,
  Znacka VARCHAR(50) NOT NULL,
  Model VARCHAR(50) NOT NULL,
  Rok_vyroby VARCHAR(50) NOT NULL,
  Barva VARCHAR(20) NOT NULL,
  Cena VARCHAR(50) NOT NULL,
  Stav_tachometru VARCHAR(50) NOT NULL,
  Pocet_vlastniku VARCHAR(50) NOT NULL,
  PRIMARY KEY (id)
);

create Table nakladaky (
id INT NOT NULL AUTO_INCREMENT,
  Znacka VARCHAR(255) NOT NULL,
  Model VARCHAR(50) NOT NULL,
  Nosnost VARCHAR(50) NOT NULL,
  Cena VARCHAR(50) NOT NULL,
  Rok_vyroby VARCHAR(50)NOT NULL,
  Palivo VARCHAR(50) NOT NULL,
  PRIMARY KEY (id)
);

INSERT INTO auta (Znacka, Rok_vyroby, Cena, Vykon, Historie) 
VALUES ('Toyota', 2020, 25000, 120, 'Servisna kniha k dispozicii'),
('Audi', 2019, 30000, 150, 'Jedinecny stav'), ('BMW', 2021, 40000, 200, 'Znackova servisna historia');

INSERT INTO motorky (Znacka, Model, Rok_vyroby, Barva, Cena, Stav_tachometru, Pocet_vlastniku) 
VALUES ('Honda', 'CBR1000RR', 2018, 'červená', 15000, 10000, 1),
 ('Suzuki', 'GSX-R1000R', 2020, 'biela', 14500, 6000, 2), 
    ('Yamaha', 'YZF-R1M', 2021, 'modrá', 23000, 500, 0);
  
  INSERT INTO nakladaky (Znacka, Model, Nosnost, Cena, Rok_vyroby, Palivo) 
VALUES ('Volvo', 'FH16', 25000, 50000, 2019, 'Diesel'),
('MAN', 'TGX', 20000, 45000, 2018, 'Diesel'), 
    ('Scania', 'R500', 18000, 40000, 2017, 'Diesel');
    