import {
  USER_REGISTER,
  USER_FAIL_REGISTRATION,
  USER_LOGIN,
  USER_FAIL_LOGIN,
  USER_SET,
  USER_LOGOUT
} from './ActionTypes';

export function setUser(user) {
  return { type: USER_SET, user: user };
}

export function registerUser(user) {
  return { type: USER_REGISTER };
}

export function failRegistration() {
  return { type: USER_FAIL_REGISTRATION };
}

export function loginUser() {
  return { type: USER_LOGIN };
}

export function failLogin() {
  return { type: USER_FAIL_LOGIN };
}

export function logoutUser() {
  return { type: USER_LOGOUT };
}
