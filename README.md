<img width=100% src="https://capsule-render.vercel.app/api?type=waving&color=0:00bfbf,100:1e90ff&height=140&section=header"/>

<h1 align="center">💰 Sistema Financeiro</h1>

<p align="center">
Sistema web desenvolvido em ASP.NET Core para controle de requisições financeiras, autenticação de usuários e gestão de movimentações.
</p>

---

## 🚀 Sobre o Projeto

O **Sistema Financeiro** é uma aplicação web desenvolvida com foco em controle de requisições internas, permitindo:

- Cadastro de usuários com autenticação (Identity)
- Controle de acesso ao sistema (login obrigatório)
- CRUD completo de requisições financeiras
- Organização e rastreamento de solicitações
- Interface web responsiva

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (LocalDB / Azure compatível)
- ASP.NET Identity
- Bootstrap 5
- Razor Pages

---

## 🔐 Autenticação

O sistema utiliza **ASP.NET Identity**, garantindo:

- Login obrigatório para acesso
- Registro de usuários
- Logout seguro
- Controle de sessão

---

## 📄 Funcionalidades

### 👤 Usuários
- Registro de conta
- Login e logout
- Controle de sessão

### 📊 Requisições
- Criar nova requisição
- Editar requisição
- Excluir requisição
- Visualizar detalhes
- Listagem completa

---

## 📁 Estrutura do Projeto

SistemaFinanceiro
├── Controllers
├── Models
├── Data
├── Views
├── Areas (Identity)
├── wwwroot
└── Program.cs

---

## ▶️ Como executar o projeto

# clonar repositório
git clone https://github.com/seu-usuario/sistema-financeiro.git

# entrar na pasta
cd SistemaFinanceiro

# restaurar dependências
dotnet restore

# executar migrations (se necessário)
dotnet ef database update

# rodar aplicação
dotnet run
