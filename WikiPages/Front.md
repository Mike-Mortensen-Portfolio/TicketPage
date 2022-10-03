# Welcome to the Assignment Page WiKi
The structure of the project is formed by using a **Domain** layer to host the entity container classes and the EF Core context class.
A service layer is then used to apply logic to entities, which is done through interfaces and extensions. A Repository pattern is used
to form a 'connection' through the [TicketPageService]() class, which acts as the core entry point of the system ([See Diagrams for more info](#class-diagrams)).


## Table of Content
| Nr. |               Namespace              |                 Note                 |
|-----|--------------------------------------|--------------------------------------|
|  1  | [SKP.TicketPage.Domain](LinkToWiKiPage) | _The project that contains the context class and entities. Shouldn't contain any logic unless it's context related_ |
|  2  | [SKP.TicketPage.Services](LinkToWiKiPage) | _Contains all service related functionality (Repositories, extensions etc.)_
|  3  | [Log Storage](WikiPages/LogStorage.md)                        | HOw the log systems stores exceptions and how they're maintained and accessed 

## Related Articles
| Nr. |                Name                |                About               |
|-----|------------------------------------|------------------------------------|
|  1  | [9 Best Practices for REST API Development (_Partech.nl_)](https://www.partech.nl/nl/publicaties/2020/07/9-trending-best-practices-for-rest-api-development#) | _Describes common practices for forming REST APIs. The API project is build with some of the principals from thhis article in mind_ |
|  2  | [Best Practices for REST API Design (_StackOverflow.blog, John-AU-Yeung & Ryan Donovan_)](https://stackoverflow.blog/2020/03/02/best-practices-for-rest-api-design/) | _A more in depth article describing the same principals as the article above. However it also mentions additional principals that are considered while designing the API._ |
