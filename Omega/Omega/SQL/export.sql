-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: auto
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `auta`
--

DROP TABLE IF EXISTS `auta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `auta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Znacka` varchar(255) NOT NULL,
  `Rok_vyroby` varchar(255) NOT NULL,
  `Cena` varchar(255) NOT NULL,
  `Vykon` varchar(255) NOT NULL,
  `Historie` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `auta`
--

LOCK TABLES `auta` WRITE;
/*!40000 ALTER TABLE `auta` DISABLE KEYS */;
INSERT INTO `auta` VALUES (1,'Toyota','2020','25000','120','Servisna kniha k dispozicii'),(2,'Audi','2019','30000','150','Jedinecny stav'),(3,'BMW','2021','40000','200','Znackova servisna historia');
/*!40000 ALTER TABLE `auta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motorky`
--

DROP TABLE IF EXISTS `motorky`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motorky` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Znacka` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Rok_vyroby` varchar(50) NOT NULL,
  `Barva` varchar(20) NOT NULL,
  `Cena` varchar(50) NOT NULL,
  `Stav_tachometru` varchar(50) NOT NULL,
  `Pocet_vlastniku` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motorky`
--

LOCK TABLES `motorky` WRITE;
/*!40000 ALTER TABLE `motorky` DISABLE KEYS */;
INSERT INTO `motorky` VALUES (1,'Honda','CBR1000RR','2018','červená','15000','10000','1'),(2,'Suzuki','GSX-R1000R','2020','biela','14500','6000','2'),(3,'Yamaha','YZF-R1M','2021','modrá','23000','500','0');
/*!40000 ALTER TABLE `motorky` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nakladaky`
--

DROP TABLE IF EXISTS `nakladaky`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nakladaky` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Znacka` varchar(255) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Nosnost` varchar(50) NOT NULL,
  `Cena` varchar(50) NOT NULL,
  `Rok_vyroby` varchar(50) NOT NULL,
  `Palivo` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nakladaky`
--

LOCK TABLES `nakladaky` WRITE;
/*!40000 ALTER TABLE `nakladaky` DISABLE KEYS */;
INSERT INTO `nakladaky` VALUES (1,'Volvo','FH16','25000','50000','2019','Diesel'),(2,'MAN','TGX','20000','45000','2018','Diesel'),(3,'Scania','R500','18000','40000','2017','Diesel');
/*!40000 ALTER TABLE `nakladaky` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-21 13:04:12
