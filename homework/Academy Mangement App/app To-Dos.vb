Create the MVC academy management app project - Done

Create a project To store the DomainModels - Done
#Region DomainModels
Create a folder For Enumerators - Done
	Create the Role Enumerator For User Roles - Done
	Which contains the Next roles:
		Admin
		Trainer
		Student
	Create a base model containing Id - Done
		Create a User Model - Done
		Inherits from Base
			public string Username
			public string Password
			public Role Role

		Methods:
				Authenticate()
				AddUser()
				RemoveUser()
		
		Create a Student Model - Done
		Inherits from User
			public string Name
			public virtual List<Subject> Subjects
			public virtual List<Grade> Grades

		Methods:
			GetSubjects()
			GetGrades()
		
		Create a Subject Model - Done
		Properties:
			public string SubjectName
			public virtual List<Student> StudentsEnrolled
			 
		Methods:
			 AssignStudent()
			 GetStudents()

		Create a Grade Model - Done
		Properties:
			public Student Student
			Public Subject Subject
		
		Methods:
			AddGrade()
			UpdateGrade()
#End Region

Create a project To store the Repositories - Done
#Region Repositories
Create an interfaces And implementations folder within
the project - Done
	Create a Generic IRepository Interface inside the interfaces folder 
		With CRUD operations - Done
	
	Implement the IRepository Interface inside the implementations folder - Done

Add a DbContextClass inheriting from DbContextClass - Done
	add every Model you want To represent As a table In the SQL Server -
#End Region

Create a project To store the Services - Done
#Region Services

Add the interfaces And implementations folder
	Implement an interface for each model that is going to be manipulated
	that is going to use the Repository CRUD operations + extra methods linked
	to the model

#End Region

Create a project To store the ViewModels - Done
#Region ViewModels
Here you are going To store the models that are going To be sent To the Controller For presentation
#End Region

Create a project To store the Helpers - Done
#Region Helpers
Here you will store the DIModule which will take care Of dependency injection
and Mappers for converting from DomainModels to ViewModels and vice versa
#End Region

Add references to the projects so they have access to what they need

