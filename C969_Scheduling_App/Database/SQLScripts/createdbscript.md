# Here are the scripts to create the database and its tables for the C969 Scheduling App.

DROP DATABASE IF EXISTS client_schedule;
CREATE DATABASE client_schedule;
USE client_schedule;

#### User table
-- CREATE TABLE user (
    userId INT AUTO_INCREMENT PRIMARY KEY,
    userName VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    active INT DEFAULT 1,
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    createdBy VARCHAR(255),
    lastUpdate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(255)
); --

-- Country table
CREATE TABLE country (
    countryId INT AUTO_INCREMENT PRIMARY KEY,
    country VARCHAR(255) NOT NULL,
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    createdBy VARCHAR(255),
    lastUpdate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(255)
);

-- City table
CREATE TABLE city (
    cityId INT AUTO_INCREMENT PRIMARY KEY,
    city VARCHAR(255) NOT NULL,
    countryId INT NOT NULL,
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    createdBy VARCHAR(255),
    lastUpdate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(255),
    FOREIGN KEY (countryId) REFERENCES country(countryId)
);

-- Address table
CREATE TABLE `address` (
    addressId INT AUTO_INCREMENT PRIMARY KEY,
    address VARCHAR(255) NOT NULL,
    address2 VARCHAR(255),
    cityId INT NOT NULL,
    postalCode VARCHAR(20),
    phone VARCHAR(20),
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    createdBy VARCHAR(255),
    lastUpdate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(255),
    FOREIGN KEY (cityId) REFERENCES city(cityId)
);

-- Customer table
CREATE TABLE customer (
    customerId INT AUTO_INCREMENT PRIMARY KEY,
    customerName VARCHAR(255) NOT NULL,
    addressId INT NOT NULL,
    active INT DEFAULT 1,
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    createdBy VARCHAR(255),
    lastUpdate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(255),
    FOREIGN KEY (addressId) REFERENCES `address`(addressId)
);

-- Appointment table
CREATE TABLE appointment (
    appointmentId INT AUTO_INCREMENT PRIMARY KEY,
    customerId INT NOT NULL,
    userId INT NOT NULL,
    title VARCHAR(255),
    description TEXT,
    location VARCHAR(255),
    contact VARCHAR(255),
    type VARCHAR(100),
    url VARCHAR(500),
    start DATETIME NOT NULL,
    end DATETIME NOT NULL,
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    createdBy VARCHAR(255),
    lastUpdate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(255),
    FOREIGN KEY (customerId) REFERENCES customer(customerId),
    FOREIGN KEY (userId) REFERENCES user(userId)
);

## Sample Data Insertion
INSERT INTO country (country, createdBy, lastUpdateBy) VALUES
('United States', 'system', 'system'),
('Canada', 'system', 'system'),
('United Kingdom', 'system', 'system'),
('Mexico', 'system', 'system'),
('India', 'system', 'system');

INSERT INTO city (city, countryId, createdBy, lastUpdateBy) VALUES
('New York', 1, 'system', 'system'),
('Los Angeles', 1, 'system', 'system'),
('Chicago', 1, 'system', 'system'),
('Houston', 1, 'system', 'system'),
('Phoenix', 1, 'system', 'system'),
('Toronto', 2, 'system', 'system'),
('Vancouver', 2, 'system', 'system'),
('Montreal', 2, 'system', 'system'),
('London', 3, 'system', 'system'),
('Manchester', 3, 'system', 'system'),
('Mexico City', 4, 'system', 'system'),
('Guadalajara', 4, 'system', 'system'),
('Mumbai', 5, 'system', 'system'),
('Delhi', 5, 'system', 'system');

INSERT INTO user (userName, password, active, createdBy, lastUpdateBy) VALUES
('testuser', 'testpass', 1, 'system', 'system'),
('john.doe', 'password123', 1, 'system', 'system'),
('jane.smith', 'password456', 1, 'system', 'system'),
('admin', 'admin123', 1, 'system', 'system'),
('manager', 'manager123', 1, 'system', 'system');

CREATE USER IF NOT EXISTS 'sqlUser'@'localhost' IDENTIFIED BY 'Passw0rd!';
GRANT ALL PRIVILEGES ON client_schedule.* TO 'sqlUser'@'localhost';
FLUSH PRIVILEGES;
