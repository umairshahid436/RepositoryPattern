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
Two different types of calculations performed for an annual cost. In order to achieve that two services created in the service layer

BasicAnnualCostCalculationService
PackagedAnnualCostCalculationService

These two services will calculate the annual cost of the product

```

### RESTful Service
```
As per instructions, in this project, RESTful service has been created.

Get: https://localhost:44385/api/product/
This will return all products in ascending order by annual cost such as

{
 success: true,
 data: [
        {
           tariffName: "Packaged tariff",
           annualCost: "950 €/Year"
        },
        {
           tariffName: "basic electricity tariff”",
           annualCost: "1050 €/Year"
        },
        {
           tariffName: "basic electricity tariff”",
           annualCost: "1380 €/Year"
        },
        {
           tariffName: "Packaged tariff”",
           annualCost: "1400 €/Year"
        },
        {
           tariffName: "Packaged tariff”",
           annualCost: "1400 €/Year"
        }
 ],
 message: "success",
 total: 5
 }

```

### Comparison 
```
Comparison method has been created in the product service layer which will take consumption as input and calculate the annual cost (Basic + Packaged), create a list of products, insert into database and return that list.

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
