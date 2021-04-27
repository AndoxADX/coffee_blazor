# Description
This project is a demo of a micro-frontend application.

## Project Disclaimer
- When using the term of "Micro-Frontend", we are referring to the concept of it.
- This project does not serve as a _STANDARD_ for the "Micro-Frontend" concept.
- This project is _NOT_ production tested.

## Problems with Micro-frontend
#### - **Authentication**
This can become an issue when multiple part of frontend require the same user auth.
There should be some way to share these infos with each other.
#### - **Component Reusability**
When the code base are separated, it is not uncommon that few similar or identical
components are created throughout different frontends. These common components 
should be reused, and maintained in one place.
#### - **Components (Domain) Discoverability**
When the code base gets larger, and more components are being introduced, it is 
quite common for developers to take a long time just to search for and reuse some
components. It is possible that they will miss them, and recreate a new one.  
*_The "Components" mentioned here are custom domain components._
#### - **Intercommunication**
Sometimes different components need to talk to each other. It is even harder when
components in different code base do so. Therefore, it is good to have a structured
way to allow communication between them.

### What this Demo is trying to sovle
- Full stack solution (from development, to production).
- Component Reusability among all Frontends.

# What made this project possible?
This project depends heavily on few arising technologies.
## Docker/Containerization
Each micro-frontend are wrapped in a container.
## Kubernetes
This allow managing of all these micro-frontends deployment. Including the micro-service backend.
## WebAssembly
For this demo, we are using Blazor webassembly.  
_Yes this is project has a dependency on a particular framework._
## Others
- VSCode
- Dotnet Core 5 (or .NET 5)
- Docker and Docker Compose

# Our solution (attempts)
## IndexedDB
IndexedDB is very common to front-end developers. However they are not heavily used as most 
data comes from API/backend. In this project, we decided to make use of this, to build a structure of framework on top of it.

# Run The Demo
- Open terminal window in the root directory of the `docker-compose.yml` file.
- Run `docker-compose up --build -V`
- Open browser with URL `http://localhost:8000`

