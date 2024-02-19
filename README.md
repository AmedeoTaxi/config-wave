# Description

Trying to make some sort of library that can procedurally generate any kind of things with the "Wave function collapse" algorithm. The idea is to have a system that reads a configuration, and uses that configuration to generate the output.

## Configuration

The configuration should have:
1. how many dimensions should the output have
2. what are the possible states
3. what are the rules for each state (_bonus_: instead of using a specific "0-1" rule (i.e. state `A` can/cannot be near state `B`), it is possible to define a real probability value)

### Extra

#### Rotation

A description of the rotation for each state: every state can have a specific rotation, so it will need a rule for each side (thinking in squares)

#### Probability

Instead of using a specific "0-1" rule (i.e. state `A` can/cannot be near state `B`), it is possible to define a real probability value. The function collapse will occur based on those probabilities.
