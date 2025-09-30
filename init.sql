CREATE TABLE IF NOT EXISTS Reports (
  ReportID INT NOT NULL AUTO_INCREMENT,
  ObstacleName VARCHAR(45) NULL,
  ObstacleHeight DECIMAL(10,0) NULL,
  ObstacleDescription VARCHAR(45) NULL,
  ObstacleLocation LONGTEXT NULL,
  PRIMARY KEY (ReportID)
) ENGINE=InnoDB;