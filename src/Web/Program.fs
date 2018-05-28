module BeerApp.Web

open System
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.EntityFrameworkCore
open Giraffe
open BeerApp.Domain.Models
open BeerApp.Domain.Contracts
open BeerApp.Data

let getBreweriesHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let breweryRepository = ctx.GetService<IRepository<Brewery>>()
            let! breweries = breweryRepository.Get()
            let breweryNames = breweries |> Seq.map (fun brewery -> brewery.Name)
            let returnStr =
                match Seq.isEmpty breweryNames with
                | true -> "No breweries"
                | false -> breweryNames |> Seq.fold (fun acc breweryName -> acc + breweryName + Environment.NewLine) String.Empty
            return! text returnStr next ctx
        }

let webApp =
    choose [
        route "/" >=> text "Hello World"
        route "/breweries" >=> getBreweriesHandler
    ]

let configureApp (app: IApplicationBuilder) =
    app.UseGiraffe webApp

let configureServices (services: IServiceCollection) =
    services.AddGiraffe() |> ignore

    services.AddDbContext<BeerAppDbContext>(fun options ->
            options.UseNpgsql("Server=localhost;Database=giraffe-test") |> ignore)
        .AddScoped<IRepository<Brewery>, Repository<Brewery>>() |> ignore

[<EntryPoint>]
let main _ =
    let host =
        WebHost.CreateDefaultBuilder()
            .Configure(Action<IApplicationBuilder> configureApp)
            .ConfigureServices(configureServices)
            .Build()

    using (host.Services.CreateScope()) (fun scope ->
        let services = scope.ServiceProvider
        let context = services.GetService<BeerAppDbContext>()
        context.Database.EnsureCreated() |> ignore
    )

    host.Run()
    0
