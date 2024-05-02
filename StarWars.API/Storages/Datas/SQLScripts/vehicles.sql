CREATE TABLE vehicles (
                          id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                          name VARCHAR(255) NOT NULL,
                          model VARCHAR(255),
                          vehicle_class VARCHAR(255),
                          manufacturer VARCHAR(255),
                          cost_in_credits VARCHAR(255),
                          length VARCHAR(255),
                          crew VARCHAR(255),
                          passengers VARCHAR(255),
                          max_atmosphering_speed VARCHAR(255),
                          cargo_capacity VARCHAR(255),
                          consumables VARCHAR(255),
                          movieId INT DEFAULT NULL,
                          characterId INT DEFAULT NULL
);



CREATE TABLE `vehicles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `model` varchar(255) DEFAULT NULL,
  `vehicle_class` varchar(255) DEFAULT NULL,
  `manufacturer` varchar(255) DEFAULT NULL,
  `cost_in_credits` varchar(255) DEFAULT NULL,
  `length` varchar(255) DEFAULT NULL,
  `crew` varchar(255) DEFAULT NULL,
  `passengers` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `max_atmosphering_speed` varchar(255) DEFAULT NULL,
  `cargo_capacity` varchar(255) DEFAULT NULL,
  `consumables` varchar(255) DEFAULT NULL,
  `movieId` int DEFAULT NULL,
  `characterId` int DEFAULT NULL,
  `film_id` int DEFAULT NULL,
  `character_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `film_id` (`film_id`),
  KEY `character_id` (`character_id`),
  CONSTRAINT `vehicles_ibfk_1` FOREIGN KEY (`film_id`) REFERENCES `movies` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=178 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci