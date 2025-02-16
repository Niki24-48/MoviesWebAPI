CREATE DATABASE movies_x;
USE movies_x;

-- Tabla de géneros (Clave primaria STRING)
CREATE TABLE genres (
    id VARCHAR(50) PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- Tabla de directores (Clave primaria STRING)
CREATE TABLE directors (
    id VARCHAR(50) PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    birth_year INT,
    nationality VARCHAR(100)
);

-- Tabla de películas
CREATE TABLE movies (
    id INT PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    release_year YEAR,
    genre_id VARCHAR(50),
    director_id VARCHAR(50),
    rating DECIMAL(3,1),
    box_office BIGINT,
    FOREIGN KEY (genre_id) REFERENCES genres(id),
    FOREIGN KEY (director_id) REFERENCES directors(id)
);

-- Tabla de actores
CREATE TABLE actors (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    birth_year DATE NULL,
    nationality VARCHAR(100)
);

-- Tabla de relación entre películas y actores
CREATE TABLE movie_cast (
    movie_id INT,
    actor_id INT,
    role VARCHAR(100),
    PRIMARY KEY (movie_id, actor_id),
    FOREIGN KEY (movie_id) REFERENCES movies(id),
    FOREIGN KEY (actor_id) REFERENCES actors(id)
);

-- Inserts para géneros
INSERT INTO genres (id, name) VALUES
('action', 'Action'),
('comedy', 'Comedy'),
('drama', 'Drama'),
('sci-fi', 'Science Fiction');

-- Inserts para directores
INSERT INTO directors (id, name, birth_year, nationality) VALUES
('nolan', 'Christopher Nolan', 1970, 'British'),
('tarantino', 'Quentin Tarantino', 1963, 'American'),
('spielberg', 'Steven Spielberg', 1946, 'American');

-- Inserts para películas
INSERT INTO movies (title, release_year, genre_id, director_id, rating, box_office) VALUES
('Inception', 2010, 'sci-fi', 'nolan', 8.8, 829895144),
('Pulp Fiction', 1994, 'drama', 'tarantino', 8.9, 213928762),
('Jurassic Park', 1993, 'sci-fi', 'spielberg', 8.1, 1045400000);

-- Inserts para actores
INSERT INTO actors (name, birth_year, nationality) VALUES
('Leonardo DiCaprio', '1974-01-01', 'American'),
('Samuel L. Jackson', '1948-01-01', 'American'),
('Jeff Goldblum', '1952-01-01', 'American');

-- Inserts para el reparto de películas
INSERT INTO movie_cast (movie_id, actor_id, role) VALUES
(1, 1, 'Dom Cobb'),
(2, 2, 'Jules Winnfield'),
(3, 3, 'Dr. Ian Malcolm');
