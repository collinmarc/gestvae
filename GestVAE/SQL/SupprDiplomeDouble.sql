UPDATE DiplomeCands
Set bDeleted = 1, AttSup = 'Suppression Diplome en double'
WHERE id IN (
    SELECT id FROM DiplomeCands d1
    WHERE (SELECT COUNT(*) FROM diplomeCands d2 WHERE d2.candidat_id = d1.candidat_id AND d2.id > d1.id) < 2
    AND d1.candidat_id IN (
        SELECT candidat_id FROM DiplomeCands GROUP BY candidat_id HAVING COUNT(*) >= 2
    )
);