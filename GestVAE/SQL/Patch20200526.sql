UPDATE Livret2
SET DateValidite = '31-12-2020' where DateValidite > '01-01-2070'
GO
UPDATE Livret1
SET DateValidite = '31-12-2020' where DateValidite > '01-01-2070'