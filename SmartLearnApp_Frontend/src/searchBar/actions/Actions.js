import { url } from '../../config.js';
import { requestFilters, receiveFilters, resetVisibilityFilter } from './ActionCreators';

export function fetchFilters() {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  };

  return function(dispatch) {
    dispatch(requestFilters());

    return fetch(url + 'api/films/filters-info', requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveFilters(response));
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}
