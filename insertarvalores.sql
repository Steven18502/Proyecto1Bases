INSERT INTO public."Peliculas"(
            pnombre_original, pnombre, pduracion, director, clasificacion, 
            protagonistas, pimagen)
    VALUES ('Kung Fu Panda', 'El Panda Ninja', '120 min', 'Tim Burton', 'D', 
            'Jackie Chan', 'url...'),
            ('Pulp Fiction', 'Tiempos Violentos', '154 min', 'Quentin Tarantino', 'C', 
            'John Travolta, Samuel L. Jackson', 'url...'),
            ('The Shining', 'El Resplandor', '146 min', 'Stanley Kubrick', 'C', 
            'Jack Nicholson, Shelley Duval', 'url...');

INSERT INTO public."Proyecciones"(
            horario, cine, sala)
    VALUES ('1:00-3:20', 'Cinema A', '2A'),
	('7:00-9:30', 'Cinema B', '1B'),
	('5:00-7:00', 'Cinema C', '2C');

INSERT INTO public."Sucursales"(
            nombre_cine, ubicacion, cantidad_salas)
    VALUES ('Cinema A', 'Cartago', '8'),
	('Cinema B', 'San José', '15'),
	('Cinema C', 'Limón', '5');

INSERT INTO public."Empleados"(
            ecedula, eusuario, econstrasenia, enombre_completo, eedad, efecha_nacimiento, 
            etelefono, rol)
    VALUES ('205640021', 'rodrigallo@gmail.com', 'contra1234', 'Rodrigo Gallo', 20, '2001-03-14', 
            '81888856', 'Cajero'),
            ('100677891', 'luisaperico@gmail.com', '1234contra', 'Luisa Perico', 34, '1986-11-15', 
            '64565578', 'Administradora'),
            ('110268879', 'jaimemorado@live.com', 'saprissa35', 'Jaime Mora', 18, '2003-03-16', 
            '85123697', 'Miseláneo');

INSERT INTO public."Clientes"(
            ccedula, cusuario, ccontrasenia, cnombre_completo, cedad, cfecha_nacimiento, 
            ctelefono)
    VALUES ('495151169', 'lau88@gmail.com', '489a84da9', 'Laura Castillo', 26, '1995-05-17', 
            '66978413'),
            ('143457896', 'david89@gmail.com', '22daas', 'David Meza', 19, '2001-12-18', 
            '87894211'),
            ('178946631', 'mariellei@live.com', 'nosemeocurreunaclave', 'Mariel Ibarra', 51, '1970-08-19', 
            '79451122');
