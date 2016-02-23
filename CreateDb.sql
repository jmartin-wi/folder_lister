CREATE DATABASE  IF NOT EXISTS `tree_lister` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `tree_lister`;
-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: tree_lister
-- ------------------------------------------------------
-- Server version	5.6.25-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbltrees`
--

DROP TABLE IF EXISTS `tbltrees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbltrees` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `treeId` varchar(36) DEFAULT NULL,
  `treeName` varchar(50) DEFAULT NULL,
  `treeRoot` varchar(500) DEFAULT NULL,
  `treeCreateDate` varchar(50) DEFAULT NULL,
  `treeComment` varchar(500) DEFAULT NULL,
  `treePart` varchar(50) DEFAULT NULL,
  `treeNodeId` varchar(45) DEFAULT NULL,
  `treeNodeParentId` varchar(45) DEFAULT NULL,
  `treeNodeStatus` varchar(45) DEFAULT NULL,
  `partId` varchar(36) DEFAULT NULL,
  `partName` varchar(500) DEFAULT NULL,
  `partSize` varchar(50) DEFAULT NULL,
  `partPath` varchar(500) DEFAULT NULL,
  `partCreateDate` varchar(50) DEFAULT NULL,
  `partCreateUser` varchar(500) DEFAULT NULL,
  `partCategory` varchar(200) DEFAULT NULL,
  `partSubCategory` varchar(200) DEFAULT NULL,
  `partLocation` varchar(4) DEFAULT NULL,
  `partMime` varchar(50) DEFAULT NULL,
  `partComment` varchar(500) DEFAULT NULL,
  `partViewed` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=235 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-02-02 22:21:39
