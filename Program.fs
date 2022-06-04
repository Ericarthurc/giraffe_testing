namespace DashingOwl

module Program =
    open System
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Microsoft.Extensions.Hosting
    open Microsoft.Extensions.Logging
    open Microsoft.Extensions.DependencyInjection
    open Giraffe
    open Giraffe.EndpointRouting

    let configureServices (services: IServiceCollection) = services.AddGiraffe() |> ignore

    let configureApp (app: IApplicationBuilder) =
        app
            .UseStaticFiles()
            .UseRouting()
            .UseGiraffe(Router.endpoints)
        |> ignore

    [<EntryPoint>]
    let main _ =
        Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(fun webHostBuilder ->
                webHostBuilder
                    .UseWebRoot("public")
                    .Configure(configureApp)
                    .ConfigureServices(configureServices)
                |> ignore)
            .Build()
            .Run()

        0
