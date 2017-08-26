# Portfolio-dotnet
#### A Portfolio in ASP.NET

#### By Charles Emrich
#### CharlesEmrich @ gitHub for any questions.

## Description
A redo of my initial portfolio independent project, now in ASP.NET and powered by the Github API

## Installation

* Clone the repository (https://github.com/CharlesEmrich/Portfolio-dotnet)
* Add the class Models/EnvironmentVariables.cs
  * It should look like this:
  namespace Portfolio.Models
{
    public class EnvironmentVariables
    {
        public static string AuthToken = "Your Github Authorization Token";
        public static string UserAgent = "Your User Name";
    }
}
* In Visual Studio, use IIS Express to boot up an instance of the app.

## Known Bugs
  * ASP.NET Refuses to use my custom CSS
  * Or load images stored in wwwroot
  * Github API seems like it might not be acknowledging my attempts to sort by starred.

## Technologies Used

* HTML
* C#
* CSS
* ASP.NET Core MVC
* Javascript

### License

MIT

Copyright (c) 2017 Charles Emrich
