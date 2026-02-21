# Assumptions

## Step 1

- For "all dimensions size", the assumptions made was that every parcel has a Length, Height and Width.
- For the keeping tracking Cost, a Money was class was created with a currency of "NZD", for a Zero value.
- For the Quote class. An assumption was made the line items returned are final and immutable

## Step 2

- Speedy shipping is an optional flag passed into Calculate() and applies to the entire order, not individual parcels.
- When enabled, a separate order-level line item called “Speedy shipping” is added with a cost equal to the pre subtotal.
