import React from 'react';
import { combineReducers, createStore, applyMiddleware } from 'redux';
import { userReducer } from './user/reducers/User';
import { filmReducer } from './films/reducers/Film';
import { sessionReducer } from './sessions/reducers/Session';
import { HallReducer, hallReducer } from './hall/reducers/Hall';
import { reducer as formReducer } from 'redux-form';
import ReduxThunk from 'redux-thunk';
import { SearchBarReducer } from './searchBar/reducers/SearchBar';
import { ServiceReducer } from './services/reducers/Service';

const rootReducer = combineReducers({
  user: userReducer,
  film: filmReducer,
  session: sessionReducer,
  form: formReducer,
  searchBar: SearchBarReducer,
  hall: hallReducer,
  service: ServiceReducer
});

const store = createStore(rootReducer, applyMiddleware(ReduxThunk));

export { store };
