namespace DashingOwl

module HttpHandlers =
    open Microsoft.AspNetCore.Http
    open Microsoft.Net.Http.Headers
    open Giraffe

    let handlerTest (blog: string) : HttpHandler =
        fun (next: HttpFunc) (ctx: HttpContext) ->
            let fileContent = Parser.getFileContent (blog)
            let meta = Parser.getMetaFromFileContent (fileContent)
            let post = Parser.getHTMLFromMarkdown (fst fileContent)
            (post |> Views.master |> htmlView) next ctx
