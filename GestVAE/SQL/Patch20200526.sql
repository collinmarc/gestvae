UPDATE Livret2
SET DateValidite = '01-01-2070' where DateValidite > '01-01-2070'
GO
UPDATE Livret1
SET DateValidite = '01-01-2070' where DateValidite > '01-01-2070'