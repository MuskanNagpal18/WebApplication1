USE MedicineDB;

INSERT INTO dbo.Users (Name, Email, PasswordHash, Role)
VALUES ('Admin User', 'admin@gmail.com', '123', 'admin');
USE MedicineDB;
DELETE FROM dbo.Users;
INSERT INTO dbo.Users (Name, Email, PasswordHash, Role)
VALUES ('Admin', 'admin@gmail.com', '123', 'admin');