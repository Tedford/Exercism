module ProteinTranslation

let proteins = [("AUG","Methionine");
                ("UUU", "Phenylalanine");
                ("UUC", "Phenylalanine");
                ("UUA", "Leucine");
                ("UUG", "Leucine");
                ("UCU", "Serine");
                ("UCC", "Serine");
                ("UCA", "Serine");
                ("UCG", "Serine");
                ("UAU", "Tyrosine");
                ("UAC", "Tyrosine");
                ("UGU", "Cysteine");
                ("UGC", "Cysteine");
                ("UGG", "Tryptophan");
                ] |> Map.ofList

let translate polypeptide = 
    List.unfold (fun sequence -> 
        if System.String.IsNullOrWhiteSpace(sequence) 
        then None 
        else 
            let codon =sequence.Substring(0,3)
            match codon with
            | "UAA" | "UAG" | "UGA" -> None
            | _-> Some(codon, sequence.Substring(3)) 
        ) polypeptide
    |> List.map (fun codon -> proteins.[codon])