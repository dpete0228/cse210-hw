# Nephite Lamanite Battle Simulator

## Overview

This is a console-based battle simulator inspired by the conflicts between the Nephites and Lamanites as described in the Book of Mormon. You can create your own armies by specifying the number of different unit types for both sides and then watch the battle unfold round by round. The simulator tracks health, attack power, defense, morale, and special unit abilities, culminating in a victor when one army retreats.

**Abstraction:** The program is divided into classes (`Army`, `Warrior`, and specific unit types) each with a single, well-defined responsibility.
**Encapsulation:** Warrior statistics (health, attack, defense, morale) are kept private within their classes, accessed and modified through controlled public methods.
**Inheritance:** Specific warrior types (e.g., `ChiefCaptain`, `LamaniteKing`) inherit common behaviors and attributes from the base `Warrior` class.
**Polymorphism:** The `Defend` and `Attack` methods are overridden in derived warrior classes to implement unique behaviors for different unit types.


## Features

* **Army Creation:** Define the size and composition of both the Nephite and Lamanite armies by choosing the number of each unique unit type.
* **Turn-Based Simulation:** Watch the battle progress in rounds, with each surviving warrior getting a chance to attack.
* **Unit Variety:** Includes several distinct unit types for both the Nephites and Lamanites, each with their own stats and potential special abilities (e.g., Ammonite resilience, King-Men switching sides, Lamanite King's damage negation).
* **Morale System:** Armies can retreat if their morale drops too low or if they suffer too many casualties. Morale is affected by damage taken and the loss of leaders.
* **Traitor Mechanic:** King-Men units have a chance to switch sides when attacked by Dissenters, adding an element of unpredictability to the battles.
* **Detailed Statistics:** After each round, the simulator displays key statistics for both armies, including the number of healthy, injured, dead, and retreated warriors, as well as the current army morale.

## Unit Types

### Nephites

* **Chief Captain:** Health: 100, Attack: 30, Defense: 20, Morale: 100. A strong leader unit with high attack power and excellent morale.
* **Captain:** Health: 100, Attack: 30, Defense: 15, Morale: 75. A capable sub-leader, providing a good balance of offense and defense.
* **Ammonite:** Health: 100, Attack: 15, Defense: 10, Morale: 65. Known for their resilience, Ammonites have a chance to return to the fight after being downed for a random number of rounds, regaining 50 health.
* **King Man:** Health: 100, Attack: 20, Defense: 30, Morale: 60. Defensively sturdy units who have a 1/3 chance of switching sides when attacked by a Dissenter.
* **Nephite Warrior:** Health: 100, Attack: 20, Defense: 10, Morale: 50. The standard infantry unit of the Nephite army.

### Lamanites

* **Lamanite King:** Health: 100, Attack: 30, Defense: 15, Morale: 80. The leader of the Lamanite army, possessing strong attack power and a 1/5 chance to negate incoming damage.
* **Lamanite Commander:** Health: 100, Attack: 30, Defense: 10, Morale: 50. An offensively focused leader unit for the Lamanite forces.
* **Dissenter:** Health: 100, Attack: 30, Defense: 12, Morale: 60. A formidable attacking unit with the unique ability to potentially cause King-Men in the opposing army to switch sides upon attacking them.
* **Lamanite Warrior:** Health: 100, Attack: 15, Defense: 7, Morale: 45. The basic infantry unit of the Lamanite army.


