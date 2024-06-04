
FROM mcr.microsoft.com/mssql/server


EXPOSE 1433

USER root
RUN mkdir -p /usr/src/app && chown -R mssql:mssql /usr/src/app

USER mssql

COPY ./init-db.sh /usr/src/app/init-db.sh
USER root

RUN chmod +x /usr/src/app/init-db.sh


CMD /bin/bash /usr/src/app/init-db.sh & /opt/mssql/bin/sqlservr



#docker build -t db_agenda .
#docker run  -p 1433:1433 --name sql_db  db_agenda
