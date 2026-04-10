# 🥗 MacroCalc

A simple web application that helps users track and store their daily macronutrients — **fat**, **carbs**, and **protein** — to support their diet goals.

---

## 🚀 Features

- Add and manage daily macro entries (fat, carbs, protein)
- Edit macro entries 
- View and store macros by date
- Simple and clean architecture using ASP.NET Core and EF Core
- SQL Server integration for persistent data storage

---

## 🧰 Tech Stack

- **Backend:** ASP.NET Core  
- **ORM:** Entity Framework Core  
- **Database:** SQL Server  

---

## ⚙️ Getting Started

### 🛠️ Prerequisites

Before you start, make sure you have:
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 

---

### 🧩 Installation & Setup

1. **Clone this repository:**
   ```bash
   git clone https://github.com/JehadT/MacroCalc.git
   ```
2. **Update your connection string:**
Open appsettings.json and modify the connection string to match your local SQL Server instance:
  ```bash
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=MacroCalc;Trusted_Connection=True"
  }
  ```
3. **Apply database migrations:** (using Package Manager Console)
  ```bash
  Update-Database
  ```
4. **Run the code**

---

Developed with ❤️ using ASP.NET Core
