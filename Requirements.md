# Employee Database Project Requirements

## Overview

EmployeeDatabaseProject is a focused effort to create and manage employee data within a database. In this project, employee attributes will be defined, database operations such as inserting, updating, and deleting will be implemented, and APIs and services will facilitate seamless database interaction. We adhere to data integrity and security standards while maintaining accurate and accessible employee records.

### 1). Domain Project

1. Update the **Employee** class and add the following properties:

   - **Id** : it's a required key property, and must be unique
   - **First Name** : it's a required property
   - **Last Name** : it's a required property
   - **Age** : it's a required property
   - **Gender** : it's a required property
   - **Full Name** : this should be First Name and Last Name combined, and should not be stored in the database

### 2). Repository Project

2. Update the EmployeeRepository class and implement the following methods (using Entity Framework):

   - **Insert** : this should store new employee into the database
   - **Update** : this should update an existing employee in the database
   - **Delete** : this should delete an existing employee from the database

3. Create a new DBContext class, which will allow access to the Employees database table via the EmployeeRepository

### 3). Service Project

4. Update the EmployeeService class and implement the following methods:
   - **Save** : this should upsert an Employee, depending on whether it already exists in the database or not
   - **GetAll** : this should return a collection of all employees in the system, and allow filtering via first name, last name and gender

### 4). Tests.Unit.Sample.Services

5. Update the EmployeeServiceTest class and add some unit tests for the following methods:
   - **EmployeeService.Save**
   - **EmployeeService.GetAll**
   - Please feel free to implement mocking using any framework that you know; the **Sample.Infrastructure.UnitTest.MockDbSetHelper** class may help get you started.

### 5). Tests.Unit.Sample.Repositories

6.  Update the **EmployeeRepositoryTest** class and add some unit tests for the following methods:

- **EmployeeRepository.Delete**

### 6). Web API Project

7. Update the EmployeeController class and implement the following API endpoints:
   - **Save** : this should call the service to add or update an Employee, and then return a useful response to the front-end
   - **GetAll** : this should call the service to retrieve a list of Employees in the system, allowing any relevant filter arguments to be passed in from the front-end
   - **Please ensure that all** :
     - **i. Inputs are validated and sanitized**
     - **ii. Requests are authenticated**
