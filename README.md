# PBL3 - Digital Banking Management System

This is a university group project for **PBL3**. It is a desktop application that simulates a digital banking system, allowing users to manage their accounts, transfer funds, pay bills, and handle loans or savings.

## 🛠 Technology Stack
- **Language:** C#
- **Framework:** .NET Framework 4.7.2 (Windows Forms)
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework 6.0
- **Architecture:** 3-Tier Architecture (GUI, BLL, DAL, and DTO)

## ✨ Main Features
- **User Authentication:** Register, login, and change passwords safely.
- **Account Management:** View balances, update personal information, and track transaction history.
- **Transactions:** Perform internal and external money transfers.
- **Payments:** Pay standard utility bills (electricity, water, internet, phone).
- **Loans & Savings:** Apply for loans, view automatic repayment schedules, and open savings accounts.
- **Admin Dashboard:** Quick overview for admins to manage users and monitor transactions.

## 🏗 Technical Highlights
- **3-Tier Architecture:** Clean separation of concerns between the User Interface (GUI), Business Logic (BLL), and Database Access (DAL).
- **TransactionScope:** Used in the Payment and Loan modules to ensure data integrity. If an error occurs during a complex transaction (like taking money and updating an invoice), it rolls back safely.
- **Password Security:** Passwords are hashed using the **PBKDF2** algorithm before being saved to the database.

## 🚀 How to Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/sonphan1408/PBL3.git
   ```
2. **Setup Database:**
   - Open SQL Server Management Studio (SSMS).
   - Create a database named `DigitalBankingDB` and run the provided SQL script to create tables.
3. **Configure Connection:**
   - Open the solution `PBL3.sln` in Visual Studio.
   - Go to `DAL/App.Config`.
   - Update the `Data Source` in the connection string to match your local SQL Server instance (e.g., `(local)\SQLEXPRESS` or `localhost`).
4. **Run:**
   - Right-click on the `GUI` project and select **"Set as Startup Project"**.
   - Press **F5** to build and run the application.