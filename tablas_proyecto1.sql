-- Table: public.cliente


CREATE TABLE "Clientes"
(
  ccedula character varying(9) NOT NULL,
  cusuario character varying(50),
  ccontrasenia character varying(50),
  cnombre_completo character varying(50),
  cedad integer,
  cfecha_nacimiento date NOT NULL,
  ctelefono character varying(12),
  CONSTRAINT "PK_Clientes" PRIMARY KEY (ccedula)
);

-- Table: public.cliente

CREATE TABLE "Empleados"
(
  ecedula  character varying(9) NOT NULL,
  eusuario character varying(50),
  econstrasenia character varying(50),
  enombre_completo character varying(50),
  eedad integer NOT NULL,
  efecha_nacimiento date NOT NULL,
  etelefono character varying(15),
  rol character varying(50),
  CONSTRAINT "PK_Empleados" PRIMARY KEY (ecedula)
);

-- Table: sucursal

CREATE TABLE "Sucursales"
(
  nombre_cine character varying(50) NOT NULL,
  ubicacion character varying(50),
  cantidad_salas integer NOT NULL,
  CONSTRAINT "PK_Sucursales" PRIMARY KEY (nombre_cine)
);

-- Table: public.sala

-- DROP TABLE public.sala;

CREATE TABLE "Salas"
(
  sid character varying(9) NOT NULL,
  nombre_sucursal character varying(50),
  cantidad_columnas integer NOT NULL,
  cantidad_filas integer NOT NULL,
  scapacidad integer NOT NULL,
  CONSTRAINT "PK_Salas" PRIMARY KEY (sid),
  CONSTRAINT sala_sucursal_fk FOREIGN KEY (nombre_sucursal)
      REFERENCES "Sucursales" (nombre_cine) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE "Proyecciones"
(
  proyeccionId SERIAL NOT NULL ,
  horario character varying(50),
  cine character varying(50),
  sala character varying(50),
  CONSTRAINT "PK_Proyecciones" PRIMARY KEY (proyeccionId)
);

CREATE TABLE "Peliculas"
(
  pnombre_original character varying(50) NOT NULL,
  pnombre character varying(50),
  pduracion character varying(50),
  director character varying(50),
  clasificacion character varying(50),
  protagonistas character varying(50),
  pimagen character varying(200),
  CONSTRAINT "PK_Peliculas" PRIMARY KEY (pnombre_original)
);

CREATE TABLE "Facturas"
(
  facturaId integer NOT NULL,
  Cliente character varying(50),
  Sucursal character varying(50),
  Pelicula character varying(50),
  Proyeccion character varying(50),
  Sala character varying(50),
  Asiento character varying(50),
  CONSTRAINT "PK_Facturas" PRIMARY KEY (facturaId)
);