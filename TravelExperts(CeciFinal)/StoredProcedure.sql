create procedure InsertPkgDetail
@ProductID int,
@SupplierID int,
@PackageID int

AS

INSERT INTO [dbo].[Packages_Products_Suppliers]
([PackageId], [ProductSupplierId])
VALUES
(@PackageID, (SELECT [ProductSupplierId] 
FROM [Products_Suppliers]
WHERE [ProductId]=@ProductID AND [SupplierId]=@SupplierID))




