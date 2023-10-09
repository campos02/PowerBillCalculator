# PowerBillCalculator
Simple Avalonia app that calculates a power bill. Calculations are based on kWh cost and taxes that get added to the final bill.

Can be compiled for desktop and Android.

# Use
* Results are displayed as valid inputs are given.
* Last reading is subtracted from current when calculating. To use a single kWh value, fill the latter while leaving the former empty.

### First use
The default settings for all parameters is zero, so on first use it's necessary to set them via the settings page, which is accessible through the bottom right button.

## Settings
Both values used for calculation are customizable and saved locally.

## Currency format
Currency is displayed based on device region settings, e.g. on a US device the dollar format is used.
