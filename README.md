\#MyTasksMentor



Plataforma de gestión de tareas y notas con integración de Inteligencia Artificial, diseñada para mejorar la productividad personal mediante análisis inteligente de información.



\---



\## Características principales



\* Gestión de tareas (crear, consultar, completar)

\* Gestión de notas personales

\* Generación de resúmenes inteligentes con IA

\* Análisis contextual de información del usuario

\* Arquitectura limpia (Clean Architecture)



\---



\## Arquitectura



El proyecto está diseñado bajo principios de \*\*Clean Architecture\*\*:



\* \*\*Domain\*\* → Entidades y reglas de negocio

\* \*\*Application\*\* → Casos de uso

\* \*\*Infrastructure\*\* → MongoDB + servicios externos

\* \*\*API\*\* → Exposición REST



\---



\##Tecnologías utilizadas



\* ASP.NET Core

\* MongoDB (Atlas)

\* Azure App Service

\* REST API

\* Dependency Injection

\* Middleware para manejo de errores

\* Integración con IA (API compatible OpenAI)



\---



\## Despliegue



La aplicación está desplegada en Azure:



https://mytasksmentor-api-bubbfnczgyecabam.canadacentral-01.azurewebsites.net/swagger



\---



\## Configuración



Las credenciales sensibles se manejan mediante:



\* Variables de entorno

\* Configuración segura en Azure



\---



\## Endpoints principales



\* `POST /api/tasks`

\* `GET /api/tasks/user/{userId}`

\* `PATCH /api/tasks/{id}/complete`

\* `GET /api/tasks/summary/{userId}`

\* `POST /api/notes`

\* `GET /api/tasks/notes-analysis/{userId}`



\---



\## IA aplicada



El sistema utiliza IA para:



\* Generar resúmenes de tareas

\* Analizar notas del usuario

\* Proporcionar recomendaciones inteligentes



\---



\## Aprendizajes clave



\* Implementación de Clean Architecture en .NET

\* Integración de servicios de IA en backend

\* Despliegue en Azure

\* Manejo de configuración segura

\* Diseño de APIs REST escalables



\---



\## Próximas mejoras



\* Autenticación con JWT

\* Frontend con Vue.js

\* Automatizaciones inteligentes (tipo Zapier)

\* Búsqueda semántica con embeddings



\---



\## Autor



Desarrollado por Daniel Gallego



\---







