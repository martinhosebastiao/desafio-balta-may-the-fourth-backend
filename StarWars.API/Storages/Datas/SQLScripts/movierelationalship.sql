CREATE TABLE DesafioStarWars.MovieRelationship (
	MovieId INT NOT NULL,
	TargetType TINYINT NOT NULL,
	TargetId INT NOT NULL,
	MovieRelationshipId INT auto_increment NOT NULL,
	CONSTRAINT MovieRelationship_PK PRIMARY KEY (MovieRelationshipId)
);

