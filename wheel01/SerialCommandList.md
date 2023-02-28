# Serial Communication Protocol

Format: `COMMAND:value;`

Example: `E:274;`

Current configuration is PC as master and Pico as slave.
Pico will never send anything unless requested by PC.

PC will periodically send force feedback magnitude and Pico will reply back with encoder position.

## From Pico to PC

| Command | Value Type | Value Range | Description |
| --- | --- | --- | --- |
| E | int (32 bit) | `-2147483648` ~ `2147483647` | Encoder position. Already multiplied by over rotation and have offset applied. |

## From PC to Pico

| Command | Value Type | Value Range | Description |
| --- | --- | --- | --- |
| F | int | `-10000` ~ `10000` | Force feedback magnitude. |
| C | none | - | Ask Pico to save current position as zero. |
| P | float | `0.00` ~ `1.00` | Scale voltage being sent to motor. This value will be saved on Pico. |