
const colors = require('tailwindcss/colors')
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  theme: {
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      'lightgray': '#D3D3D3',
      'darkgray': '#2A2A2A',
    },
    extend:{
      backgroundImage:{
        'loginregistrybg':"url(./public/pictures/loginregistrybg.jpg)",
      },
      fontFamily:{
        'mainfont':['Montserrat, sans-serif']
      }
    },
  },
  plugins: [],
}
