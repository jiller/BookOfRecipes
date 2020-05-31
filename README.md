# BookOfRecipes
This is an simple book of recipes implementation

## Solution structure

| Directory | Description |
| ------ | ------------------------------------------------------------ |
| client | Directory with API Client generated during the build process |
| src | Directory with source code of API Client |
| tests | Directory with test projects |

## Used external packages
* MediatR - mostly was used to isolate code which processes query\commands
* AutoMapper - for mapping domain entities to DTOs
* Swagger - to expose UI for API documentation
* NSwag - for API client generation

## Still not implemented

* "Users will have a different level of access". Access rights haven't implemented yet. There're only tables for users and permissions in the database. I planed to use the OpenID Connect Library to solve this problem
* "Recipes can have a conflicted history in terms of origin, i.e multiple countries, people, and variations, although they have the same name etc". Unfortunately, history hasn't implemented yet.
* "Recipes change over time, and history should be preserved". Same point - history hasn't implemented yet.
* Sample application consumed API Client hasn't implemented
