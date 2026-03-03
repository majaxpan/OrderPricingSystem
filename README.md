# OrderPricingSystem

Built with .NET 8 Web API

## How to run: 
git clone https://github.com/majaxpan/OrderPricingSystem
cd OrderPricingSystem  
dotnet run

API will run on default port 5261:  
http://localhost:5261  

API Endpoint:  
GET /api/pricing/calculate

## Test cases and results

### 1. 
Call: /api/pricing/calculate?productId=PROD-001&quantity=55&country=MK  
Result (final Price): 700.92

### 2. 
Call: /api/pricing/calculate?productId=PROD-001&quantity=100&country=DE  
Result (final Price): 1224

### 3. 
Call: /api/pricing/calculate?productId=PROD-001&quantity=25&country=USA  
Result (final Price): 330

## Bugs:

### 1. Tax calculation
Tax is now calculated **after applying discounts**.  
I introduced `subtotalAfterDiscount` and used it to calculate tax so the final price is correct.

### 2. Discount logic
- Discounts are applied **only if subtotal ≥ 500**.  
- 5% discount for quantities **10–49**  
- 10% discount for quantities **50–99**  
- 15% discount for quantity **100**  

## Note:
JSON file **products.json** is used to store product data and it is saved in the root folder.
