SELECT UserId, Name FROM dbo.Users;
SELECT MedicineId, MedicineName FROM dbo.Medicines;
SELECT * FROM dbo.UserMedicines;
INSERT INTO dbo.UserMedicines
(UserId, MedicineName, Dosage, ReminderTime, TotalQuantity, RemainingQuantity, Status)
VALUES
(3, 'Crocin 500mg', 2, '08:00:00', 10, 10, 'Active'),
(5, 'Ibuprofen', 1, '09:30:00', 5, 5, 'Active'),
(6, 'Metformin', 1, '07:00:00', 30, 30, 'Active'),
(7, 'Aspirin', 1, '10:00:00', 7, 7, 'Active'),
(8, 'Cough Syrup', 2, '06:00:00', 3, 3, 'Active');