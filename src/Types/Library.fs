namespace Interop.FSharp

type CustomError = String

module Functions = 
    let hello x = $"Hello {x}"
