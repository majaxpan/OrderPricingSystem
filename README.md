#OrderPricingSystem

Built with **.NET 8 Web API**

##How to run:
git clone https://github.com/yourusername/OrderPricingSystem.git
cd OrderPricingSystem
dotnet run

API will run on default port 5261
http://localhost:5261
API endopoint: GET /api/pricing/calculate

##Test cases and results
###1.call: /api/pricing/calculate?productId=PROD-001&quantity=55&country=MK
###result(final Price): 700.92

###2.call: /api/pricing/calculate?productId=PROD-001&quantity=100&country=DE
###result(final Price): 1224

###3.call: /api/pricing/calculate?productId=PROD-001&quantity=25&country=USA
###result(final Price): 330

