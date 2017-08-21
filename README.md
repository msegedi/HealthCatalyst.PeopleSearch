# The People Search Application

## Business Requirements
* The application accepts search input in a text box and then displays in a pleasing style a list of people where any part of their first or last name matches what was typed in the search box (displaying at least name, address, age, interests, and a picture). 
* Solution should either seed data or provide a way to enter new users or both
* Simulate search being slow and have the UI gracefully handle the delay

## Technical Requirements
* An ASP.NET MVC Application 
* Use Ajax to respond to search request (no full page refresh) using JSON for both the request and the response
* Use Entity Framework Code First to talk to the database
* Unit Tests for appropriate parts of the application

## Instructions for running the app
* The solution was created in VS 2017.
* The projects are .NET Core 2.0 projects. The SDK will need installed to run it locally.
* The HealthCatalyst.Apis.People.Data project uses LocalDB and EF Code-First + Migrations. Since there are two runnable projects, ensure HealthCatalyst.Apis.People.Web is set as the startup project prior to running `Update-Database`.
* Before running the HealthCatalyst.PeopleSearch.Web (UI) project, ensure HealthCatalyst.Apis.People.Web (API) is running.

## To make it production-ready / wish list
* UI features
  * Prettier UI in general
  * Paging
  * Sorting (at the UI level, likely using lodash)
  * Prettier mobile layout
  * Unit tests
* API features
  * I started writing up a list of production-level API features that I find essential for any type of API-centric environment while working on a different code challenge. I think they mostly applly here as well - https://github.com/msegedi/RedVentures.TravelApi#notes. I've copied some of them below:
  * Essential real-world API features that I did not implement for this project:
    * Paging
    * Filtering
    * Sorting
    * Projecting / selecting certain fields
    * Security
    * Exception handling
    * Error handling
    * Use of a server framework to be shared across all APIs: validating filters and project fields, error codes, etc.
  * More far-reaching things I would do in an API-heavy ecosystem:
    * API guidelines document. Helps all developers across the organization follow standards for API endpoint and resource design including: resource naming, versioning, SLAs, request limits, and much, much more.
    * Creation of a client framework to easily work with these APIs across the ecosystem. Follows standards set forth by the API guidelines.
    * API Key assignment on a per-api basis.
    * Swagger
    * Auto trimming of request parameters
    * Force HTTPS for all endpoints
    * Centralized ValidateModelStateFilter
    * Consistent BadRequest model including error code, field names, and descriptions
    * Exception handling
    * Logging
    * Method XML comments
    * I'm really just scratching the surface here...
  * If curious about how I'd implement some of the Client or Server Frameworks that I mention above, I'd be more than happy to provide code that I've already written to handle some of this.

