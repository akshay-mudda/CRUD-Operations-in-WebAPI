﻿CREATE TABLE SAMPLE(
id INT NOT NULL PRIMARY KEY IDENTITY,
Column1 NVARCHAR (100),
Column2 DECIMAL (15,5),
Column3 DateTime,
Column4 NVARCHAR (MAX) NOT NULL,
Create_Date DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP
);