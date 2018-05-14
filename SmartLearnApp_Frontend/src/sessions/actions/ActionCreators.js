import {
  SESSIONS_REQUEST,
  SESSIONS_RESPONSE,
  SESSIONS_FOR_FILM_REQUEST,
  SESSIONS_FOR_FILM_RESPONSE
} from './ActionTypes';

export function requestSessions() {
  return { type: SESSIONS_REQUEST };
}

export function receiveSessions(response) {
  return { type: SESSIONS_RESPONSE, response: response };
}

export function requestSessionsForFilm() {
  return { type: SESSIONS_FOR_FILM_REQUEST };
}

export function receiveSessionsForFilm(response) {
  return { type: SESSIONS_FOR_FILM_RESPONSE, response: response };
}
