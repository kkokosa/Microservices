# .NET Core Microservices 

A complete solution that shows an example implementation of microservices in .NET Core ecosystem. It is designed with the spirit of DDD strategic design patterns but do not enforce using "tactical DDD" on the services level. It consist of:
* applications - consume services underneath:
	* simple web application - ASP.NET and React.js based web application 
	* simple REST API - ASP.NET WebAPI to be consumed by mobile application
* application services
* domain services
	* microservices - a few cooperating microservices written with different approach. As in microservices world there is no one-win-all solution, you can use any of such them as a template for your solution.
* framework - a think framework shared by all microservices which takes care of 

In most cases you will use one or two kind of microservices as a template for you solution. You can treat this solution as an inspiration giving some answers to common problems and design decisions. You can also use it as a complete skeleton to start building your own application, removing any unnecessary parts.

Roadmap:
* .NET Core Framework
	- [ ] REST client
* Plain Old Service microservice
	- [ ] Plain template
* ASP.NET Core DDD microservice
	- [x] Plain template
* NancyFx DDD microservice
	- [ ] Plain template
* Suave DDD microservice
	- [ ] Plain template
* Deployment
	- [ ] Docker configuration
	- [ ] Docker Compose configuration
