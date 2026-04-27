# 🚗 Car Rental Management System (C# + SQL Server)

A **Car Rental Management System** developed using **C# (WinForms)** and **SQL Server** to manage customers, cars, rentals, and payments efficiently.

---

## 📌 Features

* 👤 Manage Customers (Add, Update, Delete)
* 🚘 Manage Cars (Add, Update, Delete)
* 👨‍💼 Manage Employees
* 📅 Rent and Return Cars
* 💰 Track Payments
* 🔄 Automatic Car Status Update (Available / Rented)
* 🧾 View Rental Records with Customer & Car Details
* 🔐 Authentication system (Login/Register)

---

## 🛠️ Technologies Used

* 💻 C# (Windows Forms)
* 🗄️ SQL Server
* 🔗 ADO.NET

---

## 🗂️ Database Design

### 📊 Tables

* **CUSTOMERS**

  * CustomerID (PK)
  * FirstName, LastName
  * PhoneNumber, Email, Password
  * Address

* **CARS**

  * CarID (PK)
  * CarName, Brand, Model
  * YearMade, PlateNumber
  * PricePerDay
  * Status (Available / Rented)

* **EMPLOYEES**

  * EmployeeID (PK)
  * FirstName, LastName
  * PositionName
  * PhoneNumber, Salary

* **RENTALS**

  * RentalID (PK)
  * CustomerID (FK)
  * CarID (FK)
  * RentDate, ReturnDate
  * TotalAmount

* **PAYMENTS**

  * PaymentID (PK)
  * RentalID (FK)
  * PaymentDate
  * PaymentMethod
  * AmountPaid

---

## ⚙️ Database Logic

### 🔹 Stored Procedure

**GetAllRentals**

* Retrieves rental data with:

  * Customer name
  * Car name
  * Rental details

---

### 🔹 Trigger

**trg_UpdateCarStatus**

Automatically updates car status:

* `ReturnDate IS NULL` → **Rented**
* `ReturnDate IS NOT NULL` → **Available**

---

### 🔹 Constraint

* Ensures:

  * `ReturnDate >= RentDate`

---

## 🚀 Future Improvements

* 📊 Reports (PDF/Charts)
* 🌐 Web version (ASP.NET / MERN)
* 💳 Online payment integration

---

## 👨‍💻 Author

**Anas Abdullaahi**
🔗 GitHub: https://github.com/Anas4167

---

## ⭐ Support

If you find this project useful, give it a ⭐ on GitHub!

---

## 📄 License

This project is for educational purposes.
