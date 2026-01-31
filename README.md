# Currency Converter
## Description
- This is a small demo project that converts currencies based on different exchange rates. 
- It uses a Sqlite database that should be prepopulated on download, so you should be able to run the project as soon as you clone this repository.
- The general usage arguments list looks like this: `{Original Currency Code} {Original Amount} {New Currency Code}`, where currency codes are 3 letter sequences.

## How to Run
**Prerequisites: Dotnet10** | (I have Sqlite downloaded globally on my machine, you may need that.)
1. Clone this repository onto your machine.
1. Navigate to the root directory of this repository in a CLI of your choosing.
1. Run the command `dotnet run --project CurrencyConverter/ EUR 100 HKD`; This should spit out a number for you based on the conversion rates in the sqlite database.
