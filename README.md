# ToDoManager API
Purpose 
A Clean Architecture .NET 9 Web API for managing ToDo list. Implements four endpoints: list to do items, create a to do item and delete a to do item. 

Design summary
Architecture
-	Presentation: Api project - controllers, middleware.
-	Application: Application project - CQRS, interfaces, exceptions
-	Domain: Domain project - entities.
-	Infrastructure: Infrastructure project - repository implementation.
This separation keeps business rules independent of frameworks and makes testing easier.

# ToDoManager UI
The frontend is a simple Angular application:
-   Displays list of TODO items
-   Allow adding new items
-   Allow deleting items

Further considerations (for extending beyond test)
-   Use DTOs to map domain entities for API consumption
-   Add persistence (EF Core + database)
-   More robust error handling and logging


