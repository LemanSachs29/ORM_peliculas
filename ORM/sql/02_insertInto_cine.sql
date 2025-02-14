USE cine;

-- 1. Insertar datos en la tabla de Géneros
INSERT INTO generos (nombre, descripcion) VALUES
('Acción', 'Películas llenas de emocionantes escenas de acción.'),
('Comedia', 'Películas diseñadas para hacer reír.'),
('Drama', 'Películas con historias emocionales y serias.'),
('Ciencia Ficción', 'Películas que exploran conceptos científicos y futuristas.');

-- 2. Insertar datos en la tabla de Películas
INSERT INTO peliculas (titulo, descripcion, fecha_lanzamiento, duracion, rating, idioma) VALUES
('El Padrino', 'La historia de una familia mafiosa en Nueva York.', '1972-03-24', 175, 9.2, 'Inglés'),
('Matrix', 'Un hacker descubre la verdad sobre la realidad.', '1999-03-31', 136, 8.7, 'Inglés'),
('Toy Story', 'Las aventuras de los juguetes de un niño.', '1995-11-22', 81, 8.3, 'Inglés'),
('Inception', 'Un ladrón que roba secretos a través de los sueños.', '2010-07-16', 148, 8.8, 'Inglés');

-- 3. Insertar datos en la tabla de Actores
INSERT INTO actores (nombre, apellido, fecha_nacimiento, nacionalidad) VALUES
('Marlon', 'Brando', '1924-04-03', 'Estadounidense'),
('Keanu', 'Reeves', '1964-09-02', 'Canadiense'),
('Tom', 'Hanks', '1956-07-09', 'Estadounidense'),
('Leonardo', 'DiCaprio', '1974-11-11', 'Estadounidense');

-- 4. Insertar datos en la tabla de Directores
INSERT INTO directores (nombre, apellido, fecha_nacimiento, nacionalidad) VALUES
('Francis Ford', 'Coppola', '1939-04-07', 'Estadounidense'),
('Lana', 'Wachowski', '1965-06-21', 'Estadounidense'),
('John', 'Lasseter', '1957-01-12', 'Estadounidense'),
('Christopher', 'Nolan', '1970-07-30', 'Británico');

-- 5. Insertar datos en la tabla de Productores
INSERT INTO productores (nombre, apellido, fecha_nacimiento, nacionalidad) VALUES
('Albert S.', 'Ruddy', '1930-03-28', 'Canadiense'),
('Joel', 'Silver', '1952-07-14', 'Estadounidense'),
('Darla K.', 'Anderson', '1968-06-23', 'Estadounidense'),
('Emma', 'Thomas', '1971-12-09', 'Británica');

-- 6. Insertar datos en la tabla de Estudios
INSERT INTO estudios (nombre, ubicacion, anio_fundacion) VALUES
('Paramount Pictures', 'Hollywood, California', 1912),
('Warner Bros.', 'Burbank, California', 1923),
('Pixar Animation Studios', 'Emeryville, California', 1986),
('Syncopy', 'Londres, Inglaterra', 2001);

-- 7. Insertar datos en la tabla de Cines
INSERT INTO cines (nombre, direccion, ciudad, pais) VALUES
('Cineplex', '123 Calle Principal', 'Madrid', 'España'),
('AMC Theatres', '456 Avenida Central', 'Nueva York', 'Estados Unidos'),
('Odeon Cinemas', '789 Calle Secundaria', 'Londres', 'Reino Unido'),
('Cinemark', '1011 Avenida Norte', 'Ciudad de México', 'México');

-- 8. Insertar datos en la tabla de Usuarios
INSERT INTO usuarios (nombre, email, contrasena) VALUES
('Juan Pérez', 'juan.perez@example.com', 'password123'),
('Ana Gómez', 'ana.gomez@example.com', 'password456'),
('Carlos Ruiz', 'carlos.ruiz@example.com', 'password789'),
('Laura Sánchez', 'laura.sanchez@example.com', 'password012');

-- 9. Insertar datos en la tabla de Críticos
INSERT INTO criticos (nombre, apellido, afiliacion) VALUES
('Pedro', 'Martínez', 'Cinefilos Magazine'),
('Sofía', 'López', 'Film Review Weekly'),
('Miguel', 'García', 'Cinema Today'),
('Elena', 'Fernández', 'Movie Critics Association');

-- 10. Insertar datos en la tabla de Premios
INSERT INTO premios (nombre, descripcion, anio) VALUES
('Óscar', 'Premio de la Academia de Cine.', 1929),
('Globo de Oro', 'Premio otorgado por la prensa extranjera en Hollywood.', 1944),
('BAFTA', 'Premio de la Academia Británica de Cine.', 1947),
('Palma de Oro', 'Premio del Festival de Cine de Cannes.', 1955);

-- 11. Insertar datos en la tabla de Festivales
INSERT INTO festivales (nombre, ubicacion, fecha_inicio, fecha_fin) VALUES
('Festival de Cannes', 'Cannes, Francia', '2023-05-16', '2023-05-27'),
('Festival de Venecia', 'Venecia, Italia', '2023-08-30', '2023-09-09'),
('Festival de Berlín', 'Berlín, Alemania', '2023-02-16', '2023-02-26'),
('Sundance Film Festival', 'Park City, Utah', '2023-01-19', '2023-01-29');

-- 12. Insertar datos en la tabla intermedia Película - Género
INSERT INTO pelicula_genero (pelicula_id, genero_id) VALUES
(1, 3),  -- El Padrino - Drama
(2, 1),  -- Matrix - Acción
(3, 2),  -- Toy Story - Comedia
(4, 4);  -- Inception - Ciencia Ficción

-- 13. Insertar datos en la tabla intermedia Película - Actor
INSERT INTO pelicula_actor (pelicula_id, actor_id, personaje, orden) VALUES
(1, 1, 'Don Vito Corleone', 1),  -- El Padrino - Marlon Brando
(2, 2, 'Neo', 1),                -- Matrix - Keanu Reeves
(3, 3, 'Woody', 1),              -- Toy Story - Tom Hanks
(4, 4, 'Cobb', 1);               -- Inception - Leonardo DiCaprio

-- 14. Insertar datos en la tabla intermedia Película - Director
INSERT INTO pelicula_director (pelicula_id, director_id) VALUES
(1, 1),  -- El Padrino - Francis Ford Coppola
(2, 2),  -- Matrix - Lana Wachowski
(3, 3),  -- Toy Story - John Lasseter
(4, 4);  -- Inception - Christopher Nolan

-- 15. Insertar datos en la tabla intermedia Película - Productor
INSERT INTO pelicula_productor (pelicula_id, productor_id) VALUES
(1, 1),  -- El Padrino - Albert S. Ruddy
(2, 2),  -- Matrix - Joel Silver
(3, 3),  -- Toy Story - Darla K. Anderson
(4, 4);  -- Inception - Emma Thomas

-- 16. Insertar datos en la tabla intermedia Película - Estudio
INSERT INTO pelicula_estudio (pelicula_id, estudio_id) VALUES
(1, 1),  -- El Padrino - Paramount Pictures
(2, 2),  -- Matrix - Warner Bros.
(3, 3),  -- Toy Story - Pixar Animation Studios
(4, 4);  -- Inception - Syncopy

-- 17. Insertar datos en la tabla de Salas
INSERT INTO salas (cine_id, nombre, capacidad) VALUES
(1, 'Sala 1', 100),
(2, 'Sala 2', 150),
(3, 'Sala 3', 120),
(4, 'Sala 4', 200);

-- 18. Insertar datos en la tabla de Funciones
INSERT INTO funciones (pelicula_id, sala_id, fecha_hora, duracion) VALUES
(1, 1, '2023-10-01 18:00:00', 175),
(2, 2, '2023-10-01 20:00:00', 136),
(3, 3, '2023-10-02 15:00:00', 81),
(4, 4, '2023-10-02 18:00:00', 148);

-- 19. Insertar datos en la tabla de Boletos
INSERT INTO boletos (funcion_id, usuario_id, asiento, precio) VALUES
(1, 1, 'A1', 10.50),
(2, 2, 'B2', 12.00),
(3, 3, 'C3', 8.50),
(4, 4, 'D4', 15.00);

-- 20. Insertar datos en la tabla de Reseñas de Usuarios
INSERT INTO resenas (pelicula_id, usuario_id, rating, comentario) VALUES
(1, 1, 9, 'Una obra maestra del cine.'),
(2, 2, 8, 'Muy buena película, efectos especiales increíbles.'),
(3, 3, 9, 'Divertida y emocionante, perfecta para toda la familia.'),
(4, 4, 9, 'Una película que te hace pensar.');

-- 21. Insertar datos en la tabla de Reseñas de Críticos
INSERT INTO resenas_criticos (pelicula_id, critico_id, rating, comentario) VALUES
(1, 1, 10, 'Una de las mejores películas de todos los tiempos.'),
(2, 2, 9, 'Revolucionaria en su género.'),
(3, 3, 8, 'Una película que marcó un antes y un después en la animación.'),
(4, 4, 9, 'Christopher Nolan vuelve a sorprender con una historia compleja.');

-- 22. Insertar datos en la tabla de Trailers
INSERT INTO trailers (pelicula_id, url, idioma, calidad) VALUES
(1, 'https://www.youtube.com/watch?v=sY1S34973zA', 'Inglés', 'HD'),
(2, 'https://www.youtube.com/watch?v=vKQi3bBA1y8', 'Inglés', '4K'),
(3, 'https://www.youtube.com/watch?v=KYz2wyBy3kc', 'Inglés', 'HD'),
(4, 'https://www.youtube.com/watch?v=YoHD9XEInc0', 'Inglés', '4K');

-- 23. Insertar datos en la tabla intermedia Película - Premio
INSERT INTO pelicula_premio (pelicula_id, premio_id, categoria, anio) VALUES
(1, 1, 'Mejor Película', 1973),
(2, 2, 'Mejor Película - Drama', 2000),
(3, 3, 'Mejor Película de Animación', 1996),
(4, 4, 'Mejor Director', 2011);

-- 24. Insertar datos en la tabla intermedia Película - Festival
INSERT INTO pelicula_festival (pelicula_id, festival_id, screening_date, premio_ganado) VALUES
(1, 1, '1972-05-20', 'Palma de Oro'),
(2, 2, '1999-09-03', 'León de Oro'),
(3, 3, '1995-02-10', 'Oso de Oro'),
(4, 4, '2010-01-21', 'Gran Premio del Jurado');

-- 25. Insertar datos en la tabla de Publicidad
INSERT INTO publicidad (pelicula_id, campaña, presupuesto, fecha_inicio, fecha_fin) VALUES
(1, 'Campaña de relanzamiento', 500000.00, '2023-09-01', '2023-09-30'),
(2, 'Campaña de aniversario', 750000.00, '2023-10-01', '2023-10-31'),
(3, 'Campaña de Navidad', 300000.00, '2023-11-15', '2023-12-25'),
(4, 'Campaña de streaming', 1000000.00, '2023-10-15', '2023-11-15');