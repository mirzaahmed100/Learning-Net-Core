#Learn ASp.net

##Service Lifetime



SingleTon Service :- Only one object will use to throughtout application.. For eg if we have product Repository and API if we add item in Product same object will revolve and use around it.now for product only one object will use around this API.

AddScoped Service :-In this service Life Same Object will not be used for product so previous data will be lost.. Like if we pass product Name "Shirt" and again "Shirt-2" it will lost Shirt name data and update to Shirt-2 as Object is not shared

Transient Service:- We will get new Instance for Repository and for every Http Request new object will be created

Pros and Cons of Singleton It is usefull for less recourses like Logging or Shopping Cart service which has to revolve throught the application as shopping cart does have to maintain internal state so therefor we register Singleton in both cases. Now to use scoped and Transient here is bad because each time request new instance will created and for transient as it doesnt hold state so singleton is better and to be used single and hold state also for the Payment Service Singleton is bad as instant needed for external gateway payment so Singleton is not good here

Pros and Cons of Scoped

For payment service which will use scoped as it will interace with external payment gateways and required statefull connection within scope as for singleton it have to change its object for external payment and for trasient it is bad as it is stateless. For entity framework contexts are recommend to be scoped so that you can reuse the connection properties. In logger case where we want to print messages to console or anything scoped should not be use.

Pros and Cons of Transient It is Stateless and for smaller applications it does not maintain state or shared recourse. Now for example if we want to use Utitlty Service or Functions we will use Tranient for simple Caculation it will not hold the state so here Transient is much better. Now in Logger where single instant is using here Transient is not better as it is stateless we have to maintain its state so Transient is not better and for EF contexts is also not better