-- Display the fields id, name, city and cuisine for all the restaurants.
SELECT * FROM Restaurant;
SELECT * From Rating;
SELECT * FROM Menu;

-- Display all the restaurants which are in the city of Orlando.
SELECT * FROM Restaurant
WHERE city = 'Orlando';

-- Display the top 5 restaurants in the state of New York.
SELECT TOP 5 r.rest_name, r.cuisine, r.city, ra.score
FROM Restaurant r
JOIN Rating ra ON r.id = ra.rest_id
WHERE r.city = 'New York City'
ORDER BY ra.score DESC;

-- Display restaurants who achieved a score more than 90.
SELECT r.rest_name, r.cuisine, r.city, ra.score
FROM Restaurant r
JOIN Rating ra ON r.id = ra.rest_id
WHERE ra.score > 90;

-- Display restaurants who achieved a score more than 80 but less than 100.
SELECT r.rest_name, r.cuisine, r.city, ra.score
FROM Restaurant r
JOIN Rating ra ON r.id = ra.rest_id
WHERE ra.score > 80 AND ra.score < 100;

-- Display restaurants that do not prepare any cuisine of 'American' and their score is more than 70.
SELECT r.rest_name, r.cuisine, ra.score
FROM Restaurant r
JOIN Rating ra ON r.id = ra.rest_id
WHERE r.cuisine <> 'American' AND ra.score > 70;

-- Display restaurants that do not prepare any cuisine of 'American', their score is more than 70
-- and the city is Dallas.
SELECT r.rest_name, r.cuisine, r.city
FROM Restaurant r
JOIN Rating ra ON r.id = ra.rest_id
WHERE r.cuisine != 'American' AND ra.score > 70 AND r.city = 'Dallas';

-- Display restaurants which do not prepare any cuisine of 'American', achieved a grade point 'A',
-- and are not from Seattle, according to the cuisine in descending order.
SELECT r.rest_name, r.cuisine, r.city
FROM Restaurant r
JOIN Rating ra ON r.id = ra.rest_id
WHERE r.cuisine != 'American' AND ra.grade = 'A' AND r.city != 'Seattle'
ORDER BY r.cuisine DESC;

-- Display the fields id, name, city and cuisine for all the restaurants
-- that contain the letters "reg" somewhere in its name.
SELECT id, rest_name, city, cuisine
FROM Restaurant
WHERE rest_name LIKE '%reg%';

-- Display restaurants from Los Angeles that serve Italian and Chinese cuisines.
SELECT *
FROM Restaurant
WHERE city = 'Los Angeles' AND cuisine IN ('Italian', 'Chinese');

-- Display restaurants that scored less than 10.
SELECT r.id, r.rest_name, r.city, r.cuisine
FROM Restaurant r
JOIN Rating ON r.id = Rating.rest_id
WHERE Rating.score < 10;

-- Display restaurants that scored an average of more than 50 between 01-Jan-2022 and 30-Jun-2022, in descending order of the score.
SELECT r.id, r.rest_name, r.city, r.cuisine, AVG(rating.score) as avg_score
FROM Restaurant r
JOIN Rating rating ON r.id = rating.rest_id
WHERE rating.score_date BETWEEN '2022-01-01' AND '2022-06-30'
GROUP BY r.id, r.rest_name, r.city, r.cuisine
HAVING AVG(rating.score) > 50
ORDER BY avg_score DESC;

-- Display the restaurant name, cuisine, city, and item, and price,
-- where the item price is over 20.00, and sort in ascending order of price and restaurant name:
SELECT r.rest_name, r.cuisine, r.city, m.item_name, m.item_price
FROM Restaurant r
JOIN Menu m ON r.id = m.rest_id
WHERE m.item_price > 20
ORDER BY m.item_price ASC, r.rest_name ASC;


