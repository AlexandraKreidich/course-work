import { url } from '../../config.js';

import {
  setUser,
  registerUser,
  failRegistration,
  loginUser,
  failLogin,
  logoutUser
} from '../actions/ActionCreators';

function logInUser(email, password) {
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify({ email, password })
  };

  return function(dispatch) {
    dispatch(loginUser());

    return fetch(url + 'api/account/login', requestOptions)
      .then(function(response) {
        if (response.status !== 200) {
          return dispatch(failLogin());
        }
        return response.json();
      })
      .then(function(responseJson) {
        if (responseJson && responseJson.token) {
          let userData = {
            id: responseJson.id,
            userRole: responseJson.userRole,
            email: responseJson.email,
            firstName: responseJson.firstName,
            lastName: responseJson.lastName,
            token: responseJson.token
          };
          dispatch(setUser(userData));

          return userData;
        }
        return null;
      })
      .then(function(userData) {
        localStorage.setItem('userData', JSON.stringify(userData));
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}

function registerNewUser(email, firstName, lastName, password) {
  const requestOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
    body: JSON.stringify({ email, firstName, lastName, password })
  };

  return function(dispatch) {
    dispatch(registerUser());

    return fetch(url + 'api/account/register', requestOptions)
      .then(function(response) {
        if (response.status === 400) {
          return dispatch(failRegistration());
        }
        return response.json();
      })
      .then(function(responseJson) {
        if (responseJson && responseJson.token) {
          dispatch(logInUser(responseJson.email, password));
        }
      })
      .catch(function(error) {
        console.log(error);
      });
  };
}

function logout() {
  return function(dispatch) {
    localStorage.removeItem('userData');
    dispatch(logoutUser());
  };
}

function loadUserDataFromLocalStorage() {
  let userData = localStorage.getItem('userData');
  if (userData === null) {
    return {
      id: 0,
      userRole: null,
      email: null,
      firstName: null,
      lastName: null,
      token: null
    };
  }
  return JSON.parse(userData);
}

export { logInUser, registerNewUser, loadUserDataFromLocalStorage, logout };
