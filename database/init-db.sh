
sleep 20s


/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "MinhaSenhaForte123!" -Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Schedule') CREATE DATABASE Schedule;"
