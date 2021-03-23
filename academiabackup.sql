CREATE DATABASE  IF NOT EXISTS `academia_lr` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `academia_lr`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: academia_lr
-- ------------------------------------------------------
-- Server version	5.6.51-log

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
-- Table structure for table `aluno`
--

DROP TABLE IF EXISTS `aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aluno` (
  `id_aluno` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `nascimento` date DEFAULT NULL,
  `telefone` varchar(12) DEFAULT NULL,
  `whatsapp` varchar(15) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_aluno`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno`
--

LOCK TABLES `aluno` WRITE;
/*!40000 ALTER TABLE `aluno` DISABLE KEYS */;
INSERT INTO `aluno` VALUES (4,'Arlete Santana','05465118934','1980-11-18','4833696677','48991480381','arletesantana@gmail.com'),(6,'Junior',NULL,'1984-03-14','48991480381',NULL,'birrahc@hotmail.com'),(7,'Junior','05765118976','1984-03-14','48991480381','48991480381','birrahc@hotmail.com'),(8,'Claudinir Santos','05365128976','1990-09-21','48991443211','48991483355','clausantos@gmail.com'),(9,'Claudinir Santos','05365128976','1990-09-02','48991443211','48991483355','clausantos@gmail.com');
/*!40000 ALTER TABLE `aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aluno_turma`
--

DROP TABLE IF EXISTS `aluno_turma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aluno_turma` (
  `id_al_tur` int(11) NOT NULL AUTO_INCREMENT,
  `aluno` int(11) DEFAULT NULL,
  `turma` int(11) DEFAULT NULL,
  `situacao_aluno` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_al_tur`),
  KEY `aluno` (`aluno`),
  KEY `turma` (`turma`),
  KEY `situacao` (`situacao_aluno`),
  CONSTRAINT `aluno_turma_ibfk_1` FOREIGN KEY (`aluno`) REFERENCES `aluno` (`id_aluno`),
  CONSTRAINT `aluno_turma_ibfk_2` FOREIGN KEY (`turma`) REFERENCES `turma` (`id_turma`),
  CONSTRAINT `aluno_turma_ibfk_3` FOREIGN KEY (`situacao_aluno`) REFERENCES `status_turma` (`id_st`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno_turma`
--

LOCK TABLES `aluno_turma` WRITE;
/*!40000 ALTER TABLE `aluno_turma` DISABLE KEYS */;
/*!40000 ALTER TABLE `aluno_turma` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `atividade`
--

DROP TABLE IF EXISTS `atividade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `atividade` (
  `id_atividade` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(50) NOT NULL,
  `descricao` varchar(150) NOT NULL,
  `dias_semana_horario` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id_atividade`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atividade`
--

LOCK TABLES `atividade` WRITE;
/*!40000 ALTER TABLE `atividade` DISABLE KEYS */;
INSERT INTO `atividade` VALUES (1,'Funcional, Hit','Ginastica, Aerobico, Hit','Segunda, Quarta e Sexta das 08:00 as 09:00 Sabado das 09:00 as 10:00');
/*!40000 ALTER TABLE `atividade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classificacao`
--

DROP TABLE IF EXISTS `classificacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classificacao` (
  `id_classificacao` int(11) NOT NULL AUTO_INCREMENT,
  `desc_classificacao` char(1) DEFAULT NULL,
  PRIMARY KEY (`id_classificacao`),
  UNIQUE KEY `desc_classificacao` (`desc_classificacao`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classificacao`
--

LOCK TABLES `classificacao` WRITE;
/*!40000 ALTER TABLE `classificacao` DISABLE KEYS */;
INSERT INTO `classificacao` VALUES (1,'A'),(2,'B'),(3,'C'),(4,'D'),(5,'E');
/*!40000 ALTER TABLE `classificacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evento_aluno`
--

DROP TABLE IF EXISTS `evento_aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `evento_aluno` (
  `id_ev_al` int(11) NOT NULL AUTO_INCREMENT,
  `evento` int(11) DEFAULT NULL,
  `evento_aluno` int(11) DEFAULT NULL,
  `status_evento` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_ev_al`),
  KEY `evento` (`evento`),
  KEY `evento_aluno` (`evento_aluno`),
  KEY `status_evento` (`status_evento`),
  CONSTRAINT `evento_aluno_ibfk_1` FOREIGN KEY (`evento`) REFERENCES `eventos` (`id_evento`),
  CONSTRAINT `evento_aluno_ibfk_2` FOREIGN KEY (`evento_aluno`) REFERENCES `aluno` (`id_aluno`),
  CONSTRAINT `evento_aluno_ibfk_3` FOREIGN KEY (`status_evento`) REFERENCES `status_evento` (`id_st_ev`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento_aluno`
--

LOCK TABLES `evento_aluno` WRITE;
/*!40000 ALTER TABLE `evento_aluno` DISABLE KEYS */;
/*!40000 ALTER TABLE `evento_aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventos`
--

DROP TABLE IF EXISTS `eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eventos` (
  `id_evento` int(11) NOT NULL AUTO_INCREMENT,
  `envento_nome` varchar(45) DEFAULT NULL,
  `data_evento` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `Obs` text,
  `evento_status` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_evento`),
  KEY `evento_status` (`evento_status`),
  CONSTRAINT `eventos_ibfk_1` FOREIGN KEY (`evento_status`) REFERENCES `status_evento` (`id_st_ev`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventos`
--

LOCK TABLES `eventos` WRITE;
/*!40000 ALTER TABLE `eventos` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login` (
  `id_login` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(45) DEFAULT NULL,
  `senha` varchar(45) DEFAULT NULL,
  `permissao` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_login`),
  UNIQUE KEY `login` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES (1,'jrc','$1$i0P8Mi5W$WNQM6V1.03tryB8CwuOwe.',NULL),(2,'joaca','$1$IA5SO9nm$NLnNUMyWUm19czdYZo1FH0',NULL),(3,'birra','202cb962ac59075b964b07152d234b70',NULL);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagamentos`
--

DROP TABLE IF EXISTS `pagamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagamentos` (
  `id_pgt` int(11) NOT NULL AUTO_INCREMENT,
  `fkaluno_pgt` int(11) NOT NULL,
  `data_pgt` date DEFAULT NULL,
  `ref_data_in` date DEFAULT NULL,
  `ref_data_fi` date DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `desconto` double DEFAULT NULL,
  `observacao` text,
  PRIMARY KEY (`id_pgt`),
  KEY `aluno_pgt` (`fkaluno_pgt`),
  CONSTRAINT `pagamentos_ibfk_1` FOREIGN KEY (`fkaluno_pgt`) REFERENCES `aluno` (`id_aluno`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamentos`
--

LOCK TABLES `pagamentos` WRITE;
/*!40000 ALTER TABLE `pagamentos` DISABLE KEYS */;
INSERT INTO `pagamentos` VALUES (2,9,'2021-02-09','2021-03-09','2021-04-09',180,15,'Pagamento referente ao mes de Março'),(3,6,'2021-02-09','2021-02-09','2021-03-09',150,10,'Pagamento referente ao mes de fevereiro');
/*!40000 ALTER TABLE `pagamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professor`
--

DROP TABLE IF EXISTS `professor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professor` (
  `idprofessor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `nascimento` date DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `whatsapp` varchar(15) DEFAULT NULL,
  `email` varchar(60) DEFAULT NULL,
  `formacao` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`idprofessor`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professor`
--

LOCK TABLES `professor` WRITE;
/*!40000 ALTER TABLE `professor` DISABLE KEYS */;
INSERT INTO `professor` VALUES (1,'Junior','1984-03-14','05765118976','48991480381','48991480381','birrahc@hotmail.com','Bacharel em Educação Fisica'),(4,'Vadico Santos Saraiva','1974-09-19','05765118976','48991776655','48991765544','vadico@hotmail.com','Doutor em Educação Fisica'),(5,'Samira Antunes','1984-09-19','05765118976','48991776655','48991765544','sami@hotmail.com','mestre em Educação Fisica');
/*!40000 ALTER TABLE `professor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repeticoestreino`
--

DROP TABLE IF EXISTS `repeticoestreino`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `repeticoestreino` (
  `id_repeticoestreino` int(11) NOT NULL AUTO_INCREMENT,
  `desc_repeticao` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id_repeticoestreino`),
  UNIQUE KEY `desc_repeticao` (`desc_repeticao`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repeticoestreino`
--

LOCK TABLES `repeticoestreino` WRITE;
/*!40000 ALTER TABLE `repeticoestreino` DISABLE KEYS */;
INSERT INTO `repeticoestreino` VALUES (5,'10x'),(1,'2x'),(2,'4x'),(3,'6x'),(4,'8x');
/*!40000 ALTER TABLE `repeticoestreino` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status_evento`
--

DROP TABLE IF EXISTS `status_evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `status_evento` (
  `id_st_ev` int(11) NOT NULL AUTO_INCREMENT,
  `situacao_evento` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_st_ev`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status_evento`
--

LOCK TABLES `status_evento` WRITE;
/*!40000 ALTER TABLE `status_evento` DISABLE KEYS */;
/*!40000 ALTER TABLE `status_evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status_turma`
--

DROP TABLE IF EXISTS `status_turma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `status_turma` (
  `id_st` int(11) NOT NULL AUTO_INCREMENT,
  `situacao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_st`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status_turma`
--

LOCK TABLES `status_turma` WRITE;
/*!40000 ALTER TABLE `status_turma` DISABLE KEYS */;
INSERT INTO `status_turma` VALUES (1,'Ativo'),(2,'Inativo');
/*!40000 ALTER TABLE `status_turma` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_treino`
--

DROP TABLE IF EXISTS `tipo_treino`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_treino` (
  `id_tipo_treino` int(11) NOT NULL AUTO_INCREMENT,
  `descricao_tipo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_tipo_treino`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_treino`
--

LOCK TABLES `tipo_treino` WRITE;
/*!40000 ALTER TABLE `tipo_treino` DISABLE KEYS */;
INSERT INTO `tipo_treino` VALUES (1,'HIPERMETROPIA'),(2,'RESISTÊNCIA MUSCULAR'),(3,'POTÊNCIA MUSCULAR'),(4,'FORÇA MUSCULAR'),(5,'HIT');
/*!40000 ALTER TABLE `tipo_treino` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `treino`
--

DROP TABLE IF EXISTS `treino`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `treino` (
  `id_treino` int(11) NOT NULL AUTO_INCREMENT,
  `fktipo` int(11) NOT NULL,
  `descricao` varchar(150) NOT NULL,
  PRIMARY KEY (`id_treino`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `treino`
--

LOCK TABLES `treino` WRITE;
/*!40000 ALTER TABLE `treino` DISABLE KEYS */;
INSERT INTO `treino` VALUES (2,1,'Biceps Com Corda'),(3,3,'Triceps com barra'),(4,1,'Supino Inclinado');
/*!40000 ALTER TABLE `treino` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `treino_aluno`
--

DROP TABLE IF EXISTS `treino_aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `treino_aluno` (
  `id_treino_aluno` int(11) NOT NULL AUTO_INCREMENT,
  `fkclassificacao` int(11) DEFAULT NULL,
  `fkaluno` int(11) DEFAULT NULL,
  `fktreino` int(11) DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `fkrepeticoes` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_treino_aluno`),
  KEY `fkclassificacao` (`fkclassificacao`),
  KEY `fkaluno` (`fkaluno`),
  KEY `fktreino` (`fktreino`),
  KEY `fkrepeticoes` (`fkrepeticoes`),
  CONSTRAINT `treino_aluno_ibfk_1` FOREIGN KEY (`fkclassificacao`) REFERENCES `classificacao` (`id_classificacao`),
  CONSTRAINT `treino_aluno_ibfk_2` FOREIGN KEY (`fkaluno`) REFERENCES `aluno` (`id_aluno`),
  CONSTRAINT `treino_aluno_ibfk_3` FOREIGN KEY (`fktreino`) REFERENCES `treino` (`id_treino`),
  CONSTRAINT `treino_aluno_ibfk_4` FOREIGN KEY (`fkrepeticoes`) REFERENCES `repeticoestreino` (`id_repeticoestreino`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `treino_aluno`
--

LOCK TABLES `treino_aluno` WRITE;
/*!40000 ALTER TABLE `treino_aluno` DISABLE KEYS */;
INSERT INTO `treino_aluno` VALUES (2,1,4,2,9,2);
/*!40000 ALTER TABLE `treino_aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turma`
--

DROP TABLE IF EXISTS `turma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `turma` (
  `id_turma` int(11) NOT NULL AUTO_INCREMENT,
  `turma_nome` varchar(60) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`id_turma`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turma`
--

LOCK TABLES `turma` WRITE;
/*!40000 ALTER TABLE `turma` DISABLE KEYS */;
INSERT INTO `turma` VALUES (1,'Turma',160);
/*!40000 ALTER TABLE `turma` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-03-23 12:35:42
