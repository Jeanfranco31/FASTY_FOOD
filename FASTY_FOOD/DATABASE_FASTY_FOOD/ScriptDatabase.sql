CREATE DATABASE FASTY_FOOD

Create table Rol(
	id INT IDENTITY(1,1) PRIMARY KEY,
	rolname VARCHAR(50) NOT NULL,
	dateRegister DATETIME,
	statusRol BIT
);

Create table Company(
	id INT IDENTITY(1,1) PRIMARY KEY,
	ruc VARCHAR(13) NOT NULL,
	fullName VARCHAR(150) NOT NULL,
	dateRegister DATETIME,
	statusCompany BIT
);

Create table Users(
	id INT IDENTITY(1,1) PRIMARY KEY,
	id_number VARCHAR(10) UNIQUE NOT NULL,
	full_name VARCHAR(150) NOT NULL,
	pass VARCHAR(200) NOT NULL,
	username VARCHAR(20) NOT NULL,
	date_Register DATETIME NOT NULL,
	status_User BIT,
	id_Rol INT REFERENCES ROL(id),
	id_Company INT REFERENCES Company(id)
);

Create table LoginLog(
	id INT IDENTITY(1,1) PRIMARY KEY,
	userName VARCHAR(20) NOT NULL,
	attemp INT,
	date_Logged DATETIME,
	status_Account BIT,
	id_User INT REFERENCES Users(id)
);

Create table MenuOption(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name_Option VARCHAR(50) NOT NULL,
	icon_Name VARCHAR(50) NOT NULL,
	date_Register DATETIME,
	statusOption BIT
);

Create table SubMenu(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nameSubOption VARCHAR(50) NOT NULL,
	date_Register DATETIME,
	idOption INT REFERENCES MenuOption(id)
);

Create table Category(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nameCategory VARCHAR(50) NOT NULL,
	date_Register DATETIME,
	status_Category BIT
);

Create table OrderCustomer(
	id INT IDENTITY(1,1) PRIMARY KEY,
	price DECIMAL(12,2),
	image_Name VARCHAR(150) NOT NULL,
	date_Register DATETIME,
	id_Category INT REFERENCES Category(id),
	id_User INT REFERENCES Users(id)
);

Create table LogOrderCustomer(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idOrderCustomer INT REFERENCES OrderCustomer(id),
	id_User INT REFERENCES Users(id)
);