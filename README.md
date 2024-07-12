# Water Billing Management System Application

WaterBilling is a desktop application for managing water bills. It allows users to add, edit, delete, and pay bills. The application uses a SQL Server database to store billing information.

## Features

- **Add Bill:** Add a new bill with details such as consumer ID, agent, bill period, consumption, rate, tax, and total.
- **Edit Bill:** Edit existing bills and update the information.
- **Delete Bill:** Delete bills from the database.
- **Pay Bill:** Pay bills by entering the payment amount, which is subtracted from the current total and updated in the database.
- **View Bills:** Display all bills in a DataGridView for easy viewing and management.

## Prerequisites

- .NET Framework (C#)
- SQL Server

## Database Setup

1. Create a SQL Server database named `WaterBillingDb`.
2. Create the following table:

```sql
CREATE TABLE BillTbl (
    BNum INT PRIMARY KEY IDENTITY(1,1),
    Cid INT,
    Agent VARCHAR(100),
    BillPeriod VARCHAR(50),
    Consumption INT,
    Rate INT,
    Tax FLOAT,
    Total INT
);
```

## Installation

1. Clone the repository:

```bash
git clone https://github.com/yourusername/WaterBilling.git
```

2. Open the solution in Visual Studio.
   
3. Update the connection string in the Checkout and Billing forms to match your SQL Server instance:

```csharp
SqlConnection Con = new SqlConnection(@"Data Source=YOUR_SERVER_NAME;Initial Catalog=WaterBillingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
```

4. Build and run the application.

## Usage

### Add Bill

- Enter the consumer ID, agent, bill period, consumption, and rate.
- The application will automatically calculate the tax (1% of the total) and the total amount.
- Click on the "Add" button to save the bill to the database.

### Edit Bill

- Select a bill from the DataGridView.
- Modify the necessary details.
- Click on the "Edit" button to update the bill in the database.

### Delete Bill

- Select a bill from the DataGridView.
- Click on the "Delete" button to remove the bill from the database.

### Pay Bill

- Select a bill from the DataGridView.
- Enter the payment amount in the provided textbox.
- Click on the "Pay Bill" button to update the bill's total in the database.

## Code Overview

### Billing Form

- `ShowBill`: Retrieves and displays all bills from the database.
- `Add_Click`: Adds a new bill to the database.
- `button1_Click (Edit)`: Edits the selected bill in the database.
- `button2_Click (Delete)`: Deletes the selected bill from the database.
- `BillDGV_CellContentClick`: Populates the form fields with the selected bill's information.
- `GetCons`: Retrieves consumer IDs from the ConsumerTbl table.
- `GetConsRate`: Retrieves the rate for the selected consumer ID.

### Checkout Form

- `bunifuThinButton21_Click (Pay Bill)`: Handles the payment process, updates the bill's total in the database.
- `GetSelectedBillId`: Dummy method to get the selected bill ID (to be replaced with actual logic).
- `GetSelectedBillTotal`: Dummy method to get the selected bill's total (to be replaced with actual logic).
- `ResetForm`: Resets the form fields after payment.

## License

This project is licensed under the MIT License.

## Acknowledgments

- Icons by FontAwesome
- UI components by Guna.UI2
