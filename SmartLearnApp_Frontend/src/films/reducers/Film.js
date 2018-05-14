import { FILMS_REQUEST, FILMS_RESPONSE } from '../actions/ActionTypes';

const initialState = {
  films: [],
  isFilmsLoading: false
};

const filmReducer = function(state = initialState, action) {
  switch (action.type) {
    case FILMS_REQUEST:
      return {
        ...state,
        isFilmsLoading: true
      };
    case FILMS_RESPONSE:
      return {
        ...state,
        films: action.response,
        isFilmsLoading: false
      };
  }
  return state;
};

export { filmReducer };
