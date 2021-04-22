-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: academia_lr
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `aluno`
--

DROP TABLE IF EXISTS `aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aluno` (
  `id_aluno` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `nascimento` date DEFAULT NULL,
  `telefone` varchar(12) DEFAULT NULL,
  `whatsapp` varchar(15) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `alunoSexo` int DEFAULT NULL,
  PRIMARY KEY (`id_aluno`),
  KEY `alunoSexo` (`alunoSexo`),
  CONSTRAINT `aluno_ibfk_1` FOREIGN KEY (`alunoSexo`) REFERENCES `genero` (`id_genero`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno`
--

LOCK TABLES `aluno` WRITE;
/*!40000 ALTER TABLE `aluno` DISABLE KEYS */;
INSERT INTO `aluno` VALUES (4,'Arlete Santana','05465118934','1984-05-12','4833696677','48991480381','arletesantana@gmail.com',2),(6,'Antonio Santos','05978514789','1998-08-12','48991480381','48991558877','birrahc@hotmail.com',1),(7,'Júnior cesar de Oliveira','05765118976','1984-03-14','48991480381','48991480381','birrahc@hotmail.com',1),(8,'Claudinir Santos','05365128976','1990-09-21','48991443211','48991483355','clausantos@gmail.com',1),(9,'Valdori Antônio Oliviera','05365128976','1990-09-02','48991443211','48991483355','clausantos@gmail.com',1),(10,'Andre da Rocha','05569878542','1998-11-06','4833695565','48991447865','andrerocha@gmail.com',1),(11,'Osvaldo Antonio dos Santos','05163219965','2000-11-01','4833694455','48991445569','osv@gmail.com',1),(12,'Beatriz Silveira Moniz ','05236948954','1998-06-12','4833697874','48991558874','bea@gmail.com',2),(13,'Raquel Antunes','05978514789','1997-05-22','4833695547','48991558877','raquel@gmail.com',2),(14,'Vinicius César de Oliveira','06709876534','1999-09-22','48991224355','4884343408','vini@gmail.com',1),(15,'Gregorio Santos','05163219965','2000-11-01','4833694455','48991445569','osv@gmail.com',1),(16,'Giovanni','05978514789','1978-06-05','48991487704','48991558877','giovanni@gmail.com',1),(17,'Antonieta de Barros','05236948954','1999-02-15','48991487704','48991558874','alexfarias32@gmail.com',2),(18,'Cristiano Santos','05978514789','1988-03-15','48991487704','48991558874','alexfarias32@gmail.com',1),(19,'Juvencio Santos Saraiva','05978514789','1987-01-22','48991487704','48991558877','alexfarias32@gmail.com',1),(20,'Arthur Correia Santos ','05236948954','1986-05-22','48991487704','48991445569','alexfarias32@gmail.com',1),(21,'Carina Silveira Gonçalves','05978514789','1988-06-15','48991487704','48991558877','alexfarias32@gmail.com',2),(22,'Daniela Dutra Santos','05163219965','1985-03-26','48991487704','48991445569','alexfarias32@gmail.com',2),(23,'Monica Arcanjo Santos','','1988-01-15','48991487704','48991558877','alexfarias32@gmail.com',2),(24,'Cesar Anibal','05236948954','1984-03-15','48991487704','48991558877','alexfarias32@gmail.com',1),(25,'Cesar Anibal','05978514789','1976-03-19','48991487704','48991558877','alexfarias32@gmail.com',1),(26,'Irineu Oliveira','05236948954','1975-05-22','48991487704','48991558874','alexfarias32@gmail.com',1),(27,'Janete Antunes','05978514789','1989-06-15','48991487704','48991558874','alexfarias32@gmail.com',2),(28,'Edinaldo Fonseca','05163219965','1981-01-22','48991487704','48991558877','alexfarias32@gmail.com',1);
/*!40000 ALTER TABLE `aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aluno_turma`
--

DROP TABLE IF EXISTS `aluno_turma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aluno_turma` (
  `id_al_tur` int NOT NULL AUTO_INCREMENT,
  `aluno` int DEFAULT NULL,
  `turma` int DEFAULT NULL,
  `situacao_aluno` int DEFAULT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `atividade` (
  `id_atividade` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classificacao` (
  `id_classificacao` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evento_aluno` (
  `id_ev_al` int NOT NULL AUTO_INCREMENT,
  `evento` int DEFAULT NULL,
  `evento_aluno` int DEFAULT NULL,
  `status_evento` int DEFAULT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventos` (
  `id_evento` int NOT NULL AUTO_INCREMENT,
  `envento_nome` varchar(45) DEFAULT NULL,
  `data_evento` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `Obs` text,
  `evento_status` int DEFAULT NULL,
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
-- Table structure for table `genero`
--

DROP TABLE IF EXISTS `genero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genero` (
  `id_genero` int NOT NULL AUTO_INCREMENT,
  `sexo` char(1) DEFAULT NULL,
  `descricao` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_genero`),
  UNIQUE KEY `sexo` (`sexo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genero`
--

LOCK TABLES `genero` WRITE;
/*!40000 ALTER TABLE `genero` DISABLE KEYS */;
INSERT INTO `genero` VALUES (1,'M','MASCULINO'),(2,'F','FEMININO');
/*!40000 ALTER TABLE `genero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `id_login` int NOT NULL AUTO_INCREMENT,
  `login` varchar(45) DEFAULT NULL,
  `senha` varchar(45) DEFAULT NULL,
  `permissao` int DEFAULT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagamentos` (
  `id_pgt` int NOT NULL AUTO_INCREMENT,
  `fkaluno_pgt` int NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `professor` (
  `idprofessor` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `repeticoestreino` (
  `id_repeticoestreino` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status_evento` (
  `id_st_ev` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status_turma` (
  `id_st` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_treino` (
  `id_tipo_treino` int NOT NULL AUTO_INCREMENT,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `treino` (
  `id_treino` int NOT NULL AUTO_INCREMENT,
  `fktipo` int NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `treino_aluno` (
  `id_treino_aluno` int NOT NULL AUTO_INCREMENT,
  `fkclassificacao` int DEFAULT NULL,
  `fkaluno` int DEFAULT NULL,
  `fktreino` int DEFAULT NULL,
  `quantidade` int DEFAULT NULL,
  `fkrepeticoes` int DEFAULT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turma` (
  `id_turma` int NOT NULL AUTO_INCREMENT,
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

-- Dump completed on 2021-04-22 10:28:43
