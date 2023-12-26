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

### Seeing patterns in the Domain Model
- Can types replace documentation?
- Simple Values
    - Primitive types such as string and integers
    - Wrapper types `OrderId` and `ProductCode` - part of the ubiquitous language
    - Wrappers will be called simple types
        - Creating simple types ensures we cannot confuse `OrderId` with `ProductCode`
        - When comparing them we get a compile error
    - Performance cost (memory & efficiency)
- Combination of Values (`AND`)
- Choice (`OR`)
- Workflows -> verbs of the UL
    - Business processes with inputs and outputs

**Persistent identity**
- Objects with persistent identity are called entities
- Objects without persistent identity are called value objects

### A Question of Identity: Value Objects
- No unique identity, interchangeable
- Immutability is required
- Values without identity
- Simple type example

```fsharp
let widgetCode1 = WidgetCode "W1234"
let widgetCode2 = WidgetCode "W1234"
(widgetCode1 = widgetCode2) // true
```

- Complex type example
    - 2 personal names with the same fields are interchangable
```fsharp
let person1 = {firstName="Alex"; lastName="Bennet"}
let person2 = {firstName="Alex"; lastName="Bennet"}
(person1 = person2) // true
```
Even though person1 and person2 have the same name, they might not be the same person.
### A Question of Identity: Entities
- Unique identity
    - Even if I change my name or address, I am still the same person
- They have a life cycle
    - Transformed from one state to the other by various business processes
- The distinction between Value Objects and Entities are context dependent
    - When phones are manufactured, each phone is given a unique serial number
    - When phones are sold, the serial number is not relevant - all phones with the same specs are interchangeable
    - Particular phone sold to a particular customer, the identity of a phone becomes relevant as well
- Entities need to have stable identities despite changes
    - Unique identifier (`OrderId`, `CustomerId`)
        - Natural (serial number, etc)
        - Artifical (UUID)
- Equality if the identifiers are the same

### Aggregates

- Collection of entities/domain objects/related objects; `Order` and `OrderLine`
    - Can be treated as a single unit
    - Changes to the `OrderLine` (price update to one of them) will create a ripple effect due to immutability and also change the `Order` itself
    - The top-level entity is `Order` - aggregate root
- Enforce consistency and invariants (integrity)
    - When data is updated in one part of the aggregate, other parts might also need updating
    - **Consistency boundary**
- If the line price changes on an order line level, the total price might need to change on an order level
- Invariants are enforced
    - Every order has at least one line item
    - When deleting multiple lines, the aggregate ensures there is an error when only one item is left
- **Aggregate References**
    - Add a `CustomerId` to the `Order` not the whole `Customer` to avoid the ripple effect of updating the `Customer` as well when the order changes
    - `Customer` and `Order` are distinct and independent aggregates
- Atomic unit of persistence, database transactions, and data transfer
    - Serialization - send the whole aggregate not just parts of them

## Chapter 6 - Integrity and Consistency in the Domain
