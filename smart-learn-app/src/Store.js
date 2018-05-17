import { combineReducers, createStore, applyMiddleware, compose } from "redux";
import { reducer as formReducer } from "redux-form";
import ReduxThunk from "redux-thunk";
import { userReducer } from "./reducers/User";

const rootReducer = combineReducers({
  user: userReducer,
  form: formReducer
});

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const enhancer = composeEnhancers(applyMiddleware(ReduxThunk));

const Store = createStore(rootReducer, enhancer);

export { Store };
