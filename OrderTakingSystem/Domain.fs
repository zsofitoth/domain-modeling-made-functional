namespace OrderTakingSystem.Domain

module Undefined =
    let value<'T> : 'T = failwith "Not implemented yet"

// Value Objects
type WidgetCode = WidgetCode of string // constraint: starting with "W" then 4 digits
type GizmoCode = GizmoCode of string // constraint: starting with "G" then 3 digits
type ProductCode = 
    | Widget of WidgetCode
    | Gizmo of GizmoCode

[<Measure>]
type kg

[<Measure>]
type unit

type UnitQuantity = private UnitQuantity of int<unit> // constraint: integer between 1 and 1000

module UnitQuantity = 
    let create qty =
        if qty < 1<unit> then
            Error "Unit quantity cannot be negative"
        elif qty > 1000<unit> then
            Error "Unit quantity cannot be more than 1000"
        else 
            Ok (UnitQuantity qty)
    
    let value (UnitQuantity qty) = qty

type KilogramQuantity = KilogramQuantity of decimal<kg> // constraint: decimal between 0.05 and 100.00 
type OrderQuantity = 
    | Unit of UnitQuantity
    | Kilo of KilogramQuantity

// Entities
type OrderId = Undefined
type OrderLineId = Undefined
type CustomerId = Undefined

type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type Price = Undefined
type BillingAmount = Undefined

type NonEmptyList<'a> = {
    First: 'a;
    Rest: 'a list;
}

type Order = {
    Id: CustomerId;
    CustomerId: CustomerId;
    ShippingAddress: ShippingAddress;
    BillingAddress: BillingAddress;
    // OrderLines: NonEmptyList<OrderLine>;
    AmountToBill: BillingAmount;
}

type OrderLine = {
    Id: OrderLineId;
    OrderId: OrderId;
    ProductCode: ProductCode;
    OrderQuantity: OrderQuantity;
    Price: Price;
}

type UnvalidatedAddress = Undefined
// type ValidatedAddress = private ...

// Workflows

type UnvalidatedOrder = {
    OrderId: string;
    // CustomerInfo: 
    ShippingAddress: UnvalidatedAddress;
    // ...
}

type PlaceOrderEvents = Undefined
// {
//     // AcknowledgementSent: 
//     // OrderPlaced: 
//     // BillableOrderPlaced: 
// }

type PlaceOrderError = 
    | ValidationError of ValidationError list
    // | other errors
and ValidationError = {
    FieldName: string;
    ErrorDescription: string;
}

type PlaceOrder =
    UnvalidatedOrder -> Result<PlaceOrderEvents, PlaceOrderError>
