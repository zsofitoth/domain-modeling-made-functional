namespace OrderTakingSystem.PlaceOrderWorkflows
open OrderTakingSystem.Domain

// Order life cycle

type ValidatedOrderLine = Undefined
type ValidatedOrder = {
    OrderId: OrderId;
    CustomerInfo: CustomerInfo;
    ShippingAddress: Address;
    BillingAddress: Address;
    OrderLines: ValidatedOrderLine list;
} 
and OrderId = Undefined
and CustomerId = Undefined
and CustomerInfo = Undefined
and Address = Undefined

type PricedOrderLine = Undefined
type PricedOrder = Undefined

type Order = 
    | Unvalidated of UnvalidatedOrder
    | Validated of ValidatedOrder
    | Priced of PricedOrder

// Definitions of internal steps
type CheckProductCodeExists = ProductCode -> boolean
type AddressValidationError = Undefined
type CheckAddress = Undefined
type CheckAddressExists = UnvalidatedAddress -> AsyncResult<CheckAddress, AddressValidationError>

type ValidateOrder = 
    CheckProductCodeExists //dependency
    -> CheckAddressExists //dependency
    -> UnvalidatedOrder // input
    -> AsyncResult<ValidatedOrder, ValidationError list>
and ValidationError = Undefined

type GetProductPrice = ProductCode -> Price
type PricingError = Undefined

type PriceOrder =  
    GetProductPrice //dependency
    -> ValidatedOrder //input
    -> Result<PricedOrder, PricingError>
