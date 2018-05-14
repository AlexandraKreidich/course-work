import React from 'react';
import PropTypes from 'prop-types';
import { Redirect, Route } from 'react-router-dom';
import { connect } from 'react-redux';

const AuthRoute = props => {
  const { component, token, authenticationRequired, nonAuthenticationRequired } = props;
  
  let redirectTo = props.redirectTo;

  if (authenticationRequired && !token) {
    redirectTo = redirectTo || '/login';
    
    return <Redirect to={redirectTo} push />;
  }

  return <Route {...props} component={component} />;
};

AuthRoute.propTypes = {
  component: PropTypes.oneOfType([PropTypes.element, PropTypes.func]),
  redirectTo: PropTypes.string,
  authenticationRequired: PropTypes.bool,
  nonAuthenticationRequired: PropTypes.bool
};

export default connect(state => ({ token: state.user.userData.token }))(AuthRoute);
