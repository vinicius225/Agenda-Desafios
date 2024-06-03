FROM rabbitmq:latest

EXPOSE 5672

EXPOSE 15672

RUN rabbitmq-plugins enable rabbitmq_management

CMD ["rabbitmq-server"]

#docker build -t rabbitmq-image .
#docker run -d --name meu-rabbitmq-container -p 5672:5672 -p 15672:15672 rabbit-conatiner

