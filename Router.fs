namespace DashingOwl

module Router =
    open Microsoft.AspNetCore.Http
    open Microsoft.Net.Http.Headers
    open Giraffe
    open Giraffe.EndpointRouting


    let endpoints: list<Endpoint> =
        [ GET [ route "/" (text "Hello World")
                route "/blog" (text "Blog here!")

                routef "/blog/%s" HttpHandlers.handlerTest

                route "/series" (text "Series")
                route "/about" (text "About") ] ]
