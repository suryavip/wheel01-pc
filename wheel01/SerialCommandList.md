# Serial Communication Protocol

Format: `COMMAND:value;`

Example: `E:274;`

## From Arduino to PC

| Command | Value Type | Value Range | Description |
| --- | --- | --- | --- |
| E | int | 0 - 4095 | Encoder position |

## From PC to Arduino

| Command | Value Type | Value Range | Description |
| --- | --- | --- | --- |
| C | none | - | Connection initiated by PC |