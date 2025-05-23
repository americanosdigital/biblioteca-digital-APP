
# 📚 Digital Library

Project developed in **Angular 19**, styled with **Tailwind CSS** and using **JSON Server** as a fake backend. It manages a book library with CRUD features, search, pagination, and a responsive layout.

---

Create a new Angular project (if necessary)
If you haven't created an Angular project yet, do this:

npm install -g @angular/cli
ng new biblioteca-digital-angular --routing --style=css

---

## 🚀 Technologies Used

- [Angular 19](https://angular.io/)
- [Tailwind CSS](https://tailwindcss.com/)
- [JSON Server](https://github.com/typicode/json-server)
- [TypeScript](https://www.typescriptlang.org/)
- [Bootstrap + AdminLTE (optional)]

---

## 🧩 Features

- ✅ Add new books  
- ✅ Edit existing books  
- ✅ Delete books  
- ✅ Paginated list  
- ✅ Search by title  
- ✅ Responsive display in cards or tables using Tailwind  
- ✅ Integration with `json-server` as a mock database  

---

## 📂 Project Structure

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

## ⚙️ Installation & Execution

### 1. Clone the repository

```bash
git clone https://github.com/americanosdigital/biblioteca-digital-angular
cd biblioteca-digital-angular
```

### 2. Install dependencies

```bash
npm install
```

### 3. Start JSON Server (fake backend)

```bash
npx json-server --watch db.json --port 3000
```

> Make sure the `db.json` file contains the basic structure:

```json
{
  "livros": [
    {
      "id": 1,
      "titulo": "The Lord of the Rings",
      "autor": "J.R.R. Tolkien",
      "ano": 1954,
      "genero": "Fantasy"
    },
    {
      "id": 2,
      "titulo": "1984",
      "autor": "George Orwell",
      "ano": 1949,
      "genero": "Dystopia"
    }
  ]
}
```

### 4. Run Angular server

```bash
ng serve
```

Access: [http://localhost:4200](http://localhost:4200)

---

## 🎨 Tailwind CSS Styling

This project uses **Tailwind CSS** for building modern and responsive layouts.

---
###

Install Tailwind Dependencies
In the terminal, inside your Angular project, run:

npm install -D tailwindcss postcss autoprefixer
npx tailwindcss init

###
---

#### Key files:

- `tailwind.config.js`
Create /tailwind.config.js:
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
Create /postcss.config.js:
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
Edit src/styles.css:
@tailwind base;
@tailwind components;
@tailwind utilities;


---

---

## 🤝 Contributing

Contributions are welcome!  
Feel free to open **issues** or submit **pull requests** with suggestions and improvements.

---

## 📄 License

This project is licensed under the **MIT** license.
