-- Eliminamos la BD si ya existiera
GO
	DROP DATABASE IF EXISTS ComidasDB;
GO

-- Creacion la BD
GO
	CREATE DATABASE ComidasDB;
GO

-- Usamos la BD
GO
	USE ComidasDB;
GO

-- Creamos las tablas de la BD
GO
	CREATE TABLE Comida(
		Id INT NOT NULL PRIMARY KEY IDENTITY,
		Nombre VARCHAR(50),
		ImagenUrl VARCHAR(500),
		Descripcion VARCHAR(1000),
		FechaFinVigencia DATETIME
	);

	CREATE TABLE Ingrediente(
		Id INT NOT NULL PRIMARY KEY IDENTITY,
		Nombre VARCHAR(50),
		ImagenUrl VARCHAR(500),
		FechaFinVigencia DATETIME
	);

	CREATE TABLE ComidaIngrediente(
		ComidaId INT,
		IngredienteId INT,
		CONSTRAINT FK_ComidaId FOREIGN KEY (ComidaId) REFERENCES Comida(Id),
		CONSTRAINT FK_IngredienteId FOREIGN KEY (IngredienteId) REFERENCES Ingrediente(Id),
		PRIMARY KEY(ComidaId, IngredienteId)
	);
GO

-- Agregamos algunos campos de ejemplo
GO
	INSERT INTO Comida VALUES ('Hamburguesa', 'https://www.clarin.com/img/2022/05/27/la-hamburguesa-mucho-mas-que___0HXb0UR0v_340x340__1.jpg', 'Sandwich de hamburguesa con pan de papa blando. La hamburguesa esta hecha a base de carne vacuna picada. En esta version se acompaña de queso cheddar y salsa bbc.', NULL);
	INSERT INTO Comida VALUES ('Pizza Muzza', 'https://www.clarin.com/img/2022/06/24/la-pizza-de-muzzarella-clasico___n9YGrfD3a_340x340__1.jpg', 'Comida que consiste en una base de masa de pan, generalmente delgada y redonda, que se recubre con salsa de tomate y queso mozzarella y se cuece al horno.', NULL);
	INSERT INTO Comida VALUES ('Completo italiano', 'https://www.concepcionchile.cl/images_content/receta-completo-italiano.jpg', 'Bocadillo tradicional de Chile que consiste en un pan de hot dog,  abierto a lo largo, con una vienesa en el medio sobre la cual se coloca tomate picado, palta y mayonesa', NULL);

	INSERT INTO Ingrediente VALUES ('Pan de Hamburguesa', 'https://d1kxxrc2vqy8oa.cloudfront.net/wp-content/uploads/2020/04/22211859/RFB-1903-4-pandehamburguesa.jpg', NULL);
	INSERT INTO Ingrediente VALUES ('Queso cheddar', 'https://www.lacasadelqueso.com.ar/wp-content/uploads/2017/07/queso-cheddar-color-intenso.jpg', NULL);
	INSERT INTO Ingrediente VALUES ('Salsa BBC', 'https://www.recetasderechupete.com/wp-content/uploads/2022/02/Salsa-barbacoa-cuenco-cristal.jpg', NULL);

	INSERT INTO Ingrediente VALUES ('Prepizza', 'https://img-global.cpcdn.com/recipes/0cd9f859a460894c/400x400cq70/photo.jpg', NULL);
	INSERT INTO Ingrediente VALUES ('Salsa para pizza', 'https://cuk-it.com/wp-content/uploads/2019/03/thumb03-1-1024x576-1-1.jpg', NULL);
	INSERT INTO Ingrediente VALUES ('Queso muzzarella', 'https://www.nutricienta.com/imagenes/alimentos/alimento-nutricienta-queso-mozzarella.jpg', NULL);

	INSERT INTO Ingrediente VALUES ('Pan de Pancho', 'https://cocinatis.com/media/photologue/photos/cache/CTIS0627-receta-como-hacer-pan-de-hot-dog_large_16x9.jpg', NULL);
	INSERT INTO Ingrediente VALUES ('Salchicha', 'https://www.65ymas.com/uploads/s1/54/70/05/bigstock-german-raw-frankfurter-sausage-408980690_1_621x621.jpeg', NULL);
	INSERT INTO Ingrediente VALUES ('Tomate', 'https://encolombia.com/wp-content/uploads/2021/11/Tomate-fruto-330x205.jpg', NULL);
	INSERT INTO Ingrediente VALUES ('Palta', 'https://assets.iprofesional.com/cdn-cgi/image/w=880,f=webp/https://assets.iprofesional.com/assets/png/2021/01/510787.png', NULL);
	INSERT INTO Ingrediente VALUES ('Mayonesa', 'https://i.blogs.es/1f6fbb/mayonesa1/450_1000.jpg', NULL);
GO

-- Agregamos las relaciones
GO
	INSERT INTO ComidaIngrediente VALUES ( 1, 1);
	INSERT INTO ComidaIngrediente VALUES ( 1, 2);
	INSERT INTO ComidaIngrediente VALUES ( 1, 3);

	INSERT INTO ComidaIngrediente VALUES ( 2, 4);
	INSERT INTO ComidaIngrediente VALUES ( 2, 5);
	INSERT INTO ComidaIngrediente VALUES ( 2, 6);
	
	INSERT INTO ComidaIngrediente VALUES ( 3, 7);
	INSERT INTO ComidaIngrediente VALUES ( 3, 8);
	INSERT INTO ComidaIngrediente VALUES ( 3, 9);
	INSERT INTO ComidaIngrediente VALUES ( 3, 10);
	INSERT INTO ComidaIngrediente VALUES ( 3, 11);
GO

-- Querys utilizadas en el codigo
GO
	SELECT * FROM Comida C WHERE C.FechaFinVigencia IS NULL;

	SELECT * FROM Comida C WHERE C.Id = 1 AND C.FechaFinVigencia IS NULL;
GO

GO
	TRUNCATE TABLE ComidaIngrediente;
	TRUNCATE TABLE Comida;
	TRUNCATE TABLE Ingrediente;
GO