import {
  USER_REGISTER,
  USER_FAIL_REGISTRATION,
  USER_LOGIN,
  USER_FAIL_LOGIN,
  USER_SET,
  USER_LOGOUT
} from "../actionTypes/ActionTypes";

import { loadUserDataFromLocalStorage } from "../actions/User";

const initialState = {
  isRegistrationInProgress: false,
  isRegistrationFailed: false,
  isLoginInProgress: false,
  isLoginFailed: false,
  userData: loadUserDataFromLocalStorage()
};

const userReducer = function(state = initialState, action) {
  switch (action.type) {
    case USER_REGISTER:
      return {
        ...state,
        isRegistrationInProgress: true,
        isRegistrationFailed: false
      };
    case USER_FAIL_REGISTRATION:
      return {
        ...state,
        isRegistrationFailed: true
      };
    case USER_LOGIN:
      console.log("user_login");
      return {
        ...state,
        isLoginInProgress: true,
        isLoginFailed: false
      };
    case USER_FAIL_LOGIN:
      console.log("user_fail_login");
      return {
        ...state,
        isLoginFailed: true
      };
    case USER_LOGOUT:
      return {
        ...initialState
      };
    case USER_SET:
      console.log("user_set");
      if (state.isLoginFailed) {
        return {
          ...initialState
        };
      } else {
        return {
          ...state,
          isLoginInProgress: false,
          userData: {
            id: action.user.id,
            userRole: action.user.userRole,
            email: action.user.email,
            firstName: action.user.firstName,
            lastName: action.user.lastName,
            token: action.user.token
          }
        };
      }
    default:
      return state;
  }
};

export { userReducer };
