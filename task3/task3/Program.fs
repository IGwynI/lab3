open System
open System.IO

[<EntryPoint>]
let main argv =
    // Путь к каталогу
    let path =
        printf "Введите путь к каталогу: "
        Console.ReadLine().Trim()

    if Directory.Exists(path) then
        let files = Directory.EnumerateFiles(path) |> Seq.map Path.GetFileName

        if Seq.isEmpty files then
            printfn "В каталоге нет файлов."
        else
            let shortest = files |> Seq.minBy (fun name -> name.Length)
            printfn "Самое короткое название файла: %s" shortest
    else
        printfn "Каталог не существует"

    0