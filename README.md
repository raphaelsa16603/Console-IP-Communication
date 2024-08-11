# Comunicação IP em Console em C#

## Visão Geral

Este projeto é uma demonstração simples de comunicação entre processos (IPC) em C# usando TCP/IP. Ele consiste em um servidor e um cliente, ambos implementados como aplicativos de console. O servidor envia objetos complexos para o cliente em intervalos regulares, e o cliente também pode enviar dados de volta para o servidor. O projeto foi projetado com foco nos princípios SOLID e utiliza padrões de design para garantir a manutenibilidade e escalabilidade.

## Funcionalidades

- **Servidor**:
  - Envia uma lista de objetos complexos para os clientes conectados a cada 250 milissegundos.
  - Lida com múltiplos clientes simultaneamente.
  - Registra erros e dados enviados/recebidos em arquivos de log separados, com novos logs criados a cada 30 minutos.

- **Cliente**:
  - Recebe dados do servidor e os registra.
  - Envia dados de volta para o servidor a cada 3 segundos.
  - Registra erros e dados enviados/recebidos em arquivos de log separados, com novos logs criados a cada 30 minutos.

## Estrutura do Projeto

- **Common**:
  - Contém código compartilhado, incluindo modelos, configuração, comunicação e utilitários de log.
  
- **ServerConsoleApp**:
  - Implementa a lógica do lado do servidor.
  
- **ClientConsoleApp**:
  - Implementa a lógica do lado do cliente.

## Começando

### Pré-requisitos

- .NET 6.0 SDK ou superior
- Visual Studio 2022 ou superior (recomendado) ou qualquer outro IDE que suporte desenvolvimento em C# e .NET.

### Instalação

1. Clone o repositório:
    ```bash
    git clone https://github.com/raphaelsa16603/Console-IP-Communication.git
    cd Console-IP-Communication
    ```

2. Abra a solução no Visual Studio.

3. Restaure os pacotes NuGet:
    ```bash
    dotnet restore
    ```

4. Compile a solução:
    ```bash
    dotnet build
    ```

### Configuração

O projeto utiliza arquivos JSON para configuração. Você encontrará dois arquivos de configuração:

- **serverConfig.json**:
  - Contém o IP e a porta do servidor, assim como o IP e a porta do cliente.
  
- **clientConfig.json**:
  - Contém o IP e a porta do cliente, assim como o IP e a porta do servidor.

Certifique-se de ajustar esses arquivos de acordo com a sua configuração de rede.

### Executando o Servidor

1. Inicie o servidor executando o projeto `ServerConsoleApp`.
2. O servidor começará a escutar conexões de clientes no IP e porta especificados.

### Executando o Cliente

1. Inicie o cliente executando o projeto `ClientConsoleApp`.
2. O cliente se conectará ao servidor usando o IP e porta especificados no arquivo de configuração.

### Logs

- **ErrorLogger**: Registra erros em arquivos no diretório `Logs/ServerErrors` ou `Logs/ClientErrors`.
- **DataLogger**: Registra dados enviados e recebidos em arquivos no diretório `Logs/ServerData` ou `Logs/ClientData`.

Novos arquivos de log são criados a cada 30 minutos.

### Exemplo de Uso

1. Execute o aplicativo do servidor.
2. Execute o aplicativo do cliente.
3. Observe os logs nos diretórios respectivos para ver a comunicação entre o servidor e o cliente.

## Contribuindo

Se você deseja contribuir, por favor faça um fork do repositório e faça as alterações que desejar. Pull requests são bem-vindos.

## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

# Console IP Communication in C#

## Overview

This project is a simple demonstration of inter-process communication (IPC) in C# using TCP/IP. It consists of a server and a client, both implemented as console applications. The server sends complex objects to the client at regular intervals, and the client can also send data back to the server. The project is designed with a focus on principles like SOLID and uses design patterns to ensure maintainability and scalability.

## Features

- **Server**:
  - Sends a list of complex objects to connected clients every 250 milliseconds.
  - Handles multiple clients simultaneously.
  - Logs errors and data sent/received in separate log files, with new logs created every 30 minutes.
  
- **Client**:
  - Receives data from the server and logs it.
  - Sends data back to the server every 3 seconds.
  - Logs errors and data sent/received in separate log files, with new logs created every 30 minutes.

## Project Structure

- **Common**:
  - Contains shared code, including models, configuration, communication, and logging utilities.
  
- **ServerConsoleApp**:
  - Implements the server-side logic.
  
- **ClientConsoleApp**:
  - Implements the client-side logic.

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022 or later (recommended) or any other IDE that supports C# and .NET development.

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/raphaelsa16603/Console-IP-Communication.git
    cd Console-IP-Communication
    ```

2. Open the solution in Visual Studio.

3. Restore the NuGet packages:
    ```bash
    dotnet restore
    ```

4. Build the solution:
    ```bash
    dotnet build
    ```

### Configuration

The project uses JSON files for configuration. You'll find two configuration files:

- **serverConfig.json**:
  - Contains the server's IP and port, as well as the client's IP and port.
  
- **clientConfig.json**:
  - Contains the client's IP and port, as well as the server's IP and port.

Make sure to adjust these files according to your network setup.

### Running the Server

1. Start the server by running the `ServerConsoleApp` project.
2. The server will start listening for client connections on the specified IP and port.

### Running the Client

1. Start the client by running the `ClientConsoleApp` project.
2. The client will connect to the server using the IP and port specified in the configuration file.

### Logging

- **ErrorLogger**: Logs errors to files in the `Logs/ServerErrors` or `Logs/ClientErrors` directory.
- **DataLogger**: Logs data sent and received to files in the `Logs/ServerData` or `Logs/ClientData` directory.

New log files are created every 30 minutes.

### Example Usage

1. Run the server application.
2. Run the client application.
3. Observe the logs in the respective directories to see the communication between the server and client.

## Contributing

If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

# Comunicación IP en Consola en C#

## Visión General

Este proyecto es una demostración simple de comunicación entre procesos (IPC) en C# usando TCP/IP. Consiste en un servidor y un cliente, ambos implementados como aplicaciones de consola. El servidor envía objetos complejos al cliente a intervalos regulares, y el cliente también puede enviar datos de vuelta al servidor. El proyecto está diseñado con un enfoque en principios como SOLID y utiliza patrones de diseño para garantizar mantenibilidad y escalabilidad.

## Funcionalidades

- **Servidor**:
  - Envía una lista de objetos complejos a los clientes conectados cada 250 milisegundos.
  - Maneja múltiples clientes simultáneamente.
  - Registra errores y datos enviados/recibidos en archivos de log separados, con nuevos logs creados cada 30 minutos.

- **Cliente**:
  - Recibe datos del servidor y los registra.
  - Envía datos de vuelta al servidor cada 3 segundos.
  - Registra errores y datos enviados/recibidos en archivos de log separados, con nuevos logs creados cada 30 minutos.

## Estructura del Proyecto

- **Common**:
  - Contiene código compartido, incluidos modelos, configuración, comunicación y utilidades de registro.
  
- **ServerConsoleApp**:
  - Implementa la lógica del lado del servidor.
  
- **ClientConsoleApp**:
  - Implementa la lógica del lado del cliente.

## Comenzando

### Prerrequisitos

- .NET 6.0 SDK o posterior
- Visual Studio 2022 o posterior (recomendado) o cualquier otro IDE que soporte desarrollo en C# y .NET.

### Instalación

1. Clona el repositorio:
    ```bash
    git clone https://github.com/raphaelsa16603/Console-IP-Communication.git
    cd Console-IP-Communication
    ```

2. Abre la solución en Visual Studio.

3. Restaura los paquetes NuGet:
    ```bash
    dotnet restore
    ```

4. Construye la solución:
    ```bash
    dotnet build
    ```

### Configuración

El proyecto utiliza archivos JSON para la configuración. Encontrarás dos archivos de configuración:

- **serverConfig.json**:
  - Contiene la IP y el puerto del servidor, así como la IP y el puerto del cliente.
  
- **clientConfig.json**:
  - Contiene la IP y el puerto del cliente, así como la IP y el puerto del servidor.

Asegúrate de ajustar estos archivos según la configuración de tu red.

### Ejecución del Servidor

1. Inicia el servidor ejecutando el proyecto `ServerConsoleApp`.
2. El servidor comenzará a escuchar las conexiones de los clientes en la IP y puerto especificados.

### Ejecución del Cliente

1. Inicia el cliente ejecutando el proyecto `ClientConsoleApp`.
2. El cliente se conectará al servidor utilizando la IP y el puerto especificados en el archivo de configuración.

### Registro

- **ErrorLogger**: Registra errores en archivos en el directorio `Logs/ServerErrors` o `Logs/ClientErrors`.
- **DataLogger**: Registra datos enviados y recibidos en archivos en el directorio `Logs/ServerData` o `Logs/ClientData`.

Se crean nuevos archivos de log cada 30 minutos.

### Ejemplo de Uso

1. Ejecuta la aplicación del servidor.
2. Ejecuta la aplicación del cliente.
3. Observa los logs en los directorios respectivos para ver la comunicación entre el servidor y el cliente.

## Contribuyendo

Si deseas contribuir, por favor haz un fork del repositorio y realiza los cambios que desees. Las solicitudes de pull son bienvenidas.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - vea el archivo [LICENSE](LICENSE) para más detalles.
