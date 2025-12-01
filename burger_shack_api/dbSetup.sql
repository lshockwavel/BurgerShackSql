CREATE TABLE IF NOT EXISTS burgers (
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(100) NOT NULL,
  description TEXT,
  price DECIMAL(10,2) NOT NULL,
  isAvailable BOOLEAN DEFAULT TRUE
  );

  CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) DEFAULT charset utf8mb4 COMMENT '';



INSERT INTO burgers (name, description, price, isAvailable) VALUES
('Classic Burger', 'A juicy beef patty with lettuce, tomato, and our special sauce.', 8.99, TRUE),
('Cheeseburger', 'A classic burger topped with melted cheddar cheese.', 9.49, TRUE),
('Bacon Burger', 'A beef patty topped with crispy bacon and BBQ sauce.', 10.49, TRUE),
('Veggie Burger', 'A delicious vegetarian patty with fresh veggies and avocado.', 9.99, TRUE),
('Mushroom Swiss Burger', 'A beef patty topped with sautéed mushrooms and Swiss cheese.', 10.99, TRUE);




SELECT * FROM burgers;

SELECT * FROM burgers WHERE id = 1;

