namespace DashingOwl

module Views =
    open System
    open System.Net
    open Giraffe.ViewEngine

    let partial =
        nav [] [
            a [ _href "./test" ] [ str "Test Link" ]
        ]

    let master (id: string) =
        html [] [
            head [] [
                title [] [ str "Testy Boi " ]
            ]
            body [] [ partial; h2 [] [ str id ] ]
        ]
