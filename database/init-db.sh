
sleep 20s


/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Schedule') CREATE DATABASE Schedule;"
