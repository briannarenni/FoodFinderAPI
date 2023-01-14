SELECT * FROM Rating;
-----------
INSERT INTO Rating (rest_id, grade, score, score_date)
SELECT
  id,
  (CASE WHEN RAND() < 0.25 THEN 'A'
        WHEN RAND() < 0.50 THEN 'B'
        WHEN RAND() < 0.75 THEN 'C'
        ELSE 'D' END) AS grade,
  (RAND() * (100 - 30) + 30) AS score,
  DATEADD(day, RAND() * (266 - 1) + 1, '2022-01-04') AS score_date
FROM Restaurant;
-------------
UPDATE Rating
SET score_date = DATEADD(day, RAND(CHECKSUM(NEWID())) * 365, '2021-11-01')
-------------
BEGIN TRANSACTION

DECLARE @rating_id INT
DECLARE @score INT

DECLARE rating_cursor CURSOR FOR
    SELECT rating_id FROM Rating

OPEN rating_cursor

FETCH NEXT FROM rating_cursor INTO @rating_id

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @score = ROUND((RAND() * 100), 0)

    UPDATE Rating
    SET score = @score
    WHERE rating_id = @rating_id

    FETCH NEXT FROM rating_cursor INTO @rating_id
END

CLOSE rating_cursor
DEALLOCATE rating_cursor

COMMIT TRANSACTION
