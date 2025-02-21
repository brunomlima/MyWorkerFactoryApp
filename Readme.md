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
│── Program.cs               # Configuração do Host e DI
│── Worker.cs                # Serviço principal do Worker
│── Services.cs              # Implementação dos serviços
│── ServiceFactory.cs        # Implementação do Factory Pattern
│── MyWorkerFactoryApp.csproj # Arquivo de configuração do projeto
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

### 🔹 **3. Compilar o projeto**
```bash
dotnet build
```

### 🔹 **4. Executar o Worker**
```bash
dotnet run
```

## ⚙ **Funcionamento**
1️⃣ O Worker inicia e registra os logs com **Serilog**.
2️⃣ O **Factory Pattern** cria instâncias dinâmicas de diferentes serviços (`ServiceA`, `ServiceB`, `ServiceC`).
3️⃣ O Worker executa os serviços periodicamente, garantindo flexibilidade e escalabilidade.
4️⃣ O Serilog registra logs em **console** e **arquivos** para facilitar o monitoramento.

## ✨ **Principais Funcionalidades**
✅ **Execução de múltiplos serviços** de forma assíncrona.
✅ **Modularidade** com injeção de dependência.
✅ **Registro de logs estruturados** para monitoramento.
✅ **Facilidade de expansão** para novos serviços.
✅ **Utilização de padrões de design** para código limpo e organizado.

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

💡 **Dúvidas ou sugestões?** Entre em contato! 😊

📧 **Email:** seu-email@example.com
📌 **GitHub:** [seu-usuario](https://github.com/seu-usuario)
📌 **LinkedIn:** [seu-perfil](https://linkedin.com/in/seu-perfil)

