import {
  requestSessions,
  receiveSessions,
  requestSessionsForFilm,
  receiveSessionsForFilm
} from './ActionCreators';

import { url } from '../../config.js';

function fetchSessions() {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  };
  return function(dispatch) {
    dispatch(requestSessions());

    return fetch(url + 'api/sessions', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveSessions(response));
      });
  };
}

function fetchSessionsForFilm(filmId) {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  };
  return function(dispatch) {
    dispatch(requestSessionsForFilm());

    return fetch(url + 'api/films/' + filmId + '/sessions', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveSessionsForFilm(response));
      });
  };
}

export { fetchSessionsForFilm };
