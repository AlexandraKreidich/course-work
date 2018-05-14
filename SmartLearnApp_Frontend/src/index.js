import React from 'react';
import { render } from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import Application from './App';
import { store } from './Store';

render(
  <Provider store={store}>
    <BrowserRouter>
      <Application />
    </BrowserRouter>
  </Provider>,
  document.getElementById('root')
);
