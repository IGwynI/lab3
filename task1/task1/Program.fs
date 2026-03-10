open System

// Чтение целого положительного числа
let rec readNatural message =
    printf "%s" message
    match Int32.TryParse(Console.ReadLine()) with
    | true, value when value > 0 -> value
    | _ ->
        printfn "Ошибка: введите целое положительное число (x>0)"
        readNatural message

// Функция поиска минимальной цифры числа
let rec minDigit number mini =
    if number > 0 then
        let lastDigit = number % 10
        if lastDigit < mini then 
            minDigit (number / 10) lastDigit
        else 
            minDigit (number / 10) mini
    else 
        mini

[<EntryPoint>]
let main argv =
    printf "Введите количество элементов последовательности: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, count when count >= 0 ->
        let numbers = 
            seq {
                for i in 1 .. count do
                    yield readNatural (sprintf "Введите элемент %d: " i)
            }
            |> Seq.cache

        let minDigits = numbers |> Seq.map (fun x -> minDigit x 9)

        printfn "Исходная последовательность: %A" (numbers |> Seq.toList)
        printfn "Минимальные цифры: %A" (minDigits |> Seq.toList)

    | _ ->
        printfn "Ошибка: количество элементов не может быть отрицательным"
    0