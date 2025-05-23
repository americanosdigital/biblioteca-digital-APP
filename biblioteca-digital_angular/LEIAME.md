
# 📚 Biblioteca Digital

Projeto desenvolvido em **Angular 19**, com estilização via **Tailwind CSS** e backend simulado com **JSON Server**, para gerenciar uma biblioteca de livros com funcionalidades de CRUD, busca, paginação e exibição com layout responsivo.

---

Criar um novo projeto Angular (caso necessário)
Se você ainda não criou o projeto Angular, faça isso:

npm install -g @angular/cli
ng new biblioteca-digital-angular --routing --style=css

---

## 🚀 Tecnologias Utilizadas

- [Angular 19](https://angular.io/)
- [Tailwind CSS](https://tailwindcss.com/)
- [JSON Server](https://github.com/typicode/json-server)
- [TypeScript](https://www.typescriptlang.org/)
- [Bootstrap + AdminLTE (opcional)]

---

## 🧩 Funcionalidades

- ✅ Cadastro de livros  
- ✅ Edição de livros existentes  
- ✅ Exclusão de livros  
- ✅ Listagem com paginação  
- ✅ Busca por título  
- ✅ Exibição em cards responsivos ou tabela com Tailwind  
- ✅ Integração com `json-server` como banco de dados fake  

---

## 📂 Estrutura do Projeto

```
biblioteca-digital-angular/
├── src/
│   ├── app/
│   │   ├── livros/
│   │   │   ├── listagem/
│   │   │   ├── cadastro/
│   │   ├── shared/
│   │   │   ├── components/
│   │   │   ├── services/
│   ├── assets/
├── db.json
├── tailwind.config.js
├── postcss.config.js
└── angular.json
```

---

## ⚙️ Instalação e Execução

### 1. Clonar o repositório

```bash
git clone https://github.com/americanosdigital/biblioteca-digital-angular
cd biblioteca-digital-angular
```

### 2. Instalar as dependências

```bash
npm install
```

### 3. Iniciar o JSON Server (fake backend)

```bash
npx json-server --watch db.json --port 3000
```

> Certifique-se de que o arquivo `db.json` contém a estrutura básica:

```json
{
  "livros": [
    {
      "id": 1,
      "titulo": "O Senhor dos Anéis",
      "autor": "J.R.R. Tolkien",
      "ano": 1954,
      "genero": "Fantasia"
    },
    {
      "id": 2,
      "titulo": "1984",
      "autor": "George Orwell",
      "ano": 1949,
      "genero": "Distopia"
    }
  ]
}
```

### 4. Rodar o servidor Angular

```bash
ng serve
```

Acesse: [http://localhost:4200](http://localhost:4200)

---

## 🎨 Estilização com Tailwind CSS

Este projeto utiliza **Tailwind CSS** para a criação de layouts modernos e responsivos.

---
###
Instalar dependências do Tailwind
No terminal, dentro do seu projeto Angular, execute:

npm install -D tailwindcss postcss autoprefixer
npx tailwindcss init
###
---

#### Arquivos importantes:

- `tailwind.config.js`
Criar /tailwind.config.js:
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

- `postcss.config.js`
Criar /postcss.config.js:
// postcss.config.js
import tailwindcss from '@tailwindcss/postcss';

const tailwindcss = require('@tailwindcss/postcss');
const autoprefixer = require('autoprefixer');

module.exports = {
  plugins: [
    tailwindcss,
    autoprefixer,
  ]
};

- `src/styles.css`
Edite src/styles.css:
@tailwind base;
@tailwind components;
@tailwind utilities;


---

## 🤝 Contribuição

Contribuições são bem-vindas!  
Sinta-se à vontade para abrir **issues** ou enviar **pull requests** com sugestões e melhorias.

---

## 📄 Licença

Este projeto está licenciado sob a licença **MIT**.
