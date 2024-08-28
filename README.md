# Examples of implementing design patterns in Unity

## 1. Assets\Patterns Realizations Examples\Example 01. Weapon Types (Template Method)

Design patterns: Template Method

Different types of weapons either fire with infinite ammo or with limited ammo.

## 2. Assets\Patterns Realizations Examples\Example 02. Seller (Strategy)

**Design patterns: Strategy**

The vendor sells different items to the player depending on their age

## 3. Assets\Patterns Realizations Examples\Example 03. Ball Game (Strategy & Template Method)

**Design patterns: Strategy, Mediator, Template Method**

In the bubble game, the player wins if all the bubbles are popped or if only bubbles of a single color are popped. Before starting the game, players can choose the rules.
Scene loading and settings transfer between them are organized through ZenjectSceneLoader.

## 4. Assets\Patterns Realizations Examples\Example 04. Robot Kyle (Finite State Machine)

**Design patterns: State**

Robot Kyle patrols waypoint locations and performs one of 3 random actions upon arrival at a waypoint:

- Waiting
- Dancing
- Floor exercise

## 5. Assets\Patterns Realizations Examples\Example 05. Robot Jamo (Finite State machine)

**Design patterns: Hierarchical State Machine**

Implemented player control over Robot Jamo based on a state hierarchy.

## 6. Assets\Patterns Realizations Examples\Example 06. UI Clicker (Mediator)

**Design patterns: Mediator**

Simple clicker game. There are two buttons: take damage and gain experience. As experience increases, the player's level rises. With each level-up, the maximum health capacity increases.
When the level increases, lost health is fully restored. If health reaches 0, the game ends and the player is prompted to restart the game.
UI data is managed using the Mediator.

## 7. Assets\Patterns Realizations Examples\Example 07. Different Design UI (Fabric, Mediator)

**Design patterns: Fabric, Mediator**

The UI displays icons for money and energy. Using a factory, you can change the design and color of these icons

## 8. Assets\Patterns Realizations Examples\Example 08. Character Constructor (Decorator, Fluent Builder, Fabric)

**Design patterns: Decorator, Fluent Builder, Mediator**

Character creator based on race selection, specialization, and abilities. There are three attributes: strength, agility, and intelligence. There are three races: human, elf, and orc.
The specified attributes are unique to each race and are configured through a configuration file. For each race, a specialization can be chosen: rogue, mage, or barbarian.
Additionally, there are skills: chess player, bodybuilder, and morning exercise master.
At the entry point of the scene, several characters are created, and information is output to the console

## 9. Assets\Patterns Realizations Examples\Example 09. Enemies Grid Killer  (Visiter, Fabric, Mediator)

**Design patterns: Visitor, Fabric, Mediator**

There are 4 types of enemies: human, elf, orc, and robot.
A specific number of points is awarded for defeating each type of enemy. The spawner creates enemies according to a predefined grid, taking into account whether a cell is currently occupied.
It also considers the total weight of the generated enemies. If the total weight of all enemies on the scene exceeds a certain threshold, enemy creation is stopped. Each type of enemy has a specific weight.
