CREATE DATABASE Car_Rental_Management

USE Car_Rental_Management


-- 1. Create CUSTOMERS Table
CREATE TABLE CUSTOMERS (
    CustomerID Int PRIMARY KEY,
    FirstName Varchar(100) NOT NULL,
    LastName Varchar(100) NOT NULL,
    PhoneNumber Varchar(20) NOT NULL,
    Email Varchar(150) NOT NULL,
	Password varchar(150) not null,
    Address Varchar(255) NOT NULL
); 

-- 2. Create CARS Table
CREATE TABLE CARS (
    CarID Int PRIMARY KEY,
    CarName Varchar(100) NOT NULL,
    Brand Varchar(100) NOT NULL,
    Model Varchar(100) NOT NULL,
    YearMade Int NOT NULL,
    PlateNumber Varchar(50) UNIQUE,
    PricePerDay Decimal(10,2) NOT NULL,
    Status Varchar(30) NOT NULL
); 

-- 3. Create EMPLOYEES Table
CREATE TABLE EMPLOYEES (
    EmployeeID Int PRIMARY KEY,
    FirstName Varchar(100) NOT NULL,
    LastName Varchar(100) NOT NULL,
    PositionName Varchar(100) NOT NULL,
    PhoneNumber Varchar(20) NOT NULL,
    Salary Decimal(10,2) NOT NULL
);

-- 4. Create RENTALS Table
CREATE TABLE RENTALS (
    RentalID Int PRIMARY KEY,
    CustomerID Int,
    CarID Int,
    RentDate Date NOT NULL,
    ReturnDate Date NULL,
    TotalAmount Decimal(10,2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMERS(CustomerID),
    FOREIGN KEY (CarID) REFERENCES CARS(CarID)
);

-- 5. Create PAYMENTS Table
CREATE TABLE PAYMENTS (
    PaymentID Int PRIMARY KEY,
    RentalID Int,
    PaymentDate Date NOT NULL,
    PaymentMethod Varchar(50) NOT NULL,
    AmountPaid Decimal(10,2) NOT NULL,
    FOREIGN KEY (RentalID) REFERENCES RENTALS(RentalID)
); 

SELECT *FROM PAYMENTS