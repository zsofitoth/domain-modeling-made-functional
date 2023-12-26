# Understanding the Domain

## Chapter 1 - Introduction to DDD

### The idea

- Development team & domain experts & other stakholders <- all share the same mental model
- No translation is required between requirements (from experts) and code (written by developers)
- Shared mental model

### Guidlines
- Focus on events and processes rather than data
- Partition the problem domain into smaller subdomains
- Create a model for each subdomain in the solution
- Develop an "everywhere language" that can be shared between everyone involved in the project

### Concepts
- _Domain_ - area of knowledge associated with the problem we are trying to solve
    - "domain expert" is expert in
    - part of the problem space
- _Domain Model_ - set of simplifications that represent those aspects of a domain that are relevant to the particular problem
    - part of the solution space
- _Ubiquitous Language_ - set of concepts & vocabulary that is associated with the domain
    - shared by the team memebers & the source code
- _Bounded Context_ - subsystem in the solution space with clear boundaries that distinguish from other subsystems
    - often corresponds to a subdomain in the problem space
    - has its own context + vocabulary, its own dialect of the Ubiquitous Language
- _Context Map_ - a high level diagram showing a collection of bounded contexts and the relationship between them
- _Domain event_ - a record of something that happened in the system
    - often triggers additional activity
    - always written in past tense - "New order form received"
- _Command_ - a request for some process to happen and is triggered by a person or another event
    - if it succeeds: the state of the system changes and one or more domain events are recorded
    - an event triggers a command which initiates some business workflow, the output of the workflow are further events that can trigger other commands

### Approach
- Understanding the domain through business events
    - **Domain events**
    - Capture them through design
- **Event storming** to discover domain events

### Case study

**Order-taking System**
- Order taking process is triggered by receiving an order form in the mail
- Workflows for processing a quote, registering a customer, etc.
- When the order-taking team finishes processing the order, an event is triggered the shipping department to start the shipping process and the billing department to start the billing process
- Design process 
    - Discovered 3 subdomains (problem space)
        - Domain experts in billing, shipping and order-taking
    - Defined 3 bounded contexts

![](../assets/spaces.png)

- Context Map

![](../assets/context-map.png)
- Core domain?
    - core
    - supporting
    - generic
- Ubiquitous Language
    - "order form"
    - "quote"
    - "order"

### Misc

**Workflow:** detailed description of part of a business process.
- Lists the exact steps an eployee needs to do to accomplish a business goal
- Divide the overall business process into a series of smaller workflows (which are then coordinated im some way)

**Business Process:** describes the goal the business wants to achieve.
- Business centric focus

**Scenario:** a goal that a customer wants to achieve.
- User centric focus
- Use case: more detailed version of a scenario
    - User interactions & steps the user needs to take to achieve the goal
    - How interactions appear from a user POV.

## Chapter 2 - Understanding the Domain 

## Chapter 3 - A Functional Architecture