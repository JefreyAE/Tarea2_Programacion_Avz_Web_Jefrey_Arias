/*CREATE DATABASE tarea2;*/
use tarea2;

CREATE TABLE buildings(
	id	int IDENTITY(1,1) PRIMARY KEY,
	capacity        int NOT NULL,
	register_date   varchar(100) NOT NULL,
	final_date		varchar(100),
	province        varchar(100) NOT NULL,
	canton			varchar(100) NOT NULL,
	district		varchar(100) NOT NULL,
	bulding_type    varchar(100) NOT NULL
);

CREATE TABLE public_services(
	id int IDENTITY(1,1) PRIMARY KEY,
	name			varchar(100) not null,
	type            varchar(100) not null,
	unit			varchar(100) not null,
	company_name    varchar(100) not null
);

CREATE TABLE building_services(
	id int IDENTITY(1,1) PRIMARY KEY,
	public_services_id  int not null,
	building_id         int not null,
	CONSTRAINT fk_building FOREIGN KEY (building_id) REFERENCES buildings(id),
	CONSTRAINT fk_public_services FOREIGN KEY (public_services_id) REFERENCES public_services(id),
);

SELECT public_services.id, public_services.name, public_services.company_name FROM public_services 
INNER JOIN building_services ON public_services.id = building_services.public_services_id
INNER JOIN buildings ON building_id = building_services.building_id
WHERE buildings.id = 16;