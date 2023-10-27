module TracksOnTracksOnTracks

let newList: string list = []

let existingList: string list = ["F#"; "Clojure"; "Haskell"]

let addLanguage (language: string) (languages: string list): string list = language :: languages

let countLanguages (languages: string list): int = languages |> List.length

let reverseList(languages: string list): string list = languages |> List.rev

let excitingList (languages: string list): bool = 
    match languages with
    | "F#" :: tail -> true
    | [_; "F#"] -> true
    | [_; "F#"; _] -> true
    | _ -> false