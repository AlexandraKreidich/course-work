import React from 'react';
import { Switch, withRouter } from 'react-router-dom';
import { connect } from 'react-redux';

import { SessionsListContainer } from './sessions/containers/SessionListContainer';
import { FilmListContainer } from './films/containers/FilmListContainer';
import { HallContainer } from './hall/containers/HallContainer';
import RegisterForm from './registerForm/containers/RegisterForm';
import LoginForm from './loginForm/containers/LoginForm';

import AuthRoute from './auth-route';

const Routes = () => {
  return (
    <Switch>
      <AuthRoute path="/login" component={LoginForm} nonAuthenticationRequired />
      <AuthRoute path="/register" component={RegisterForm} nonAuthenticationRequired />
      <AuthRoute
        path="/films/:filmId/sessions"
        component={SessionsListContainer}
        nonAuthenticationRequired
      />
      <AuthRoute
        path="/hall/:hallId/session/:sessionId"
        component={HallContainer}
        authenticationRequired
      />
      <AuthRoute path="/films" component={FilmListContainer} nonAuthenticationRequired />
    </Switch>
  );
};

export default withRouter(connect(state => ({ email: state.user.userData.email }))(Routes));
