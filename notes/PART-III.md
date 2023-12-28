# Implementing the Model

## Chapter 8

Functional Programming - functions are used _everywhere_ for _everything_.
- Composition; gluing functions together (_piping_) or creating new types by combining other types
- Higher-Order Functions (or HoFs); functions that input or output other functions or take functions as parameters.
- Currying; in F# every function is curried
    - `'a -> 'b -> 'c`  can also be implemented as `'a -> 'b -> 'c`
    - Partial application is possible (used to do dependency injection)
- Total function; every input maps to an output (explicitness)
    - Side effects are documented in the signature

## Chapter 9 - Implementation: Composing a Pipeline

- Composing functions and achieving composition
- Difficulty
    - Extra parameters; dependecies
    - Effect indication; async and error handling

**Goal:**

```fsharp
let placeOrder unvalidatedOrder =
    unvalidatedOrder
    |> validateOrder
    |> priceOrder
    |> acknowledgeOrder
    |> createEvents
```



## Chapter 10 - Implementation: Working with Errors

## Chapter 11 - Serialization

## Chapter 12 - Persistence 

## Chapter 13 - Evolving a Design and Keeping it Clean