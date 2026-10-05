# Invoices

Invoices is a Windows Forms desktop application for browsing and maintaining invoices and their related records. The code is organized into data, business logic, and user interface projects, with shared database and form infrastructure in `Lib` and `Lib.UX`.

## Features

- Browse invoice records and search the browser list by customer name.
- Open an invoice form with customer and item-order lookups and editable invoice lines.
- Work with related customers, suppliers, items, item orders, invoice lines, and invoice details through the data and logic layers.
- Persist records through the shared data library's SQL Server implementation.

## Technology

- C# and .NET 8
- Windows Forms (Windows desktop)
- Microsoft SQL Server
- Dapper and `System.Data.SqlClient` in the shared data library

## Repository layout

| Project | Purpose |
| --- | --- |
| `WindowsApp/` | Desktop application entry point and main window |
| `Invoices.UX/` | Invoice browser and invoice editing views/forms |
| `Invoices.Logic/` | Invoice models, entities, and data-module builders |
| `Invoices.Data/` | SQL-backed table and record mappings |
| `Invoices.Common/` | Shared invoice application settings |
| `Lib/` | Shared database access and persistence framework |
| `Lib.UX/` | Shared WinForms data-form and grid helpers |

## Software and design patterns

The application uses these patterns in its form construction, data access, and editing workflows:

| Pattern | How it is used |
| --- | --- |
| **Builder and Director** | `CDataModuleDirector` builds the browser, master, detail, and lookup models in sequence using `CDataModuleBuilderInvoice`. `CMasterFormDirector` and `CMasterFormBuilderInvoice` assemble the invoice module and its views into a form. |
| **Factory** | `CDataTableFactory` maps table identifiers such as `Invoice` and `Customer` to table classes and creates the selected type with `Produce`. |
| **Singleton** | `CDataTableFactory.Instance` and `CSettings.Instance` provide shared instances of the table factory and application settings. The factory uses `Lazy<T>` for its singleton instance. |
| **Lazy initialization** | The SQL Server connection is created when `CDataTableFactory.DB` is first accessed. The shared SQL database classes and detail-grid lookup column also defer setup until needed. |
| **State** | Master and table form contexts hold an `IFormState` and delegate actions to state objects, such as browser-loaded, opened-entity, editing, and changed states. The states control form behavior and transitions. |
| **Decorator** | `CBrowserGridDecorator`, `CEditableGridDecorator`, and `CDetailGridDecorator` wrap WinForms grids to add browser, editing, and detail-grid behavior. |
| **Template Method** | Shared data-module and table-form classes define reusable load, save, and form lifecycle steps, with overridable hooks for specialized behavior. |
| **Visitor** | `CVisitorToModel` and `CVisitorToTable` transfer data between database records and logic entities. Model load/save operations accept these visitors; view display also uses the `DisplayView` control extension. |
| **Proxy** | `CFormTemplateMaster` exposes methods that delegate module operations and view updates to their underlying objects, keeping form state handling separate from those components. |

The project also follows a **layered architecture**: `Invoices.Data` handles persistence mappings, `Invoices.Logic` owns invoice models and business coordination, and `Invoices.UX`/`WindowsApp` provide the desktop interface. The invoice form uses a **master-detail** structure, with an invoice as the master record and its invoice lines as details.

## Requirements

- Windows
- Visual Studio 2022 with the .NET desktop development workload, or the .NET 8 SDK with Windows Forms targeting support
- Access to a compatible SQL Server instance and the database objects expected by the table mappings

## Getting started

1. Clone the repository:

   ```sh
   git clone https://github.com/KarimWalid805/Invoices.git
   cd Invoices
   ```

2. Set the SQL Server connection values used by `Invoices.Common/CSettings.cs` (`DBServerURL`, `DBName`, `DBUser`, and `DBPassword`) to values for your own database. The current defaults are embedded in the source. The class has JSON load/save helpers, but the checked-in startup flow does not call `Load()` automatically.

3. Provision the database separately. This repository does not include a database creation script, migrations, or sample database. The app expects the SQL Server tables and view mapped in `Invoices.Data/Tables/` and `Invoices.Data/Records/`.

4. Open the solution/project in Visual Studio and build the Windows Forms application. The repository currently contains machine-specific absolute project references in `Invoices.UX/Invoices.sln` and `WindowsApp/WindowsApp.csproj`; update those references to valid paths in your checkout if Visual Studio cannot resolve them.

5. Run `WindowsApp` on Windows. The main window opens first; use the Master menu's **Application Users and Movies** entry to open the invoice browser and editing workflow.

## Notes

- The UI menu still contains legacy labels such as “Application Users and Movies,” “Movie Genres,” and “Subscription Plans”; the invoice form is launched by the first of these entries.
- The repository includes generated Visual Studio and build output files. They are not required as source for the application.
- No license file is included. Contact the repository owner for reuse and distribution terms.
