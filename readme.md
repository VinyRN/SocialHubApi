### Social Network - Frontend

Este é o frontend da aplicação Social Network, construída com Angular para fornecer uma interface intuitiva e responsiva para os usuários interagirem com a rede social.

## 🚀 Tecnologias Utilizadas

	Angular (Framework frontend)
	TypeScript (Linguagem principal)
	RxJS (Gerenciamento de observáveis)
	Bootstrap/CSS (Estilização, opcional)
	HttpClient (Para comunicação com a API)
	
## 📋 Pré-requisitos

Antes de começar, você precisará ter o seguinte instalado na sua máquina:

	Node.js (v14 ou superior) e npm
	Angular CLI (v15 ou superior)
	Um backend funcional. Certifique-se de que a API backend está rodando em http://localhost:5068.
	
## 📦 Configuração e Instalação
	Siga os passos abaixo para configurar o projeto:

1. Clone o Repositório

2. Instale as Dependências

	npm install

3. Configuração do Ambiente
	
	Verifique se o arquivo src/environments/environment.ts está configurado corretamente para apontar para a API:
	
	export const environment = {
	  production: false,
	  apiUrl: 'http://localhost:5068/api'
	};
	

## 💻 Executando o Projeto

	Modo Desenvolvimento

	Para iniciar o servidor de desenvolvimento, execute:

	ng serve
	
	Acesse o frontend no navegador em: http://localhost:4200.
	
## 🌟 Funcionalidades

 #📌 Autenticação

	Login de usuários com JWT.
	Registro de novos usuários.	
	
 #📝 Postagens
	
	Criar novas postagens.
	
	Listar postagens no feed.
	
	
##🛠 Estrutura de Pastas
	Abaixo está a estrutura principal do projeto:


	src/
	├── app/
	│   ├── auth/               # Módulo de autenticação (login e registro)
	│   │   ├── login/          # Componente de login
	│   │   ├── register/       # Componente de registro
	│   ├── feed/               # Componente do feed de postagens
	│   ├── post/               # Serviço e componente relacionados a postagens
	│   ├── app.component.ts    # Componente raiz
	│   └── app.routes.ts       # Rotas do projeto
	├── assets/                 # Arquivos estáticos
	├── environments/           # Configuração de ambiente (dev/prod)

## 🔄 Integração com o Backend

	#Comunicação com a API

	O frontend usa o serviço HttpClient para se comunicar com o backend. A API deve estar configurada em environment.ts:
	
	apiUrl: 'http://localhost:5068/api'


	As rotas de API utilizadas incluem:

	POST /auth/login: Login de usuários.
	POST /auth/register: Registro de usuários.
	GET /post: Recuperar postagens.
	POST /post: Criar nova postagem.
	
##📚 Scripts Disponíveis
	
	Iniciar o Servidor

	ng serve

	#Gerar Componentes ou Serviços
	ng generate component nome-do-componente
	ng generate service nome-do-servico

