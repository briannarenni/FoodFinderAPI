SELECT * FROM Menu;
----------
INSERT INTO Menu (item_id, rest_id, item_name, item_price)
SELECT
  ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS item_id,
  id AS rest_id,
  (CASE WHEN RAND() < 0.25 THEN 'Pizza'
        WHEN RAND() < 0.50 THEN 'Hamburger'
        WHEN RAND() < 0.75 THEN 'Salad'
        ELSE 'Soup' END) AS item_name,
  (RAND() * (200 - 0) + 0) AS item_price
FROM Restaurant;
---------
UPDATE Menu
SET item_price = ROUND(RAND(CHECKSUM(NEWID())) * 190 + 10, 2);
-----------
UPDATE Menu
SET item_name = (
  CASE
    WHEN RAND(CHECKSUM(NEWID())) < 0.1 THEN 'Pizza'
    WHEN RAND(CHECKSUM(NEWID())) < 0.2 THEN 'Salad'
    WHEN RAND(CHECKSUM(NEWID())) < 0.3 THEN 'Hamburger'
    WHEN RAND(CHECKSUM(NEWID())) < 0.4 THEN 'Wings'
    WHEN RAND(CHECKSUM(NEWID())) < 0.5 THEN 'Steak'
    WHEN RAND(CHECKSUM(NEWID())) < 0.6 THEN 'Poutine'
    WHEN RAND(CHECKSUM(NEWID())) < 0.7 THEN 'Tiki Marsala'
    WHEN RAND(CHECKSUM(NEWID())) < 0.8 THEN 'Dumplings'
    WHEN RAND(CHECKSUM(NEWID())) < 0.9 THEN 'Tacos'
    WHEN RAND(CHECKSUM(NEWID())) < 1.0 THEN 'Sandwich'
    ELSE 'Panini'
  END
)






