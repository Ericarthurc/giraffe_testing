namespace DashingOwl

open System.IO
open Markdig
open Markdig.Extensions.AutoIdentifiers

type Meta =
    { Filename: string
      Title: string
      Date: string
      Tags: string list
      Series: string }


module Parser =

    let getValue (line: string) =
        match line.Split ":" with
        | [| key; value |] -> value.Trim()
        | _ -> failwith "Bad format"

    let getValues (line: string) =
        let value = (getValue line)

        value.Split ","
        |> Array.map (fun s -> s.Trim())
        |> Array.toList

    let parseEntry (fileName: string) ([| title; date; tags; series |]) =
        { Filename = fileName
          Title = getValue title
          Date = getValue date
          Tags = getValues tags
          Series = getValue series }

    let getMetaFromFileContent (content: string, fileName: string) : Meta =
        content.Split("\n")
        |> Seq.skip 1
        |> Seq.take 4
        |> Seq.toArray
        |> parseEntry fileName

    let getHTMLFromMarkdown (content: string) =
        let bone =
            MarkdownPipelineBuilder()
                .UseAutoIdentifiers(AutoIdentifierOptions.GitHub)
                .UsePipeTables()
                .Build()

        Markdown.ToHtml(content.Split("---").[2].Trim(), bone)

    let getFileContent (fileName: string) : (string * string) =
        (File.ReadAllText $"BlogPosts/{fileName}.md", fileName)
