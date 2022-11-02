ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `Artists` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `LookupId` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Genre` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ThumbnailUrl` varchar(1024) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Artists` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Albums` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `LookupId` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `YearReleased` int NOT NULL,
    `SalesId` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `ArtistId` int NOT NULL,
    `ThumbnailUrl` varchar(1024) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Albums` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Albums_Artists_ArtistId` FOREIGN KEY (`ArtistId`) REFERENCES `Artists` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE INDEX `IX_Albums_ArtistId` ON `Albums` (`ArtistId`);


CREATE UNIQUE INDEX `IX_Artists_LookupId` ON `Artists` (`LookupId`);

CREATE UNIQUE INDEX `IX_Albums_LookupId` ON `Albums` (`LookupId`);


