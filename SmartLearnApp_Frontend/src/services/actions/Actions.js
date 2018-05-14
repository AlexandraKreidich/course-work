import {
    requestServicesForSession,
    receiveServicesForSession
} from './ActionCreators';

function fetchServicesForSessions(sessionId) {
    const requestOptions = {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      }
    };
    return function(dispatch) {
      dispatch(requestSessionsForFilm());
  
      return fetch(url + 'api/sessions/' + sessionId + '/services', requestOptions)
        .then(function(response) {
          return response.json();
        })
        .then(function(response) {
          dispatch(receiveSessionsForFilm(response));
        });
    };
}