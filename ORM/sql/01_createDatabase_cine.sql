-- 1. Crear la base de datos y usarla
CREATE DATABASE IF NOT EXISTS cine;
USE cine;

-- 2. Tabla de Géneros
CREATE TABLE IF NOT EXISTS generos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    UNIQUE (nombre)
) ENGINE=InnoDB;

-- 3. Tabla de Películas
CREATE TABLE IF NOT EXISTS peliculas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    descripcion TEXT,
    fecha_lanzamiento DATE,
    duracion INT,         -- Duración en minutos
    rating DECIMAL(3,1) DEFAULT 0,
    idioma VARCHAR(50)
) ENGINE=InnoDB;

-- 4. Tabla de Actores
CREATE TABLE IF NOT EXISTS actores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100),
    fecha_nacimiento DATE,
    nacionalidad VARCHAR(100)
) ENGINE=InnoDB;

-- 5. Tabla de Directores
CREATE TABLE IF NOT EXISTS directores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100),
    fecha_nacimiento DATE,
    nacionalidad VARCHAR(100)
) ENGINE=InnoDB;

-- 6. Tabla de Productores
CREATE TABLE IF NOT EXISTS productores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100),
    fecha_nacimiento DATE,
    nacionalidad VARCHAR(100)
) ENGINE=InnoDB;

-- 7. Tabla de Estudios
CREATE TABLE IF NOT EXISTS estudios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    ubicacion VARCHAR(255),
    anio_fundacion YEAR
) ENGINE=InnoDB;

-- 8. Tabla de Cines
CREATE TABLE IF NOT EXISTS cines (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    direccion VARCHAR(255),
    ciudad VARCHAR(100),
    pais VARCHAR(100)
) ENGINE=InnoDB;

-- 9. Tabla de Usuarios
CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    contrasena VARCHAR(255) NOT NULL,
    fecha_registro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- 10. Tabla de Críticos
CREATE TABLE IF NOT EXISTS criticos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100),
    afiliacion VARCHAR(255)
) ENGINE=InnoDB;

-- 11. Tabla de Premios
CREATE TABLE IF NOT EXISTS premios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    descripcion TEXT,
    anio INT
) ENGINE=InnoDB;

-- 12. Tabla de Festivales
CREATE TABLE IF NOT EXISTS festivales (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    ubicacion VARCHAR(255),
    fecha_inicio DATE,
    fecha_fin DATE
) ENGINE=InnoDB;

-- 13. Tabla intermedia: Película - Género
CREATE TABLE IF NOT EXISTS pelicula_genero (
    pelicula_id INT NOT NULL,
    genero_id INT NOT NULL,
    PRIMARY KEY (pelicula_id, genero_id),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (genero_id) REFERENCES generos(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 14. Tabla intermedia: Película - Actor
CREATE TABLE IF NOT EXISTS pelicula_actor (
    pelicula_id INT NOT NULL,
    actor_id INT NOT NULL,
    personaje VARCHAR(100),   -- Nombre del personaje interpretado
    orden INT,                -- Orden en los créditos
    PRIMARY KEY (pelicula_id, actor_id),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (actor_id) REFERENCES actores(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 15. Tabla intermedia: Película - Director
CREATE TABLE IF NOT EXISTS pelicula_director (
    pelicula_id INT NOT NULL,
    director_id INT NOT NULL,
    PRIMARY KEY (pelicula_id, director_id),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (director_id) REFERENCES directores(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 16. Tabla intermedia: Película - Productor
CREATE TABLE IF NOT EXISTS pelicula_productor (
    pelicula_id INT NOT NULL,
    productor_id INT NOT NULL,
    PRIMARY KEY (pelicula_id, productor_id),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (productor_id) REFERENCES productores(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 17. Tabla intermedia: Película - Estudio
CREATE TABLE IF NOT EXISTS pelicula_estudio (
    pelicula_id INT NOT NULL,
    estudio_id INT NOT NULL,
    PRIMARY KEY (pelicula_id, estudio_id),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (estudio_id) REFERENCES estudios(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 18. Tabla de Salas (pantallas) dentro de los cines
CREATE TABLE IF NOT EXISTS salas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cine_id INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    capacidad INT NOT NULL,
    FOREIGN KEY (cine_id) REFERENCES cines(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 19. Tabla de Funciones (proyecciones o showtimes)
CREATE TABLE IF NOT EXISTS funciones (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    sala_id INT NOT NULL,
    fecha_hora DATETIME NOT NULL,
    duracion INT,    -- Duración de la función (en minutos); puede usarse para funciones especiales
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (sala_id) REFERENCES salas(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 20. Tabla de Boletos (tickets)
CREATE TABLE IF NOT EXISTS boletos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    funcion_id INT NOT NULL,
    usuario_id INT,
    asiento VARCHAR(10),
    precio DECIMAL(8,2) NOT NULL,
    fecha_compra TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (funcion_id) REFERENCES funciones(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE SET NULL
) ENGINE=InnoDB;

-- 21. Tabla de Reseñas de Usuarios
CREATE TABLE IF NOT EXISTS resenas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    usuario_id INT NOT NULL,
    rating TINYINT,
    comentario TEXT,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 22. Tabla de Reseñas de Críticos
CREATE TABLE IF NOT EXISTS resenas_criticos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    critico_id INT NOT NULL,
    rating TINYINT,
    comentario TEXT,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (critico_id) REFERENCES criticos(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 23. Tabla de Trailers
CREATE TABLE IF NOT EXISTS trailers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    url VARCHAR(255) NOT NULL,
    idioma VARCHAR(50),
    calidad VARCHAR(50),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 24. Tabla intermedia: Película - Premio
CREATE TABLE IF NOT EXISTS pelicula_premio (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    premio_id INT NOT NULL,
    categoria VARCHAR(100),
    anio INT,
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (premio_id) REFERENCES premios(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 25. Tabla intermedia: Película - Festival
CREATE TABLE IF NOT EXISTS pelicula_festival (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    festival_id INT NOT NULL,
    screening_date DATE,
    premio_ganado VARCHAR(100),
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE,
    FOREIGN KEY (festival_id) REFERENCES festivales(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 26. Tabla de Publicidad (campañas de promoción de películas)
CREATE TABLE IF NOT EXISTS publicidad (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    campaña VARCHAR(255) NOT NULL,
    presupuesto DECIMAL(10,2),
    fecha_inicio DATE,
    fecha_fin DATE,
    FOREIGN KEY (pelicula_id) REFERENCES peliculas(id) ON DELETE CASCADE
) ENGINE=InnoDB;