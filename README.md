#Learn ASp.net

##Service Lifetime
Service lifetimes in .NET Core specify how long a particular instance of a service should be maintained by the service container. The service lifetime can have a significant impact on the behavior of an application, particularly in terms of performance and resource usage.



SingleTon Service :- Only one object will use to throughtout application.. For eg if we have Repository and API if we add item same object will be used throught that repository.

AddScoped Service :-The Scoped lifetime creates a new object of a service for each scope within an application. Any dependencies resolved within the same scope will receive the same instance

Transient Service:- We will get new Instance for Repository and for every Http Request new object will be created

#Use Cases of Singeton Service in .net
Singleton It is usefull for less recourses like Logging or Shopping Cart service which has to revolve throught the application as shopping cart does have to maintain internal state so therefor we register Singleton in both cases

services.AddSingleton<LoggerService, LoggerService>()

Logger will use single instant to print logging message to console

#Disadvantages of Singeton 
1) If the single Instance of the object becomes corrupted, the entire system is compromised.
2) We cannot do unit test in SingleTon.


#Use Cases of Scoped Service in .net

whenever we need to maintain a constant behavior within a single transaction or single HTTP request Scoped come into play now example is this that we have a service that retrive
data from database.

services.AddScoped<IUserDataService, UserDataService>

In this way Service will registered Using Interface of Data Service within scope of single request whenever interface is used or injected same instance will be
used of service. This ensure data consistency within Single transaction or Request
For other Example

or payment service which will use scoped as it will interace with external payment gateways and required statefull connection within scope as for singleton it have to change its object for external payment For entity framework contexts are recommend to be scoped so that you can reuse the connection properties.

services.AddScoped<IShoppingCartService, ShoppingCartService>

Service insant created for each request will be different it will be ensuring a unique and private cart for each users

AddScoped proves to be a game-changer in diffrent demanding consistency per request and user-specific behavioral patterns.  It simplifies resource management and enables smoother application performance

#Disadvantages of Scoped 
1)Limited LifeTime:- it will have lifetime of duration of single request.The service must be created again for every new Request
2) Memory Leakage:- if service is not disposed properly they can  create memory leaks. Developer must be ensured that service disposed after request finishes


#Use Cases of Transient Service in .net

services.AddTransient<IUtilityService, UtilityService>();

Transient instances are suitable for lightweight and stateless services that don’t maintain any internal state or shared resources. Examples include utility classes or simple calculation services.

#Disadvantages of Tranient
1) Takes more Memory
2) Slow as it everytime create Instance





#Dependecny Injection and IOT 

Dependecny Injection is type of pattern  which losely coupled the classes for example if we have HomeController and EmailSender class
so we have to make instant of EmailSender in HomeController to use functions but it will tightly coupled it will create issues for Unit Testing for that Controller
if in EmailSender we have thirdParty Intergration we have to make changing in Controllers who are using this EmailSender. Now how to Implement Dependecny Injection
if we have Repositories who should be used in controller we will have Interfaces to be used in COntroller to Implement Dependecny Injection. Controller will never know Method Implementation it will be in Repository interface are used for calling that Methods
Now question is Which interface will implement which Repository it will be define in DI Container in Service Lifetime
Now reason of Dependecny Injecton to be used is to Implement IOT


Dependency injection (DI) is one form of IoC where we delegate the responsibility of creating and injecting components' dependencies to some other party outside of the components themselves.



#Stack & Heap
Stack is Memory allocation and it is not flexible as Heap. Heap provides dynamic Memory allocation and its flexible and uses memory address it doesnt have object name it has address of variables 

When we have int value it is stored in Stack if it is in Struct and if we have Object it is stored in Heap.

#Use Case of Stack & Heap Explanation
Struct Student{
Public Class age;
Public Class marks;


}

Function main Program{

Student Std = new OOP.Student();
Std.age = 20;
std.mark=100;

Student std2 = std;
Student std3 = std;

}

From all values will be copied in std2 and std3. So in Stack it will acquire memory with Blocks and it could be StackOverflowed if like this objects and if we change value of std.age=25 it will not change value of other object’s column so its better to use Class and Objects


Now in Class it will store in Heap by Refrence Heap doesnt have object name will be in Stack and Object will be in Heap it will have Memory Address to stack as start with std it will be in stack and its memory will be in stack


#DTO , Model and Entity
Dto will be in WebLayer Model will be in Service Layer and Entity will be in DatabaseLayer
Difference between Model and Entity is that for Exammple we have Person details so in Model will be PersonID, FirstName,Lastname,FullName and Age so in Entity we will have less coloumns in Age Column it will be DOB as for Models which is in Service Layer we have to do BuisnessLogics for model also to get the Age by function also for FullName also will not be in Entity as we and it will be in Models as we will concatinate FirstName and LastName for FullName in BuisnessLogic using Model
In DTO Service layer is sending whole information from Entity To WebLayer(DTO) They also have less coloumns so that in Client app we dont need FirstName and LastName it will be Fullname as in Service Layer Models are using BuisnessLogics so DTO Coulmns will be less
