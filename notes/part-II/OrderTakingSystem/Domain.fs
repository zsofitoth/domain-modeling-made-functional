namespace OrderTakingSystem.Domain
// Value Objects
type WidgetCode = WidgetCode of string // constraint: starting with "W" then 4 digits
type GizmoCode = GizmoCode of string // constraint: starting with "G" then 3 digits
type ProductCode = 
    | Widget of WidgetCode
    | Gizmo of GizmoCode


type UnitQuantity = UnitQuantity of int // constraint: integer between 1 and 1000
type KilogramQuantity = KilogramQuantity of decimal // constraint: decimal between 0.05 and 100.00 
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

type Order = {
    Id: CustomerId;
    CustomerId: CustomerId;
    ShippingAddress: ShippingAddress;
    BillingAddress: BillingAddress;
    OrderLines: OrderLine list;
    AmountToBill: BillingAmount;
}

type OrderLine = {
    Id: OrderLineId;
    OrderId: OrderId;
    ProductCode: ProductCode;
    OrderQuantity: OrderQuantity;
    Price: Price;
}

// Workflows

type UnvalidatedOrder = {
    OrderId: string;
    // CustomerInfo: 
    // ShippingAddress: 
    // ...
}

type PlaceOrderEvents = {
    // AcknowledgementSent: 
    // OrderPlaced: 
    // BillableOrderPlaced: 
}

type PlaceOrderError = 
    | ValidationError of ValidationError list
    // | other errors
and ValidationError = {
    FieldName: string;
    ErrorDescription: string;
}

type PlaceOrder =
    UnvalidatedOrder -> Result<PlaceOrderEvents, PlaceOrderError>
