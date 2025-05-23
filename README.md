# semantickernel-playground

## Local LLM Setup with LM Studio

This project demonstrates how to use Semantic Kernel with local Large Language Models (LLMs) using LM Studio.

### Setting Up LM Studio

[LM Studio](https://lmstudio.ai) provides a desktop application for running various local LLMs.

1. **Install LM Studio**
    - Download and install from [lmstudio.ai](https://lmstudio.ai)

2. **Configure LM Studio**
    - Open LM Studio
    - Browse and download a model
    - Select the model
    - Go to the "Developer" tab
    - Click "Start Server" to launch the OpenAI-compatible API on port 1234
    - The server now runs on `http://localhost:1234/v1`


## Start the local docker setup

```bash
    docker-compose up -d
```

The docker-compose setup will handle all necessary dependencies and configurations automatically. Make sure [Docker](https://docs.docker.com/get-docker/) and [Docker Compose](https://docs.docker.com/compose/install/) are installed on your system before running these commands.

After all services started successfully, Open-WebUI can be accessed via `http://localhost:8181`.
The model with name `dotnetapi` should already be automatically selected.