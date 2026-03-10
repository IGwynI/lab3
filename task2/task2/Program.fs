open System

//Чтение числа
let rec readNatural message =
    printf "%s" message
    match Int32.TryParse(Console.ReadLine()) with
    | true, value when value > 0 -> value
    | _ ->
        printfn "Ошибка: введите целое положительное число (x>0)"
        readNatural message

//Поиск цифры в числе
let rec containsDigit number digit =
    if number = 0 then 
        false
    else
        let last = number % 10
        if last = digit then 
            true
        else 
            containsDigit (number / 10) digit

[<EntryPoint>]
let main argv =
    printf "Введите количество элементов списка: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, count when count >= 0 ->

        let numbers = 
            seq {
                for i in 1 .. count do
                    yield readNatural (sprintf "Введите элемент %d: " i)
            }
            |> Seq.cache

        printfn "Исходная последовательность: %A" (numbers |> Seq.toList)

        printf "Введите цифру для поиска (0-9): "
        match Int32.TryParse(Console.ReadLine()) with
        | true, digit when digit >= 0 && digit <= 9 ->
            let resultCount = Seq.fold (fun acc x -> if containsDigit x digit then acc + 1 else acc) 0 numbers
            printfn "Количество элементов, содержащих цифру %d: %d" digit resultCount

        | _ ->
            printfn "Ошибка: нужно ввести одну цифру от 0 до 9."


    | _ ->
        printfn "Ошибка: количество элементов списка не может быть отрицательным"
    0