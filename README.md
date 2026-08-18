# ToDoManager API
Purpose 
A Clean Architecture .NET 9 Web API for managing ToDo list. Implements four endpoints: list to do items, get to do item by id, create a to do item and delete a to do item. 

Design summary
Architecture
•	Presentation: Api project — controllers, middleware.
•	Application: Application project — CQRS, interfaces, exceptions
•	Domain: Domain project — entities.
•	Infrastructure: Infrastructure project — repository implementation.
This separation keeps business rules independent of frameworks and makes testing easier.



