namespace DashingOwl

module Program =
    open System
    open System.IO
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Hosting
    open Microsoft.Extensions.Hosting
    open Microsoft.Extensions.Logging
    open Microsoft.Extensions.DependencyInjection
    open Microsoft.Extensions.FileProviders
    open Giraffe
    open Giraffe.EndpointRouting

    let configureServices (services: IServiceCollection) = services.AddGiraffe() |> ignore

    let configureApp (app: IApplicationBuilder) =
        app
            .UseStaticFiles(
                StaticFileOptions(
                    FileProvider =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Public/root")),
                    RequestPath = ""
                )
            )
            .UseStaticFiles(
                StaticFileOptions(
                    FileProvider =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Public/static")),
                    RequestPath = "/public"
                )
            )
            .UseRouting()
            .UseGiraffe(Router.endpoints)
        |> ignore

    [<EntryPoint>]
    let main _ =
        Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(fun webHostBuilder ->
                webHostBuilder
                    .UseUrls("http://0.0.0.0:1234")
                    .UseWebRoot("public")
                    .Configure(configureApp)
                    .ConfigureServices(configureServices)
                |> ignore)
            .Build()
            .Run()

        0
