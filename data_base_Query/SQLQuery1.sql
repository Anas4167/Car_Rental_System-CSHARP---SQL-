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

INSERT INTO CUSTOMERS 
(CustomerID, FirstName, LastName, PhoneNumber,  Email, Password, Address)
VALUES
(20, 'Ahmed', 'Nur', '0623456789', 'ahmed@gmail.com', 'pass123', 'Hargeisa'),
(3, 'Fatima', 'Ali', '0634567890', 'fatima@gmail.com', 'pass123', 'Bosaso'),
(4, 'Asha', 'Mohamed', '0645678901', 'asha@gmail.com', 'pass123', 'Kismayo'),
(5, 'Omar', 'Farah', '0656789012', 'omar@gmail.com', 'pass123', 'Baidoa'),
(6, 'Hodan', 'Ismail', '0667890123', 'hodan@gmail.com', 'pass123', 'Garowe'),
(2, 'Ali', 'Hassan', '0612345678', 'ali@gmail.com', 'pas1234', 'Mogadishu');

INSERT INTO CARS 
(CarID, CarName, Brand, Model, YearMade, PlateNumber, PricePerDay, Status)
VALUES
(1, 'Corolla', 'Toyota', 'XLI', 2020, 'ABC123', 30.00, 'Available'),
(2, 'Civic', 'Honda', 'EX', 2019, 'DEF456', 35.00, 'Available'),
(3, 'Camry', 'Toyota', 'SE', 2021, 'GHI789', 50.00, 'Rented'),
(4, 'Accent', 'Hyundai', 'GLS', 2018, 'JKL012', 25.00, 'Available'),
(5, 'X5', 'BMW', 'Sport', 2022, 'MNO345', 100.00, 'Rented'),
(6, 'Rav4', 'Toyota', 'Limited', 2021, 'PQR678', 60.00, 'Available');


INSERT INTO EMPLOYEES 
(EmployeeID, FirstName, LastName, PositionName, PhoneNumber, Salary)
VALUES
(1, 'Abdi', 'Karim', 'Manager', '0611111111', 800.00),
(2, 'Said', 'Omar', 'Clerk', '0622222222', 400.00),
(3, 'Layla', 'Hussein', 'Accountant', '0633333333', 600.00),
(4, 'Yusuf', 'Ali', 'Driver', '0644444444', 300.00),
(5, 'Maryan', 'Nur', 'Receptionist', '0655555555', 350.00),
(6, 'Hassan', 'Ahmed', 'Cleaner', '0666666666', 200.00);

INSERT INTO RENTALS 
(RentalID, CustomerID, CarID, RentDate, ReturnDate, TotalAmount)
VALUES
(1, 1, 3, '2026-04-01', '2026-04-05', 200.00),
(2, 2, 5, '2026-04-02', '2026-04-06', 400.00),
(3, 3, 1, '2026-04-03', NULL, 150.00),
(4, 4, 2, '2026-04-04', '2026-04-07', 180.00),
(5, 5, 4, '2026-04-05', NULL, 120.00),
(6, 6, 6, '2026-04-06', '2026-04-10', 300.00);


INSERT INTO PAYMENTS 
(PaymentID, RentalID, PaymentDate, PaymentMethod, AmountPaid)
VALUES
(1, 1, '2026-04-05', 'Cash', 200.00),
(2, 2, '2026-04-06', 'Card', 400.00),
(3, 3, '2026-04-03', 'Cash', 150.00),
(4, 4, '2026-04-07', 'Card', 180.00),
(5, 5, '2026-04-05', 'Cash', 120.00),
(6, 6, '2026-04-10', 'Card', 300.00);


ALTER TABLE RENTALS
ADD CONSTRAINT CHK_ReturnDate
CHECK (ReturnDate IS NULL OR ReturnDate >= RentDate);

UPDATE CARS
SET Status = 'Rented'
WHERE CarID = 1;

SELECT RentalID, ReturnDate 
FROM RENTALS
WHERE RentalID = 5





CREATE PROCEDURE GetAllRentals
AS
BEGIN
    SELECT 
        r.RentalID,
        r.CustomerID,
        r.CarID,
        c.FirstName + ' ' + c.LastName AS CustomerName,
        ca.CarName,
        r.RentDate,
        r.ReturnDate,
        r.TotalAmount
    FROM RENTALS r
    JOIN CUSTOMERS c ON r.CustomerID = c.CustomerID
    JOIN CARS ca ON r.CarID = ca.CarID
END


GO
CREATE TRIGGER trg_UpdateCarStatus
ON RENTALS
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE CARS
    SET Status = 'Rented'
    WHERE CarID IN (
        SELECT CarID FROM inserted WHERE ReturnDate IS NULL
    )

    UPDATE CARS
    SET Status = 'Available'
    WHERE CarID IN (
        SELECT CarID FROM inserted WHERE ReturnDate IS NOT NULL
    )
END
GO