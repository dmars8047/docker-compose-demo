INSERT INTO Artists(LookupId, `Name`, Genre, ThumbnailUrl)
VALUES('405f84c0-ee18-4085-8f00-c530d408caea', 'Radiohead', 'Alternative Rock', 'https://en.wikipedia.org/wiki/Radiohead#/media/File:RadioheadMid2010s.jpg');

SET @artistId = LAST_INSERT_ID();

INSERT INTO Albums(LookupId, `Name`, YearReleased, SalesId, ArtistId, ThumbnailUrl)
VALUES ('9c7b7c8c-9d4e-4475-a2de-2b9947455e1c', 'OK Computer', 1997, '3306663b-59d9-4868-950f-0a11d2a4c619', @artistId, 'https://en.wikipedia.org/wiki/OK_Computer#/media/File:Radioheadokcomputer.png');

INSERT INTO Albums(LookupId, `Name`, YearReleased, SalesId, ArtistId, ThumbnailUrl)
VALUES ('7c4cc205-6882-430e-8c59-9b27c611c568', 'Kid A', 2000, '33fc1cc0-a804-456b-913a-3c49ef9cf6d9', @artistId, 'https://en.wikipedia.org/wiki/Kid_A#/media/File:Radioheadkida.png');