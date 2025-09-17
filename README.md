<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/bd/Logo_C_sharp.svg/1200px-Logo_C_sharp.svg.png" width="100px" />
  <img src="https://cdn.iconscout.com/icon/free/png-256/free-java-logo-icon-download-in-svg-png-gif-file-formats--wordmark-programming-language-pack-logos-icons-1174953.png?f=webp" width="150px" />
</p>

# 📚 Estrutura de Dados Lineares (EDL) - 2025.2

<p align="center">
  <img src="https://img.shields.io/badge/C%23-Linguagem-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Java-Linguagem-A7C?style=for-the-badge&logo=java&logoColor=white" alt="Java" />
  <img src="https://img.shields.io/badge/TADS-3º%20Período-yellow?style=for-the-badge" alt="TADS" />
</p>

---

## 📚 Descrição

Este repositório contém exercícios da disciplina **Estrutura de Dados Lineares (EDL)**, cursada no **3º período** do curso de **TADS (Tecnologia em Análise e Desenvolvimento de Sistemas)**, utilizando a linguagem **C#**.

---

## 🗂️ Estrutura do Projeto

```
EDL/
├── Atividade1/
│   └── Program.cs
├── Atividade2/
│   └── Program.cs
├── ...
└── README.md
```

---

## 🚀 Como Executar

### Pré-requisitos

- [SDK do .NET](https://dotnet.microsoft.com/en-us/download) instalado
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/) (ou VS Code)

### Rodando um arquivo C#

1. Navegue até a pasta de uma atividade específica:

```bash
cd Atividade1
```

2. Crie um novo projeto:

```bash
dotnet new console
```

3. Compile e execute com o .NET CLI:

```bash
dotnet run
```

> Caso deseje rodar um arquivo `.cs` diretamente, use o seguinte comando:

```bash
csc MeuArquivo.cs
./MeuArquivo.exe
```

### Rodando Arquivos em Java

**Pré-requisitos:** [JDK](https://www.oracle.com/java/technologies/javase-downloads.html) instalado

```bash
# Compilar o arquivo
javac MeuArquivo.java

# Executar o arquivo
java MeuArquivo
```
---

## 💬 Convenções de Mensagens de Commit

Use convenções semânticas para clareza e organização no histórico de commits:

- `feat`: Adição de nova funcionalidade
- `fix`: Correção de bug
- `docs`: Alterações na documentação
- `style`: Alterações de formatação que não afetam o código (espaços, vírgulas, etc.)
- `refactor`: Refatoração de código que não altera funcionalidade
- `test`: Adição ou modificação de testes
- `chore`: Atualizações de tarefas internas (configs, dependências, etc.)