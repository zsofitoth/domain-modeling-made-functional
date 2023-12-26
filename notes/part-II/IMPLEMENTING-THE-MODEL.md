# Modeling the Domain

## Chapter 4 - Understanding Types

- Represent the requirements using F#'s algebraic type system
- Function: apple -> banana
- Type - set of possible values that can be used as inputs or outputs of a function
    - Determines the function's signature

**Jargon:**
- Values
    - Immutable
    - Functional paradigm
- Variables
    - Mutable
- Objects
    - Encapsulation of data structures and it's associated behaviour (methods)
    - Have state (mutable)


### Composition of Types
- Combine 2 things to make a bigger thing
- `AND` - product type, `OR` - sum type/discriminated unions
- Record type
    - Fruit salad = 🍎 `AND` 🍌 `AND` 🍒
```fsharp
type FruitSalad = {
    Apple: AppleVariety;
    Banana: BananaVariety;
    Cherry: CherryVariety;
}
```
- Choice type
    - Fruit snack = 🍎 `OR` 🍌 `OR` 🍒
```fsharp
type FruitSalad = 
    | Apple of AppleVariety
    | Banana of BananaVariety
    | Cherry of CherryVariety
```

Algebraic type system = every compound type is composed from smaller types by `AND`ing or `OR`ing them together

### Modeling Optional Values, Errors, and Collections

- Optional Values: `Option` (`Some`, `None`)
- Errors: `Result` (`Ok`, `Err`)
- No values at all: `unit`

## Chapter 5 - Domain Modeling with Types