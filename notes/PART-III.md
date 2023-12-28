# Implementing the Model

Functional Programming - functions are used _everywhere_ for _everything_.
- Composition; gluing functions together
- Higher-Order Functions (or HoFs); functions that input or output other functions or take functions as parameters.
- Currying; in F# every function is curried
    - `'a -> 'b -> 'c`  can also be implemented as `'a -> 'b -> 'c`
    - Partial application is possible (used to do dependency injection)