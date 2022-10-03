#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SKP.TicketPage.Web/SKP.TicketPage.Web.csproj", "SKP.TicketPage.Web/"]
COPY ["SKP.TicketPage.Services/SKP.TicketPage.Services.csproj", "SKP.TicketPage.Services/"]
COPY ["SKP.TicketPage.Domain/SKP.TicketPage.Domain.csproj", "SKP.TicketPage.Domain/"]
RUN dotnet restore "SKP.TicketPage.Web/SKP.TicketPage.Web.csproj"
COPY . .
WORKDIR "/src/SKP.TicketPage.Web"
RUN dotnet build "SKP.TicketPage.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SKP.TicketPage.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SKP.TicketPage.Web.dll"]