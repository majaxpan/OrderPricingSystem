# OrderPricingSystem

Built with .NET 8 Web API

## How to run: 
git clone https://github.com/yourusername/OrderPricingSystem.git  
cd OrderPricingSystem  
dotnet run

API will run on default port 5261:  
http://localhost:5261  

API Endpoint:  
GET /api/pricing/calculate

## Test cases and results

### 1. Call: 
/api/pricing/calculate?productId=PROD-001&quantity=55&country=MK  
### Result (final Price): 700.92

### 2. Call: 
/api/pricing/calculate?productId=PROD-001&quantity=100&country=DE  
### Result (final Price): 1224

### 3. Call: 
/api/pricing/calculate?productId=PROD-001&quantity=25&country=USA  
### Result (final Price): 330
