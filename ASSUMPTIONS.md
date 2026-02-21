# Assumptions

## Step 1

- For "all dimensions size", every parcel has a Length, Height and Width.
- Keeping track of the Cost. A Money was class was created with a default currency of "NZD", for a Zero value.
- For the Quote class. An assumption was made the line items returned are final and immutable.

## Step 2

- Speedy shipping is an optional flag passed into Calculate() and applies to the entire order, not individual parcels.
- When enabled, a separate order-level line item called “Speedy shipping” is added with a cost equal to the pre subtotal.

## Step 3

- Each parcel now includes a required Weight property.
- A $2 kg surcharge applies only to the weight exceeding the size specific weight limit.

## Step 4

// To do

## Step 5

// To do