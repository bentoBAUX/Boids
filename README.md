# Boid Behaviour Simulation
<p align="center">
  <img src="https://github.com/bentoBAUX/Boids/blob/main/Assets/GIF/Boids.gif" alt="Boids.GIF" />
</p>

## Overview
Inspired by Sebastian Lague's mesmerising [Boids project](https://www.youtube.com/watch?v=bqtqltqcQhw), I set out to challenge myself by simulating flocking behaviour, such as that of birds or fish. This project features a flexible system that allows real-time control over flocking behaviours via the Unity inspector, providing a dynamic and interactive simulation experience.

## How It Works

1. **Neighbour Detection:** Each Boid detects nearby neighbours within its field of view (FOV) and proximity thresholds.
2. **Behaviour Calculation:** The `Rule Manager` dynamically calculates the influence of active behaviours—such as **Separation**, **Alignment**, and **Cohesion**—and combines them into a single steering vector.
3. **Steering Application:** The resultant steering vector is normalised and applied to the Boid, determining its movement direction in the next frame.
4. **Boundary Handling:** The wrapping mechanism ensures that Boids stay within a spherical boundary by re-entering from the opposite side when they leave.

With the core mechanics established, here are the key features that define the behaviour of the Boids in the simulation.

## Key Features

### **Separation**
- Prevents overcrowding by steering Boids away from neighbours within a specified threshold.

### **Alignment**
- Aligns the direction of a Boid with the average direction of nearby Boids to maintain coordinated movement.

### **Cohesion**
- Pulls Boids towards the centre of mass of nearby neighbours, ensuring the flock stays together.

### **Leadership**
- Identifies and follows a leader Boid, chosen based on the angle between its direction and the follower’s forward vector.

### **Field of View (FOV)**
- Limits the Boids' perception to neighbours within a defined cone of vision, based on the FOV angle.

### **Wrapping**
- Ensures Boids stay within a spherical boundary. When a Boid exits the sphere, it re-enters from the opposite side, maintaining spatial constraints.

## Project Structure

The simulation is powered by three key scripts, each responsible for a specific aspect of the Boids' behaviour:

### 1. **`BoidBehaviour.cs`**
- Assigned to each Boid GameObject to manage its movement and steering.
- Handles forward movement at a speed determined by the BoidController and updates direction based on steering inputs.
- Smoothly rotates the Boid towards the cumulative steering direction using a configurable steering speed.

### 2. **`BoidController.cs`**
- Spawns Boids within a specified radius, assigning random positions and rotations for natural variation.
- Defines and provides the speed range for Boids, which is utilised by the BoidBehaviour script.
- Links global simulation settings to individual Boids, ensuring consistent behaviour.

### 3. **`RuleManager.cs`**
- Applies flocking behaviours defined in the `Rules` script.
- Dynamically calculates and combines the influences of **Separation**, **Alignment**, **Cohesion**, and **Leadership**.
- Interprets the rules based on the inspector settings and applies them to each Boid.

These scripts work together seamlessly to produce coordinated and realistic flocking dynamics.

## Usage

As a UI system has not been implemented yet, you will need to clone the project and open it in Unity to run the simulation.

Boid behaviour can be configured in real time via the `Boid Manager` component in the scene. Below are the key inspector settings for customisation.

## Inspector Configuration

### **Boid Controller**
- **Min Speed / Max Speed:** Defines the speed range for Boids.
- **Spawn Radius:** Determines the radius within which Boids spawn.
- **Spawn Count:** Sets the number of Boids in the simulation.
- **Boid Prefab:** References the Boid GameObject prefab.

### **Rule Manager**
- **Rules Menu:** Toggles individual behaviours (Separation, Alignment, Cohesion, Leadership, Wrap).
- **Rules Settings:**
  - **FOV Angle:** Specifies the angular range of the Boid’s vision.
  - **Separation Threshold / Proximity Threshold:** Controls the distance thresholds for interactions, with larger values leading to greater separation.
  - **Behaviour Weights:** Adjusts the influence of each behaviour (e.g., Separation Weight, Alignment Weight).
- **Wrap Settings:**
  - **Wrap Radius:** Sets the boundary of the wrapping sphere.
  - **Wrap Origin:** Defines the centre point of the sphere.

## License
This project is licensed under the MIT Licence. See the [LICENSE](https://github.com/bentoBAUX/Boids/blob/main/LICENSE) file for details.

