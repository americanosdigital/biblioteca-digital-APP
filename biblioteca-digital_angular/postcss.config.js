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