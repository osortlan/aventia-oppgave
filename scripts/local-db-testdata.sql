CREATE DATABASE StreamSessionsDb;
USE StreamSessionsDb;

CREATE TABLE StreamSessions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(100)
);

INSERT INTO StreamSessions (title) VALUES ('kalle'), ('foobar'), ('volvo');