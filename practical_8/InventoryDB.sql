IF DB_ID(N'InventoryDB') IS NULL 
    CREATE DATABASE InventoryDB; 
GO 
 
USE InventoryDB; 
GO 
 
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL 
BEGIN 
    CREATE TABLE dbo.Products 
    ( 
        ProductId INT IDENTITY(1,1) PRIMARY KEY, 
        ProductName NVARCHAR(100) NOT NULL, 
        Category NVARCHAR(60) NOT NULL, 
        Quantity INT NOT NULL CONSTRAINT CK_Products_Quantity CHECK (Quantity >= 
0), 
        UnitPrice DECIMAL(12,2) NOT NULL CONSTRAINT CK_Products_UnitPrice CHECK 
(UnitPrice >= 0), 
        Description NVARCHAR(500) NULL, 
        CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Products_CreatedAt DEFAULT 
SYSUTCDATETIME() 
    ); 
END; 
GO 
 
IF NOT EXISTS (SELECT 1 FROM dbo.Products) 
BEGIN 
    INSERT INTO dbo.Products (ProductName, Category, Quantity, UnitPrice, 
Description) 
    VALUES 
    (N'Wireless Mouse', N'Electronics', 25, 599.00, N'Wireless USB mouse'), 
    (N'USB Keyboard', N'Electronics', 4, 799.00, N'Full-size USB keyboard'), 
    (N'Notebook', N'Stationery', 100, 45.00, N'A4 ruled notebook'); 
END; 
GO 
