# Serial Communication Protocol

Format: `COMMAND:value;`

Example: `E:274;`

Current configuration is PC as master and arduino as slave.
Arduino will never send anything unless requested by PC.

PC will periodically send force feedback magnitude and Arduino will reply back with encoder position.

## From Arduino to PC

| Command | Value Type | Value Range | Description |
| --- | --- | --- | --- |
| E | int | `-32768` ~ `32767` | Encoder position |

## From PC to Arduino

| Command | Value Type | Value Range | Description |
| --- | --- | --- | --- |
| F | int | `-1000` ~ `1000` | Force feedback magnitude |