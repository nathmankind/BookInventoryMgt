This is a book inventory project built with .NET 8.0(LTS)

## Getting Started

To run the project

Pre-requisite
- Have Visual Studio installed on your system
- Have a Databse Server installed (e.g Microsoft SQL Server Management Studio) 2022
- A browser (Chrome, Edge, etc)

First, clone the repository to your local machine using ```git clone https://github.com/nathmankind/BookInventoryMgt.git```

To run the application
- Open the project folder and locate `BookInventoryMgt.sln` on the local drive
- After locating the file, open the file with Visual Studio 2022
- Change the Server name: In the project tree, locate the file `appsettings.json` and change the server name from "PEARL" to your configured server name (you should find this in your database server connection)
- Inside Visual Studio, go to tools, Click on "Nugget Package Manager", then click on "Package manager console". This should open a terminal at the bottom
- Enter the code ```update-database```. This will run the migration file and create the database in your database server with the name "BookInventory"
- Finally, Click on the green button at the top to run the project. This should open up a browser and you can now interact with the system

