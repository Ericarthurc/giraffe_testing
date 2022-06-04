namespace DashingOwl

module HttpHandlers =
    open Microsoft.AspNetCore.Http
    open Microsoft.Net.Http.Headers
    open Giraffe

    let handlerTest (id: string) : HttpHandler =
        fun (next: HttpFunc) (ctx: HttpContext) -> (id |> Views.master |> htmlView) next ctx
