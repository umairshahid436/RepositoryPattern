# Tariff Comparison

### Technology Stack
```
 C#
.Net Core (3.1)
 Entity Framework (Code first)
 SQL Server
```

### Calculation Models

```
Two different types of calculations performed for an annual cost. In order to achieve that two services created in the service layer with the name

BasicServicecalculation
PackagedServiceCalculation

These two services will calculate the annual cost of the product

```

### RESTful Service
```
As per instructions, in this project, RESTful service has been created.

Get: https://localhost:44385/api/product/
This will return all products in below format
{
    "success": true,
    "data": [    
        {
            id: 15,
            unit: "KWh",
            tariffName: "basic electricity tariff”",
            packageType: "basic",
            consumption: 6000,
            annualCost: 1380
        }
    ],
    "message": "success",
    "total": 1
}

Post: https://localhost:44385/api/product/
This will take the following model as input, calculate the annual cost based on packaged type and store data. 
{
    "TariffName": "name",
    "PackageType": "Packaged",
    "Consumption": 6000
}

Following are the two types of the packaged type which used to perform desire calculation
"Basic"
"Packaged"
```

### Comparison 
```
Comparison service has been created in the service layer which will take consumption as input and calculate the annual cost, create a list of products and return that list in ascending order according to the annual cost.

Get: https://localhost:44385/api/product/Comparison?consumption=6000

Output: 

{
   success: true,
   data: [
           {
             tariffName: "basic electricity tariff”",
             annualCost: "1380 €/Year"
           },
           {
              tariffName: "Packaged tariff",
              annualCost: "1400 €/Year"
           }
   ],
   message: "success",
   total: 2
}
```

### Unit Test

```
To test calculation service, unit test has been written under XUnitTest
```
