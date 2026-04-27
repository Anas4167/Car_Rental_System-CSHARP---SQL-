<<<<<<< HEAD
# 🚗 Car Rental Management System

A **Car Rental Management System** built to manage car rentals efficiently.
This system allows users to rent cars, return them, and manage customers, vehicles, and rental records.

---

## 📌 Features

* 🔐 User-friendly interface (WinForms)
* 🚘 Manage cars (Add, Update, Delete)
* 👤 Manage customers
* 📅 Rent and return cars
* 💰 Automatic total cost calculation
* 🔄 Car status update (Available / Rented)
* 🧾 View rental history

---

## 🛠️ Technologies Used

* 💻 **C# (WinForms)**
* 🗄️ **SQL Server**
* 🔗 **ADO.NET**

---

## 🗂️ Database Structure

### Tables:

* **CARS**

  * CarID (Primary Key)
  * CarName
  * Model
  * PricePerDay
  * Status

* **CUSTOMERS**

  * CustomerID (Primary Key)
  * FirstName
  * LastName
  * Phone

* **RENTALS**

  * RentalID (Primary Key)
  * CustomerID (Foreign Key)
  * CarID (Foreign Key)
  * RentDate
  * ReturnDate
  * TotalAmount

---

## ⚙️ Key Functionalities

### 🔹 Stored Procedures

* GetAllRentals
* InsertRental
* UpdateRental
* DeleteRental

### 🔹 Trigger

* Automatically updates car status:

  * If `ReturnDate IS NULL` → **Rented**
  * If `ReturnDate IS NOT NULL` → **Available**

---

## 🚀 How to Run the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/Anas4167/Car-Rental-System.git
   ```

2. Open the project in **Visual Studio**

3. Restore the database in **SQL Server**

4. Update your connection string in `App.config`

5. Run the application ▶️

---

## 👨‍💻 Author

**Anas Abdullaahi**
🔗 GitHub: https://github.com/Anas4167

---

## ⭐ Support

If you like this project, give it a ⭐ on GitHub!

---

## 📄 License

This project is for educational purposes.
=======

>>>>>>> 4ed9635b40ee79d8547f034bea899c776f0d3692
