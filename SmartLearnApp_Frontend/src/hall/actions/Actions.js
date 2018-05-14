import { requestHallModel, receiveHallModel } from './ActionCreators';
import { url } from '../../config.js';

export function fetchHallModel(hallId, sessionId) {
  const requestOptions = {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  };

  return function(dispatch) {
    dispatch(requestHallModel());

    return fetch(url + 'api/halls/' + hallId + '/session/' + sessionId, requestOptions)
      .then(function(response) {
        return response.json();
      })
      .then(function(response) {
        dispatch(receiveHallModel(response));
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}
