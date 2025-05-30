# Frogg Swingg
Game about swinging parkour frogs 🐸
## Controls
### Jump
- **Right Click + Hold** = Charge Jump

- **Right Click + Release** = Jump

### Tongue
- **Left Click** = Project Tongue

- **Left Click + Release** = Retract Tongue

## Script Architecture
### 3 Abstraction Layers
#### Controller Layer
This is an INPUT layer that *maps* the **device inputs** <br>
to the relevant **game objects**.
#### Object Layer
This is a BRIDGE layer that *separates* complex object implementation logic, <br>
and offers in exchange a public *high-abstraction* function.
#### Component Layer
This layer IMPLEMENTS an object's Transforms, Physics, Collisions, Drawing, Animation, etc. <br>
Basically any **visible** or **audible** changes in the game world.

### Frogg System Architecture
![🐸Froggy - Design Board - Frog Architecture 1](https://github.com/user-attachments/assets/5d36d700-c3b4-4e9c-adc2-a7fe1bef7ec5)

