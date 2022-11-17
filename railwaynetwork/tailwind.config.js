
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
      'moderategray': '#505050',
      'dark': '#000000',
      'white': '#FFFFFF',
      'red':'#FF0000',
      'darkerred':'#8B0000',
      'silver':'#CED2D7',
      'darkersilver':'#555652',
      'yellow':'#FFFF00',
      'darkeryellow':'#FFA500',
      'green':'#00FF00'
    },
    extend: {
      backgroundImage: {
        'loginregistrybg': "url(./public/pictures/loginregistrybg.jpg)",
        'homebg':"url(/public/pictures/homebg.jpg)"
      },
      fontFamily: {
        'mainfont': ['Montserrat, sans-serif']
      },
      spacing: {
        '128': '42rem',
      }
    },
    screens:{
      'mobile' :'480px',
      'sm': '640px',
      'md':'768px',
      'lg':'1024px',
      'xl':'1280px',
      '2xl':'1536',
    }
  },
  plugins: [],
}
