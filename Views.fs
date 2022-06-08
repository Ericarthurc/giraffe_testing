namespace DashingOwl

module Views =
    open System
    open System.Net
    open Giraffe.ViewEngine


    let partial =
        nav [] [
            a [ _href "./test" ] [ str "Test Link" ]
        ]

    let master (markdown: string) =
        html [] [
            head [] [
                link [ _rel "stylesheet"
                       _href "https://fonts.googleapis.com/css2?family=Inter:wght@100;300;500;700&display=swap" ]
                link [ _rel "stylesheet"
                       _href "/styles/main.css" ]
                link [ _rel "stylesheet"
                       _href "/styles/markdown.css" ]
                title [] [ str "Testy Boi " ]
            ]
            body [] [
                partial
                rawText markdown
                script [ _type "application/javascript"
                         _src "/js/highlight.min.js" ] []
                script [ _type "application/javascript" ] [
                    rawText
                        """
                        hljs.highlightAll();
                    """
                ]
            ]
        ]
