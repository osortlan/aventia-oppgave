CREATE DATABASE StreamSessionsDb;
USE StreamSessionsDb;

CREATE TABLE StreamSessions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(100)
);

INSERT INTO StreamSessions (title) VALUES ('Strom styremote fra Steen & Strom'), ('Strom om vassdrag og sterk strom'), ('Vi strommer spising a surstromning');