

CREATE DATABASE AngularCrudApp;
GO

USE AngularCrudApp;
GO 

CREATE TABLE [dbo].[tblCountry] (
    [CountryId] INT IDENTITY (1, 1) NOT NULL primary Key,
    [CountryName] VARCHAR (50) NULL ,
    IsActive bit Default (1),
	CreatedDate Datetime Default (getdate())
);
GO

-----Insert Dummy Countries---



INSERT INTO tblCountry(CountryName) 
VALUES('USA');
GO


---- Create State Table

CREATE TABLE [dbo].[tblState] (
    [StateId] INT IDENTITY (1, 1) Primary Key NOT NULL,
    [StateName] VARCHAR (50) NULL,
    [CountryId] INT NOT NULL 
	 FOREIGN KEY ([CountryId]) REFERENCES tblCountry([CountryId]),
	 IsActive bit default (1),
	 CreatedDate datetime default (Getdate())

  );

  GO


  DECLARE @Countryidusa int
  SELECT  @Countryidusa=[CountryId] FROM tblCountry WHERE Countryname='USA';

  INSERT INTO [tblState](StateName,CountryId) VALUES('Washington DC',@Countryidusa);


  GO
  
  --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : get Active Countries 
  -- Syntex: Execute sp_getCountries
  --=================================
  CREATE PROCEDURE sp_getCountries
  AS 
  BEGIN 
		SELECT CountryId, CountryName FROM tblCountry WHERE IsActive=1
  END ;

  GO

    
  --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : insert Countries or  Update Countries if exists
  -- Syntex(Update): Execute Sp_insertUpdateCountries  'RUSSIA',3
  -- Syntex(Insert): Execute Sp_insertUpdateCountries  'USA'
  --=================================
  CREATE PROCEDURE Sp_insertUpdateCountries
  (  
	@CountryName VARCHAR (50),
	@CountryId INT =null
  )
  AS 
  BEGIN 
		IF(ISNULL(@CountryId , 0 )>0 )
		BEGIN

			UPDATE tblCountry SET 	CountryName=@CountryName 
			WHERE CountryId=@CountryId
		END 
		ELSE
		BEGIN
				
			INSERT INTO tblCountry(CountryName)
			VALUES(@CountryName);

		END
		
		SELECT CountryId, CountryName FROM tblCountry WHERE IsActive=1
  END 
  
  GO
      
  --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : Active Country
  -- Syntex: Execute Sp_inActiveCountry  5
  --=================================
  CREATE PROCEDURE Sp_inActiveCountry
  (  
	@CountryId INT 
  )
  AS 
  BEGIN 

			UPDATE tblCountry SET IsActive=0
			WHERE CountryId=@CountryId;
		
		
		SELECT CountryId, CountryName FROM tblCountry WHERE IsActive=1
  END 
GO
--=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : get Country by id 
  -- Syntex: Execute Sp_getCountryById  5
  --=================================
  CREATE PROCEDURE Sp_getCountryById
  (  
	@CountryId INT 
  )
  AS 
  BEGIN 

		 
		SELECT CountryId, CountryName FROM tblCountry WHERE IsActive=1 and CountryId=@CountryId
  END 
GO

    
	  
  --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : get Active States 
  -- Syntex: Execute sp_getStates
  --=================================
  CREATE PROCEDURE sp_getStates
  AS 
  BEGIN 
		SELECT StateId, ST.StateName, ST.CountryId, CountryName FROM tblState AS ST
		INNER JOIN tblCountry AS CT ON CT.CountryId=ST.CountryId AND CT.IsActive=1
		WHERE ST.IsActive=1
  END 
  GO


    --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : get Active States 
  -- Syntex: Execute sp_getStateById 1
  --=================================
  CREATE PROCEDURE sp_getStateById
   (  
	@StateId INT 
  )
  AS  
  BEGIN 
		SELECT StateId, ST.StateName, ST.CountryId, CountryName FROM tblState AS ST
		INNER JOIN tblCountry AS CT ON CT.CountryId=ST.CountryId AND CT.IsActive=1
		WHERE ST.IsActive=1 and StateId=@StateId
  END 
  GO

  --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : insert States or  Update States if exists
  -- Syntex(Update): Execute Sp_insertUpdateStates 'California', 1,1
  -- Syntex(Insert): Execute Sp_insertUpdateStates  'Washington',1
  --=================================
  CREATE PROCEDURE Sp_insertUpdateStates
  (  
	@StateName VARCHAR (50),
	@CountryId INT ,
	@StateId INT =null
  )
  AS 
  BEGIN 
		IF(ISNULL(@StateId , 0 )>0 )
		BEGIN

			UPDATE tblState SET StateName=@StateName ,CountryId=@CountryId
			WHERE StateId=@StateId;
		END 
		ELSE
		BEGIN
				
			INSERT INTO tblState(StateName,CountryId)
			VALUES(@StateName,@CountryId);

		END
		
			SELECT StateId, ST.StateName, ST.CountryId, CountryName FROM tblState AS ST
			INNER JOIN tblCountry AS CT ON CT.CountryId=ST.CountryId AND CT.IsActive=1
			WHERE ST.IsActive=1
  END 

  GO
    
  --=================================
  --Author : inder
  --Date : 2022-04-04 
  --Purpose : Active States
  -- Syntex: Execute Sp_inActiveState  1
  --=================================
  CREATE PROCEDURE Sp_inActiveState
  (  
	@StateId INT 
  )
  AS 
  BEGIN 

			UPDATE tblState SET IsActive=0
			WHERE StateId=@StateId;
		
		
			SELECT StateId, ST.StateName, ST.CountryId, CountryName FROM tblState AS ST
			INNER JOIN tblCountry AS CT ON CT.CountryId=ST.CountryId AND CT.IsActive=1
			WHERE ST.IsActive=1
  END 

