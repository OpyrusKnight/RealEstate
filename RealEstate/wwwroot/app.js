import { Application } from '@splinetool/runtime';

const canvas = document.getElementById('canvas3d');
const app = new Application(canvas);

app.load('http://127.0.0.1:58191//F:/cours/untitled (2)/scene.splinecode')
  .then(() => {
    console.log('Spline project loaded successfully.');
  })
  .catch(error => {
    console.error('Error loading Spline project:', error);
  });
