# TicketPage Log system

## Description
The [ErrorLogger](SKP.TicketPage.Services/Repositories/ErrorLogger.cs) inherits from [RepositoryBase{T}](SKP.TicketPage.Services/Repositories/RepositoryBase%7BT%7D.cs)
and implements the [IErrorLogger](SKP.TicketPage.Services/Repositories/Interfaces/IErrorLogger.cs) interface. In other words; It's a repository in the context of this application.

This means that all **CRUD** functionality is implemented and ready to be used.

## How to
The logger comes with 4 different types of log methods
- `LogCriticalAsync`: Critical logs should be composed and logged when anything that would break the application would occur.
- `LogExceptionAsync`: Exception logs should be logged when an erro occurs that didn't break the program but is severe enough to cause data corruption or othervise invalidate actions.
- `LogInfoAsync`: Information should only be logged if there's a reason for it. Don't log irrelevant information, such as page navigation or debugs.
- `LogWarningAsync`: Warnings are state changes or data invalidation that doesn't necessarily cause any harm, however, the potential is there.

All methods will return a public representation of the message you just logged. This may also include any exception data that would be passed with the log, so keep that ind mind, however, no stack is formatted and for the most part the public representation will only format the log description.

## Maintenance and Storage
Logs are stored in the SQL database and no **.NET** solution for cleanups is implemented, however, the database itself has a procedure running that periodically perma deletes
logs that are older than 1 month.
