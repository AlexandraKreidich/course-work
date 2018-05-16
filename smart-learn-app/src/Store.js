import React from "react";
import { combineReducers, createStore, applyMiddleware } from "redux";
import { reducer as formReducer } from "redux-form";
import ReduxThunk from "redux-thunk";

const rootReducer = combineReducers({});

const Store = createStore(rootReducer, applyMiddleware(ReduxThunk));

export default Store;
