# Sistema de Agendamento Blue

![alt text](docs/images/image.png)

Este sistema foi desenvolvido seguindo os padrões da Clean Architecture e CQRS. Um dos objetivos era conectar a aplicação a uma fila no RabbitMQ, mas isso não foi viável devido às limitações de tempo.

A aplicação é containerizada, com cada pasta contendo um Dockerfile com as respectivas configurações para garantir o funcionamento ideal das aplicações. Além disso, há um Docker Compose para orquestrar os containers.

## Como Rodar a Aplicação

Para rodar a aplicação, será necessário executar um container separado antes de iniciar o Docker Compose, pois o Compose infelizmente não possui um comando que faça com que o container do back-end espere o container do banco de dados subir para ser executado. Portanto, primeiro teremos que rodar o container do banco de dados para então iniciar o Docker Compose.

### Passo a Passo

Execute os seguintes comandos no terminal no diretório do projeto:

1. Acesse a pasta que contém as configurações do Docker:
    ```bash
    cd database
    ```
2. Crie a imagem do banco de dados:
    ```bash
    sudo docker build -t data_base_app .
    ```
3. Suba o container do banco de dados:
    ```bash
    sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MinhaSenhaForte123!" -p 1433:1433 -d --name sql_db data_base_app
    ```
4. Volte para a raiz do projeto:
    ```bash
    cd ..
    ```
5. Execute o Docker Compose:
    ```bash
    sudo docker compose up
    ```

## Acesso ao Sistema

Após subir os containers com o Docker Compose, será possível acessar a aplicação utilizando as seguintes credenciais:

| URL                                    | Login             | Senha |
|----------------------------------------|-------------------|-------|
| [http://localhost:8080/](http://localhost:8080/) | admin@blue.com    | admin |
