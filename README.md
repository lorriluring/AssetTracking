# Asset Tracking System

## Project Description

A C# console application that tracks company assets such as laptops, desktops, mobile phones and tablets. The system stores assets in memory, warns when an asset nears the end of its 3 year lifespan, and supports offices in several countries with their own currency. The project was built as a weekly mini project to practice object-oriented programming in C#.

## Features

- Asset classes with inheritance: abstract `Asset`, with `Computer`, `MobilePhone` and `Tablet`
- Polymorphism through an abstract `GetDescription` method
- Status warnings based on a 3 year lifespan
  - RED: less than 3 months remaining or already expired
  - YELLOW: less than 6 months remaining
- Sorting with LINQ by type and purchase date, or by office and purchase date
- Offices in Sweden, USA and Turkey, stored as an enum
- Local price calculated from the USD price with fixed exchange rates, shown with a currency code
- Unique asset Id and age calculation in years and months
- Menu system: add, view, sort, search and remove assets
- Search by brand or model, ignoring capital letters
- Input validation with `TryParse` for dates, prices and Ids
- Color coded rows for status and red error messages
- Service class (`AssetService`) separates data handling from console input and output

## Technologies

- C#
- .NET Console Application
- LINQ
- Visual Studio

## Project Structure

```
AssetTracking/
├── Models/
│   ├── Asset.cs
│   ├── Computer.cs
│   ├── MobilePhone.cs
│   ├── Tablet.cs
│   └── OfficeLocation.cs
├── Services/
│   ├── AssetService.cs
│   └── CurrencyService.cs
├── images/
│   ├── menu.png
│   ├── asset-table.png
│   └── add-asset.png
└── Program.cs
```

- Models holds the classes that describe the assets and offices.
- Services holds the logic for data handling and currency conversion.
- images holds the screenshots shown in this README.

## Installation

1. Install the .NET SDK and Visual Studio.
2. Clone the repository:
   ```
   git clone <repository-url>
   ```
3. Open the solution file `AssetTracking.sln` in Visual Studio.

## How to Run

1. Open the solution in Visual Studio.
2. Press `Ctrl+F5` to run without debugging, so the console window stays open.
3. Choose an option in the menu by typing its number and pressing Enter.

## Screenshots

Main menu:

![Main menu](images/menu.png)

Asset table with RED and YELLOW rows:

![Asset table](images/asset-table.png)

Adding an asset:

![Adding an asset](images/add-asset.png)

## Team Members

- Johan Lorentz - [GitHub profile](https://github.com/lorriluring)

## Future Improvements

- Save and load assets from a JSON file, so data stays between runs (Level 5)
- Export an asset report to CSV
- Edit an existing asset
- Live exchange rates from an API
- Unit tests for status, age and currency calculations
