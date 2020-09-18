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
Two different type of calculations performed for annual cost. In order achive that two services created in service layer with name

BasicServicecalculation
PackagedServiceCalculation

These two service will calculate the annual cost of product.

```

### RESTful Service
```
As per instructions, in this project RESTful service has been created.

Get: https://localhost:44385/api/product/
This will return all products in below format
{
    "success": true,
    "data": [    
        {
            "id": 14,
            "tariffName": "packaged tariff”",
            "packageType": "Packaged",
            "consumption": 6000,
            "annualCost": 1400
        }
    ],
    "message": "success",
    "total": 1
}

Post: https://localhost:44385/api/product/
This will take following model as input, calculate the annual cost based on packged type and store data. 
{
    "TariffName": "name",
    "PackageType": "Packaged",
    "Consumption": 6000
}

Following are the two types of packaged type which used to perform desire calculation
"Basic"
"Packaged"
```

### Comparison 
```
```

### Unit Test

```
To test calculation service, unit test has been written under XUnitTest
```
