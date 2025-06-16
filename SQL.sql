CREATE DATABASE TrainingPlansDb;
USE TrainingPlansDb;
CREATE TABLE TrainingPlans (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    CreatedAt DATETIME DEFAULT GETDATE(), 
    CreatedBy VARCHAR(50), 
    Description VARCHAR(255), 
    Name VARCHAR(100)
    ); 
SELECT * from TrainingPlans