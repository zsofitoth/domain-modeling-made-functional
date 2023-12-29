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

- Adapter functions (passthrough)
    - Function transformer
    - `map`

```fsharp
val predicatePassthru : errorMsg: string -> f: ('a -> bool) -> x: 'a -> 'a
```

- When shapes don't match because "internal dependencies" as parameters
    - Partial application is the solution

### Injecting dependencies
- We always want to pass around dependencies as explicit parameters
    - "Reader Monad"
    - "Free Monad"
- Simplest approach - pass all dependencies to the top level function which in then turn passes them down to the inner functions and those pass them down to their inner functions
- Composition root
- Too many dependencies?
    - Function is doing too many things
        - Split them up?
    - Group dependencies into a single record
- Reducing parameters by passing in "prebuilt" helper functions
    - Interface of the function type should be minimal
- Testing dependencies - mocking becomes easy


## Chapter 10 - Implementation: Working with Errors

Errors should be like explicit documentation in the code about what can go wrong.

Error Types:
- Domain errors; to be expected as part of the business process
- Panics; leaves system in an unknown state
    - Divide by zero
    - Out of memory
    - `raise` and escelate; abandon workflow
- Infrastructure errors; errors to be expected as part of the architecture
    - Mix of both
    - Can be of interest to the domain expert

[Railway Oriented Programming](https://fsharpforfunandprofit.com/rop/)
- https://vimeo.com/113707214

## Chapter 11 - Serialization

## Chapter 12 - Persistence 

## Chapter 13 - Evolving a Design and Keeping it Clean