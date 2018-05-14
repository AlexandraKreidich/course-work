import { FILMS_REQUEST, FILMS_RESPONSE } from './ActionTypes';

export function requestFilms() {
  return { type: FILMS_REQUEST };
}

export function receiveFilms(response) {
  return { type: FILMS_RESPONSE, response: response };
}
