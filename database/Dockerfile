
FROM mcr.microsoft.com/mssql/server

ENV SA_PASSWORD=V@90fr_
ENV ACCEPT_EULA=Y

EXPOSE 1433

USER root
RUN mkdir -p /usr/src/app && chown -R mssql:mssql /usr/src/app

USER mssql

COPY ./init-db.sh /usr/src/app/init-db.sh
USER root

RUN chmod +x /usr/src/app/init-db.sh


CMD /bin/bash /usr/src/app/init-db.sh & /opt/mssql/bin/sqlservr



#docker build -t my-mssql-server .
#docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MinhaSenhaForte123!" -p 1433:1433 --name sql_db  sqlserver_db
