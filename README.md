# Microsoft Orleans 3.0 on .NET Core 3 - Seed project

https://devblogs.microsoft.com/dotnet/orleans-3-0/

## Features

### Silo e Cliente executando 100% configurados e rodando com Containers Docker

Tanto o Silo quando o Cliente são aplicações .NET Core 3.0 rodando em containers docker no Linux.

### Persistência de Grains no MongoDB
1
Pré-configurado com persistência de Grains direto no MongoDB 4.2.

### Service/Silo Discovery (clustering) com Consul

Hashicorp Consul pré-configurado para trabalhar como Discovery para os Silos.

### Integrado ao Visual Studio 

Clone, Play & Debug! Tudo integrado ao Visual Studio, pronto para debug.

### Todos os serviços são hospedados e gerenciados com Docker Compose

O stack é todo implantado com Docker Compose, integrado ao Visual Studio.


### Dashboard integrado

Dashboard Configurado e Integrado à Solução

![alt text][logo]

[logo]: ./assets/OrleansDashboard.png "Logo Title Text 2"


## Requisitos

* Visual Studio 2019
* .NET Core 3.0 SDK
* Docker e Docker Compose

## Get Started

Faça o clone do projeto.

Abra a solução ./gaGO.io.MicrosoftOrleansDemo.sln.

Sete o projeto docker-compose como startup project.

Pressione F5.
