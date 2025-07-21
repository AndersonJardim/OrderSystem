# Order Processing System

Este projeto implementa um sistema distribuído para ingestão e despacho de pedidos, com arquitetura orientada a serviços, princípios de DDD, SOLID, e testes automatizados com xUnit.

---

## 🧱 Arquitetura

O sistema segue uma arquitetura baseada em DDD (Domain-Driven Design) e princípios SOLID. Os serviços se comunicam via HTTP (para testes) e podem evoluir para mensageria com RabbitMQ.

### Serviços principais:

- **Order.IngestService**: Recebe pedidos externos e os publica.
- **Order.DispatchService**: Consome pedidos e executa o processamento.

---

## 🔧 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core
- xUnit (Testes unitários)
- AutoMapper
- RabbitMQ *(próxima etapa)*
- Docker *(futuramente)*
- Swagger (OpenAPI)

---
<img width="1340" height="1454" alt="Image" src="https://github.com/user-attachments/assets/80e1d2a5-4800-4fc5-b93b-853b943df237" />