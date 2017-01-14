module Triangle


type TriangleKind = Equilateral | Isosceles | Scalene

let kind s1 s2 s3 =
    match (s1,s2,s3) with
    | _ when s1 <= 0m || s2 <= 0m|| s3 <= 0m-> invalidOp "The length of a side must be greater than 0"
    | _ when s1 + s2 < s3 || s1 + s3 < s2 || s2 + s3 < s1 -> invalidOp "Triangle inequality theorem violated"
    | _ when s1 = s2 && s1=s3-> TriangleKind.Equilateral
    | _ when s1 = s2 || s2 = s3 || s1 = s3 -> TriangleKind.Isosceles
    | _ -> TriangleKind.Scalene
