# Temporal Data Structures

A data structure designed for advanced temporal manipulation and time reversal in game development.

### Core Concept

This system is built for games that require more than just saving and loading. It records a continuous history of actions and states, allowing the game engine to move both forward and backward through time.

This allows for complex gameplay mechanics where a complete, moment-by-moment history of the game world is needed to resolve in-game logic.

### How It Works

The system uses a two-dimensional node structure to track object states across time.

#### 1. Horizontal Timelines (Per-Object)
* Every tracked object has its own timeline, which is a **doubly linked list**.
* Each node in the list stores an object's state (like **position** and **rotation**) and has pointers to its `past` and `next` nodes.
* When time moves forward, new nodes are added to the end of the list. When time reverses, the structure is traversed backward.

#### 2. Vertical Time-steps (Per-Frame)
* To capture the entire world state at a single moment, nodes from the same **time-step** across all object timelines are linked together vertically.
* These vertical connections are stored in an `ArrayList`, which allows for **fast, indexed retrieval** of every object's state at any point in time.

This dual-axis design makes it possible to both replay an individual object's history and reconstruct the entire scene instantly.

###  Project Status: Prototype

This repository contains the initial prototype for this system. It was built as a proof-of-concept for my game, *Paradox*, and has bugs that were fixed in the final version. It's shared here for illustrative purposes.
