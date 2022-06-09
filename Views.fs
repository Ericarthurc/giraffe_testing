namespace DashingOwl

module Views =
    open System
    open System.Net
    open Giraffe.ViewEngine


    let navbar =
        div [ _class "navbar-container" ] [
            nav [ _class "navbar"; _id "navbar" ] [
                div [ _class "navbar-title-container" ] [
                    a [ _class "navbar-title"; _href "/" ] [
                        str "Dashing Owl"
                    ]
                ]
                div [ _class "navbar-link-container" ] [
                    a [ _class "navbar-link"
                        _href "/series" ] [
                        str "Series"
                    ]
                    a [ _class "navbar-link"; _href "/about" ] [
                        str "About"
                    ]
                ]
            ]
        ]

    let highlightScript =
        script [ _type "application/javascript"
                 _src "/public/js/highlight.min.js" ] []

    let highlightAll =
        script [ _type "application/javascript" ] [
            rawText
                """
                        hljs.highlightAll();
                    """
        ]

    let master (markdown: string) =
        html [] [
            head [] [
                link [ _rel "preconnect"
                       _href "https://fonts.googleapis.com" ]
                link [ _rel "preconnect"
                       _href "https://fonts.gstatic.com"
                       _crossorigin "" ]
                link [ _rel "stylesheet"
                       _href "https://fonts.googleapis.com/css2?family=Lato:wght@100;300;400;700&display=swap" ]
                link [ _rel "stylesheet"
                       _href "/public/styles/main.css" ]
                title [] [ str "Testy Boi " ]
            ]
            body [] [
                navbar
                rawText markdown
                highlightScript
                highlightAll
            ]
        ]
