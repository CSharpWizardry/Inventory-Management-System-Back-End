# Inventory-Management-System-Back-End
Inventory Management System Back-End


## Projects

### IMS.API

This project contains the API entrypoint.  
A docker-image can be created by executing the command ` docker build -t ims-api .` inside the project folder (where the dockerfile is).  
It can be run via docker by executing the command `docker container run -p 8080:80 --name ims ims-api`.  
To verify that the project is working is just access the browser and hit the url `http://localhost:8080/WeatherForecast`