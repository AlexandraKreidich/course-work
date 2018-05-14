import { requestFilms, receiveFilms } from './ActionCreators';
import { url } from '../../config.js';

export function fetchFilms() {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  };

  return function(dispatch) {
    dispatch(requestFilms());

    return fetch(url + 'api/films/now-playing', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveFilms(response));
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}

export function fetchFilteredFilms(filters) {
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify(filters)
  };

  return function(dispatch) {
    dispatch(requestFilms());

    return fetch(url + 'api/films/search-films', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveFilms(response));
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}
