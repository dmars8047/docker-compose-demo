ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `SalesData` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `LookupId` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `UnitsSold` int NOT NULL,
    `TotalRevenue` int NOT NULL,
    CONSTRAINT `PK_SalesData` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE UNIQUE INDEX `IX_SalesData_LookupId` ON `SalesData` (`LookupId`);


