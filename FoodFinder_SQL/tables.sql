CREATE TABLE Restaurant (
  id INT IDENTITY(1,1) PRIMARY KEY,
  rest_name VARCHAR(100) NOT NULL,
  cuisine VARCHAR(50) NOT NULL,
  city VARCHAR(50) NOT NULL
);
---------
CREATE TABLE Rating (
  rating_id INT IDENTITY(1,1) PRIMARY KEY,
  rest_id INT NOT NULL FOREIGN KEY REFERENCES Restaurant(id),
  grade CHAR(1) NOT NULL,
  score INT NOT NULL CHECK (score BETWEEN 0 AND 100),
  score_date DATE NOT NULL
);
---------
CREATE TABLE Menu (
  item_id INT PRIMARY KEY,
  rest_id INT NOT NULL FOREIGN KEY REFERENCES Restaurant(id),
  item_name VARCHAR(50) NOT NULL,
  item_price MONEY CHECK (item_price BETWEEN 0 AND 200)
);
