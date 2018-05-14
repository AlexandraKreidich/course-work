import {
  requestSessions,
  receiveSessions,
  requestSessionsForFilm,
  receiveSessionsForFilm
} from '../actions/ActionCreators';

import {
  SESSIONS_REQUEST,
  SESSIONS_RESPONSE,
  SESSIONS_FOR_FILM_REQUEST,
  SESSIONS_FOR_FILM_RESPONSE
} from '../actions/ActionTypes';

const initialState = {
  sessions: [],
  isSessionsLoading: false
};

const sessionReducer = function(state = initialState, action) {
  switch (action.type) {
    case SESSIONS_REQUEST:
      return {
        ...state,
        isSessionsLoading: true
      };
    case SESSIONS_RESPONSE:
      return {
        ...state,
        sessions: action.response,
        isSessionsLoading: false
      };
    case SESSIONS_FOR_FILM_REQUEST:
      return {
        ...state,
        isSessionsLoading: true
      };
    case SESSIONS_FOR_FILM_RESPONSE:
      return {
        ...state,
        sessions: action.response,
        isSessionsLoading: false
      };
  }
  return state;
};

export { sessionReducer };
