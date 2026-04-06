SELECT TOP (1000) [BookModelId]
      ,[BookName]
      ,[Title]
      ,[Price]
  FROM [BookDatabase].[dbo].[tblBooks]
  alter table tblBooks
  add Author NVARCHAR(100);
  	SELECT TOP (10) * FROM tblBooks WHERE Price IS NULL;
update tblBooks set Author='Unknown' where Author is null;