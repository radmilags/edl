<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/bd/Logo_C_sharp.svg/1200px-Logo_C_sharp.svg.png" width="100px" />
  <img src="https://cdn.iconscout.com/icon/free/png-256/free-java-logo-icon-download-in-svg-png-gif-file-formats--wordmark-programming-language-pack-logos-icons-1174953.png?f=webp" width="150px" />
</p>

# EDL
Estrutura de dados lineares - disciplina do 3º período de TADS

A codificação das atividades será feita em C#. Futuramente pretendo tentar os exercícios em Java.

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

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/EDL.git
cd EDL
```

2. Navegue até a pasta de uma atividade específica:

```bash
cd Atividade1
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

### Rodando Arquivos em Java (Futuro)

**Pré-requisitos:** [JDK](https://www.oracle.com/java/technologies/javase-downloads.html) instalado

```bash
# Compilar o arquivo
javac MeuArquivo.java

# Executar o arquivo
java MeuArquivo
```

---

## 🧠 Comandos Git Essenciais

```bash
# Clonar o repositório
git clone https://github.com/seu-usuario/EDL.git

# Verificar alterações
git status

# Adicionar arquivos alterados
git add .

# Commitar mudanças
git commit -m "mensagem do commit"

# Enviar para o GitHub
git push origin main

# Atualizar repositório local
git pull origin main
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
