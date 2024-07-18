DROP TABLE IF EXISTS `Group`;
CREATE TABLE `Group` (
  `Id` int NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `GroupPermission`;
CREATE TABLE `GroupPermission` (
  `IdGroup` int NOT NULL,
  `IdPermission` int NOT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdGroup`,`IdPermission`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `ImdbEntity`;
CREATE TABLE `ImdbEntity` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ImdbId` varchar(15) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `ImageUrl` varchar(255) NOT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `ImdbEntity` VALUES (1,'tt13433802','A Quiet Place: Day One','https://m.media-amazon.com/images/M/MV5BNGZmODU3ZDEtMjQwZC00NTA5LThmNWYtYzk5MmY5ZmM4NGIxXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(2,'tt10752004','Love Hard','https://m.media-amazon.com/images/M/MV5BODIwNDIxN2YtMWU3ZS00MjU5LWIxMzctNmY1NDg5NDgwYmM0XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(3,'tt11152168','IF','https://m.media-amazon.com/images/M/MV5BYWQ4OGI2MmQtZjUxMC00Njg2LWJiZTQtYmFmZjI5ZmI1Y2U1XkEyXkFqcGdeQXVyMTA1NjE5MTAz._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(4,'tt0119225','Gridlock\'d','https://m.media-amazon.com/images/M/MV5BNWFlYTY1YWUtOWY1Yy00ODgwLTk0YzQtYTdjMDBlOTcwMGZhXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(5,'tt0096438','Who Framed Roger Rabbit','https://m.media-amazon.com/images/M/MV5BMDhiOTM2OTctODk3Ny00NWI4LThhZDgtNGQ4NjRiYjFkZGQzXkEyXkFqcGdeQXVyMTA0MjU0Ng@@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(6,'tt4777008','Maleficent: Mistress of Evil','https://m.media-amazon.com/images/M/MV5BZjJiYTExOTAtNWU0Yi00NzJjLTkwOTgtOTU2NWM1ZjJmYWVhXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(7,'tt0092099','Top Gun','https://m.media-amazon.com/images/M/MV5BZjQxYTA3ODItNzgxMy00N2Y2LWJlZGMtMTRlM2JkZjI1ZDhhXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(8,'tt0105112','Patriot Games','https://m.media-amazon.com/images/M/MV5BOTVhMWNkZDgtMzkzNy00MGJmLThkYzItNWE5YmMxMDAxNTgxXkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(9,'tt0106977','The Fugitive','https://m.media-amazon.com/images/M/MV5BYmFmOGZjYTItYjY1ZS00OWRiLTk0NDgtMjQ5MzBkYWE2YWE0XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55'),(10,'tt0106611','Cool Runnings','https://m.media-amazon.com/images/M/MV5BOGFkZmQyM2EtMzQ4My00NjUzLWE0MGYtYTczNzRhNDQxODUwXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg','2024-07-16 15:42:55','2024-07-16 15:42:55');

DROP TABLE IF EXISTS `ImdbEntityExtra`;
CREATE TABLE `ImdbEntityExtra` (
  `Id` int NOT NULL,
  `ImdbExtraId` varchar(15) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `TitleExtra` varchar(255) DEFAULT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `ImdbUser`;
CREATE TABLE `ImdbUser` (
  `ImdbId` int NOT NULL,
  `UserId` int NOT NULL,
  `Favourite` tinyint DEFAULT '0',
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ImdbId`,`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `Permission`;
CREATE TABLE `Permission` (
  `Id` int NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `Id` int NOT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Surname` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `UserGroup`;
CREATE TABLE `UserGroup` (
  `IdUser` int NOT NULL,
  `IdGroup` int NOT NULL,
  `Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdUser`,`IdGroup`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;