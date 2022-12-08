# BusTicket
Bus ticketing system Web application.

• Project Description : There are 3 main roles in the system(Admin, Operator and Customer).But without logging in, the user can also search for trips with trip details(departure - arrival point, travel date) and after the selecting the suitable trip, can proceed to seat selection. The user passes the payment stage and accesses the ticket. If the user is registered and logged in, user having the customer role, can get a ticket with the passanger information that is already saved in the account. Admin can add new user, new role and change the role of any user. The operator can add new bus trips and determine which bus and driver will be assigned. In the database, the trips are designed to include intermediate stops. If the trip is between A to D , user can buy a ticket from A to B , B to C etc.

• Technologies Used: C# .Net, ASP Net Core(MVC), ASP Net Core Identity, EF Core CodeFirst, Bootstrap,  Javascript, CSS3, HTML5, SQLite , Generic Repository Pattern, Layered Architecture, OOP

• How to set up and run this project: The project is developed with .NET 6.0 so the metnioned C# .Net version must be installed. Place the source code inside your project directory. Open the BusTicket.sln file and this will open the project in Visual Studio 2022. Now download all the necessary packages from the Nuget Package Manager. All the .NET and EF core packages are having the version of 6.0 . As database SQlite has been used, any migration or database update commend is not required. Now, you can run the project locally in your browser. Also, note that initially, admin user is added manually in the database and is assigned the Admin role.(username: admin , password:Qwe123.)

