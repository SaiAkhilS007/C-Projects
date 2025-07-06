# Expense Tracker (📊 Console App, .NET 8)

A lightweight **command-line expense log** you can build and run in seconds.  
Ideal for showcasing C# fundamentals—LINQ, file I/O, collections—without any external
dependencies or databases.

---

## ✨ Features
| Command | What it does |
|---------|--------------|
| **Add expense** | Prompt for Date (yyyy-MM-dd), Description, Amount; appends to in-memory list |
| **List expenses** | Displays all records, sorted by date, with currency formatting |
| **Save & exit** | Persists the session to `expenses.csv` in the working directory |

Additional goodies:

* **Auto-load** existing `expenses.csv` on startup  
* Simple **CSV schema**—easy to import into Excel, Power BI, or pandas  
* **Culture-invariant parsing** so decimals work regardless of locale settings  
* Fully **nullable-enabled** and **LINQ-driven** code for modern C# style

---

## 🛠 Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/) or later (`dotnet --version` ≥ 8.x)

---

## 🚀 Build & Run

```bash
git clone https://github.com/your-username/expense-tracker.git
cd expense-tracker
dotnet build      # compiles the project
dotnet run        # launches the CLI
