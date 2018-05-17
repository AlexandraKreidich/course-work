import React from "react";
import { Switch, withRouter } from "react-router-dom";
import { connect } from "react-redux";
import LoginForm from "./containers/LoginForm";
import RegisterForm from "./containers/RegisterForm";
import UserContent from "./containers/UserContent";
import AuthRoute from "./Auth-route";
import { Hero } from "./components/Hero";

const Routes = () => {
  return (
    <Switch>
      <AuthRoute
        path="/login"
        component={LoginForm}
        nonAuthenticationRequired
      />
      <AuthRoute
        path="/register"
        component={RegisterForm}
        nonAuthenticationRequired
      />
      <AuthRoute path="/user" component={UserContent} AuthenticationRequired />
      <AuthRoute path="/" component={Hero} nonAuthenticationRequired />
    </Switch>
  );
};

export default withRouter(
  connect(state => ({ email: state.user.userData.email }))(Routes)
);
