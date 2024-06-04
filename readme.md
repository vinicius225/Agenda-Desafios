# Sistema de Agendamento Blue

Este sistema foi desenvolvido seguindo os padrões da Clean Architecture e CQRS. Um dos objetivos era conectar a aplicação a uma fila no RabbitMQ, mas isso não foi viável devido às limitações de tempo.

A aplicação é containerizada, com cada pasta contendo um Dockerfile com as respectivas configurações para garantir o funcionamento ideal das aplicações. Além disso, há um Docker Compose para orquestrar os containers.

## Acesso ao Sistema

Após subir os containers com o Docker Compose, será possível acessar a aplicação utilizando as seguintes credenciais:

| URL                      | Login             | Senha |
|--------------------------|-------------------|-------|
| [http://localhost:8080/](http://localhost:8080/) | admin@blue.com | admin |
