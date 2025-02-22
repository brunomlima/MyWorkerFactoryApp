# MyWorkerFactoryApp

🚀 **Worker Service em .NET utilizando Factory Pattern**

Este projeto implementa um **Worker Service** robusto e escalável utilizando **Factory Pattern** e princípios de **Clean Code** para gerenciar múltiplos serviços de forma eficiente.

## 🎯 **Objetivo do Projeto**
O **MyWorkerFactoryApp** é um Worker Service que executa múltiplos serviços em segundo plano, garantindo modularidade, desacoplamento e manutenção simplificada.

## 🏗 **Tecnologias Utilizadas**
- [.NET 6+](https://dotnet.microsoft.com/)
- **Worker Service**
- **Factory Method Pattern**
- **Dependency Injection**
- **Serilog** para logging estruturado

## 📂 **Estrutura do Projeto**

```
MyWorkerFactoryApp/
│── 📁 Configurations/        # Configurações do Worker Service
│   │── StartupLogger.cs      # Log detalhado da inicialização
│   │── WorkerConfig.cs       # Classe para mapeamento de configurações
│── 📁 Factories/             # Implementação do Factory Pattern
│   │── IServiceFactory.cs    # Interface do Factory
│   │── ServiceFactory.cs     # Implementação da Factory
│── 📁 Services/              # Implementação dos serviços de trabalho
│   │── IService.cs           # Interface base para serviços
│   │── ServiceA.cs           # Implementação de um serviço A
│   │── ServiceB.cs           # Implementação de um serviço B
│   │── ServiceC.cs           # Implementação de um serviço C
│── 📁 Workers/               # Classes principais do Worker Service
│   │── Worker.cs             # Serviço principal do Worker
│── appsettings.json          # Configuração principal
│── appsettings.Development.json # Configuração para ambiente de desenvolvimento
│── appsettings.Production.json  # Configuração para ambiente de produção
│── Program.cs                # Configuração do Host e DI
│── MyWorkerFactoryApp.csproj  # Arquivo de configuração do projeto
│── README.md                 # Documentação do projeto
│── .gitignore                # Arquivo de ignorados do Git
```

## 🛠 **Configuração e Execução**

### 🔹 **1. Clonar o repositório**
```bash
git clone https://github.com/seu-usuario/MyWorkerFactoryApp.git
cd MyWorkerFactoryApp
```

### 🔹 **2. Adicionar Dependências Necessárias**
Execute os comandos abaixo para adicionar pacotes essenciais:
```bash
dotnet add package Microsoft.Extensions.Hosting
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
```

### 🔹 **3. Configuração do `appsettings.json`**

O **Worker Service** lê as configurações do arquivo `appsettings.json`, permitindo definir serviços, horários de execução e tempo de espera.

Exemplo de **configuração do `appsettings.json`**:

```json
{
  "WorkerConfig": {
    "Servicos": [
      {
        "Nome": "ServicoA",
        "Ativo": true,
        "Horario": { "Inicio": "08:00", "Fim": "18:00" },
        "TempoEsperaMs": 5000
      },
      {
        "Nome": "ServicoB",
        "Ativo": false,
        "Horario": { "Inicio": "10:00", "Fim": "20:00" },
        "TempoEsperaMs": 10000
      }
    ]
  }
}
```

> 🛠 **O Worker também carrega arquivos específicos para cada ambiente**, como `appsettings.Development.json` e `appsettings.Production.json`.

### 🔹 **4. Configurar o Ambiente**
Antes de rodar, defina o ambiente de execução (`Development`, `Production`, etc.).

No **Linux/macOS**, execute:
```bash
export DOTNET_ENVIRONMENT=Development
dotnet run
```

No **Windows (PowerShell)**:
```powershell
$env:DOTNET_ENVIRONMENT="Development"
dotnet run
```

### 🔹 **5. Compilar o projeto**
```bash
dotnet build
```

### 🔹 **6. Executar o Worker**
```bash
dotnet run
```

## ⚙ **Funcionamento**
1️⃣ O Worker inicia e registra os logs com **Serilog**.  
2️⃣ O **Factory Pattern** cria instâncias dinâmicas de diferentes serviços (`ServiceA`, `ServiceB`, `ServiceC`).  
3️⃣ O Worker executa os serviços periodicamente, garantindo flexibilidade e escalabilidade.  
4️⃣ O Serilog registra logs em **console** e **arquivos** para facilitar o monitoramento.  
5️⃣ O tempo de espera de cada serviço é carregado do **`appsettings.json`** e registrado nos logs.

### **📌 Exemplo de Saída no Log**
```
[09:00:00] 🚀 MyWorkerApp Iniciado!
[09:00:00] 🌍 Ambiente: Development
[09:00:00] 📢 Total de serviços configurados: 2 | Ativos: 1 ✅ | Inativos: 1 ❌
[09:00:00] ➡️ ServicoA: Ativo ✅ | ⏰ 08:00 - 18:00 | ⏳ Delay: 5000ms
[09:00:00] ➡️ ServicoB: Desativado ❌ | ⏰ 10:00 - 20:00 | ⏳ Delay: 10000ms
[09:00:00] 📅 Monitorando horários de execução...
[09:00:05] ⏳ Serviço ServicoA finalizado. Próxima execução em 5000ms...
[09:00:10] 🚀 Executando serviço: ServicoA às 09:00:10
```

## ✨ **Principais Funcionalidades**
✅ **Execução de múltiplos serviços** de forma assíncrona.  
✅ **Modularidade** com injeção de dependência.  
✅ **Registro de logs estruturados** para monitoramento.  
✅ **Facilidade de expansão** para novos serviços.  
✅ **Configuração dinâmica pelo `appsettings.json`**.  
✅ **Diferenciação de ambientes (`Development` e `Production`)**.  

## 🤝 **Contribuindo**
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

1. Faça um fork do projeto  
2. Crie uma branch para sua feature (`git checkout -b minha-feature`)  
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)  
4. Faça push para a branch (`git push origin minha-feature`)  
5. Abra um Pull Request 🚀  

## 📜 **Licença**
Este projeto está licenciado sob a **MIT License** - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

📧 **Email:** brunomlima80@gmail.com  
🔗 **LinkedIn:** [bruno-lima](https://www.linkedin.com/in/bruno-lima-b608bb27/?locale=pt_BR)  
🐙 **GitHub:** [MyWorkerApp](https://github.com/brunomlima)  

---

💡 **Dúvidas ou sugestões?** Entre em contato! 😊


---

# 🚀 **Deploy em Produção**

O **MyWorkerFactoryApp** pode ser implantado de várias maneiras, dependendo da infraestrutura utilizada. Aqui estão algumas opções recomendadas:

## 📌 **Opções de Deploy**

| Método | Fácil de Implementar | Escalável | Monitoramento |
|--------|----------------------|-----------|--------------|
| **Rodar diretamente no servidor** | ✅ Sim | ❌ Não | ❌ Difícil |
| **Docker + Kubernetes** | 🔄 Médio | ✅ Sim | ✅ Fácil |
| **Azure/AWS/Google Cloud** | 🔄 Médio | ✅ Sim | ✅ Fácil |
| **Task Scheduler (Windows)** | ✅ Sim | ❌ Não | ❌ Difícil |
| **Systemd (Linux)** | ✅ Sim | ❌ Não | ✅ Fácil |

## 🔹 **1. Deploy Manual no Servidor (Windows/Linux)**
1️⃣ **Build do projeto**  
```bash
dotnet publish -c Release -o ./deploy
```
2️⃣ **Transferir arquivos para o servidor**  
No Linux, use SCP:
```bash
scp -r ./deploy usuario@seu-servidor:/home/worker-app/
```
3️⃣ **Executar o Worker no servidor**  
```bash
dotnet MyWorkerFactoryApp.dll
```

## 🔹 **2. Deploy com Docker (Recomendado)**
1️⃣ **Criar um `Dockerfile`**  
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY ./deploy/ .
ENTRYPOINT ["dotnet", "MyWorkerFactoryApp.dll"]
```
2️⃣ **Criar a imagem Docker**  
```bash
docker build -t myworkerapp .
```
3️⃣ **Rodar o container**  
```bash
docker run -d --name worker-container myworkerapp
```

## 🔹 **3. Deploy no Azure/AWS/Google Cloud**
1️⃣ **Publicar no Azure App Service**  
```bash
az appservice plan create --name MyWorkerPlan --resource-group MyResourceGroup --sku B1
dotnet publish -c Release -o ./publish
az webapp create --name MyWorkerApp --resource-group MyResourceGroup --plan MyWorkerPlan --deployment-source-path ./publish
```
2️⃣ **Publicar no AWS ECS / Fargate**  
Criar e enviar a imagem para o **Amazon ECR**:
```bash
aws ecr create-repository --repository-name myworkerapp
docker tag myworkerapp:latest aws_account_id.dkr.ecr.region.amazonaws.com/myworkerapp
docker push aws_account_id.dkr.ecr.region.amazonaws.com/myworkerapp
```

## 🔹 **4. Rodar como Serviço no Windows/Linux**
### **Windows (Task Scheduler)**
1️⃣ **Criar uma nova tarefa** no **Agendador de Tarefas**.  
2️⃣ Definir um **Trigger** para iniciar automaticamente.  
3️⃣ Adicionar uma ação executando:  
```bash
dotnet MyWorkerFactoryApp.dll
```

### **Linux (Systemd)**
1️⃣ Criar um serviço **Systemd** no Linux:  
```bash
sudo nano /etc/systemd/system/myworker.service
```
Adicionar:
```ini
[Unit]
Description=My Worker Service
After=network.target

[Service]
ExecStart=/usr/bin/dotnet /home/worker-app/MyWorkerFactoryApp.dll
Restart=always
User=root
Group=root
WorkingDirectory=/home/worker-app/

[Install]
WantedBy=multi-user.target
```
2️⃣ **Ativar o serviço**  
```bash
sudo systemctl daemon-reload
sudo systemctl enable myworker
sudo systemctl start myworker
```
3️⃣ **Verificar status**  
```bash
sudo systemctl status myworker
```

---

🔥 **Conclusão:**  
Se você precisa de **rápida implementação**, rode o Worker no servidor diretamente.  
Se busca **escalabilidade**, **Docker + Kubernetes** é a melhor opção! 🚀  



---

# 🚀 **Deploy em Produção - Passo a Passo**

Aqui está o passo a passo para as opções mais recomendadas de deploy do **MyWorkerFactoryApp**.

---

## 🔹 **1. Rodar Diretamente no Servidor (Windows/Linux)**
Se você deseja rodar o Worker Service manualmente em um servidor, siga estes passos:

### 📌 **Passo 1: Criar o Build do Projeto**
No ambiente de desenvolvimento, gere os arquivos necessários para deploy:
```bash
dotnet publish -c Release -o ./deploy
```

### 📌 **Passo 2: Transferir para o Servidor**
- **Windows**: Use FTP/SFTP ou copie via rede.
- **Linux**: Utilize o comando `scp`:
  ```bash
  scp -r ./deploy usuario@seu-servidor:/home/worker-app/
  ```

### 📌 **Passo 3: Executar o Worker no Servidor**
No servidor, acesse a pasta e execute:
```bash
dotnet MyWorkerFactoryApp.dll
```

Se quiser rodar o Worker em **background** (no Linux), use:
```bash
nohup dotnet MyWorkerFactoryApp.dll &
```

---

## 🔹 **2. Deploy com Docker + Kubernetes (Recomendado)**
Se deseja rodar o Worker dentro de um container Docker, siga os passos abaixo:

### 📌 **Passo 1: Criar um `Dockerfile` no projeto**
Crie um arquivo chamado `Dockerfile` dentro do diretório do projeto e adicione:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY ./deploy/ .
ENTRYPOINT ["dotnet", "MyWorkerFactoryApp.dll"]
```

### 📌 **Passo 2: Criar a Imagem Docker**
```bash
docker build -t myworkerapp .
```

### 📌 **Passo 3: Rodar o Container**
```bash
docker run -d --name worker-container myworkerapp
```

Se precisar verificar os logs:
```bash
docker logs -f worker-container
```

### 📌 **Passo 4: Deploy no Kubernetes**
Se quiser rodar no **Kubernetes**, crie um arquivo `worker-deployment.yaml`:

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: worker-deployment
spec:
  replicas: 1
  selector:
    matchLabels:
      app: worker-app
  template:
    metadata:
      labels:
        app: worker-app
    spec:
      containers:
        - name: worker-container
          image: myworkerapp
          restartPolicy: Always
```

### 📌 **Passo 5: Aplicar no Kubernetes**
```bash
kubectl apply -f worker-deployment.yaml
```

Para verificar se o Worker está rodando:
```bash
kubectl get pods
kubectl logs -f worker-deployment-<id-do-pod>
```

---

## 🔹 **3. Deploy com Task Scheduler (Windows)**
Se deseja rodar o Worker como um **serviço automático** no Windows, siga estes passos:

### 📌 **Passo 1: Abrir o Agendador de Tarefas**
1. Pressione `Win + R`, digite `taskschd.msc` e pressione Enter.
2. Clique em **Criar Tarefa**.

### 📌 **Passo 2: Definir um Nome para a Tarefa**
- Nomeie a tarefa como `WorkerService`.

### 📌 **Passo 3: Criar um Gatilho**
1. Vá até a aba **Gatilhos**.
2. Clique em **Novo** e selecione **Ao iniciar o computador**.

### 📌 **Passo 4: Criar uma Ação**
1. Vá até a aba **Ações**.
2. Clique em **Nova** e selecione **Iniciar um programa**.
3. No campo **Programa/script**, digite:
   ```bash
   dotnet MyWorkerFactoryApp.dll
   ```
4. No campo **Iniciar em**, coloque o caminho onde está o Worker.

### 📌 **Passo 5: Salvar e Testar**
1. Clique em **OK** e confirme.
2. Para testar manualmente, clique com o botão direito na tarefa e selecione **Executar**.

---

## 🔹 **4. Deploy com Systemd (Linux)**
Se deseja rodar o Worker como um serviço no Linux, use **Systemd**.

### 📌 **Passo 1: Criar um Serviço Systemd**
Crie um arquivo para o serviço:
```bash
sudo nano /etc/systemd/system/myworker.service
```

Adicione o seguinte conteúdo:
```ini
[Unit]
Description=My Worker Service
After=network.target

[Service]
ExecStart=/usr/bin/dotnet /home/worker-app/MyWorkerFactoryApp.dll
Restart=always
User=root
Group=root
WorkingDirectory=/home/worker-app/

[Install]
WantedBy=multi-user.target
```

### 📌 **Passo 2: Ativar o Serviço**
```bash
sudo systemctl daemon-reload
sudo systemctl enable myworker
sudo systemctl start myworker
```

### 📌 **Passo 3: Verificar Status**
Para ver se o serviço está rodando corretamente:
```bash
sudo systemctl status myworker
```

Se precisar reiniciar:
```bash
sudo systemctl restart myworker
```

Se quiser ver logs em tempo real:
```bash
journalctl -u myworker -f
```

---

## 🚀 **Conclusão**
Escolha a opção mais adequada para sua necessidade:

✅ **Para um deploy rápido e manual**, rode diretamente no servidor.  
✅ **Para ambientes escaláveis**, use **Docker + Kubernetes**.  
✅ **Para automação em Windows**, utilize o **Task Scheduler**.  
✅ **Para automação em Linux**, configure um serviço com **Systemd**.  

Agora seu Worker está pronto para rodar em produção! 🚀🔥

