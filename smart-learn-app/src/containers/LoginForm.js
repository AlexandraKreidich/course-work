import React from "react";
import { Field, reduxForm } from "redux-form";
import { RenderField } from "../components/RenderField";
import { logInUser } from "../actions/User";
import { validate } from "../components/FormValidation";
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";

import "../styles/index.css";

class LoginForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoginFailed: false
    };
    this.submit = this.submit.bind(this);
  }

  submit(values) {
    this.props.logInUser(values.emailLogin, values.passwordLogin);
    this.props.reset();
    this.props.untouch();
  }

  register = () => {
    this.props.history.push("/register");
  };

  componentWillReceiveProps(newProps) {
    if (newProps.user.isLoginFailed) {
      this.setState({
        isLoginFailed: true
      });
    } else if (!newProps.user.isLoginFailed) {
      this.setState({
        isLoginFailed: false
      });
    }

    if (newProps.user.userData.token) {
      this.props.history.push("/user");
    }
  }

  render() {
    const { handleSubmit, error, pristine, submitting, invalid } = this.props;

    return (
      <section id="hero">
        <div className="hero-container">
          <form onSubmit={handleSubmit(this.submit)} className="login-form">
            <Field
              name="emailLogin"
              component={RenderField}
              label="Email"
              type="text"
            />
            <Field
              name="passwordLogin"
              component={RenderField}
              label="Password"
              type="password"
            />
            {error && <strong>{error}</strong>}
            <button
              disabled={invalid || (submitting && pristine)}
              type="submit"
            >
              login
            </button>
            <p className="message">
              Not registered? <a onClick={this.register}>Create an account</a>
            </p>
            {this.state.isLoginFailed && (
              <p className="message error"> ERROR! Invalid login or email</p>
            )}
          </form>
        </div>
      </section>
    );
  }
}

const mapDispatchToProps = dispatch => ({
  logInUser: (email, password) => dispatch(logInUser(email, password))
});

const mapStateToProps = state => ({
  user: state.user
});

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(
    reduxForm({ form: "loginForm", validate: validate })(LoginForm)
  )
);
