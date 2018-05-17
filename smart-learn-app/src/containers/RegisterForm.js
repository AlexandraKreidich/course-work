import React from "react";
import { Field, reduxForm } from "redux-form";
import { RenderField } from "../components/RenderField";
import { registerNewUser } from "../actions/User";
import { validate } from "../components/FormValidation";
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";

import "../styles/index.css";

class RegisterForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isRegistrationFailed: false
    };
  }

  submit = values => {
    this.props.reset();
    this.props.registerNewUser(
      values.email,
      values.firstName,
      values.lastName,
      values.password
    );
  };

  sigIn = () => {
    this.props.history.push("/login");
  };

  componentWillReceiveProps(newProps) {
    if (newProps.user.isRegistrationFailed) {
      this.setState({ isRegistrationFailed: true });
    } else if (!newProps.user.isRegistrationFailed) {
      this.setState({ isRegistrationFailed: false });
    }

    // if (newProps.user.userData.token !== this.props.user.userData.token) {
    //   this.props.history.push('/films');
    // }
  }

  render() {
    const { handleSubmit, error, pristine, submitting, invalid } = this.props;

    return (
      <section id="hero">
        <div className="hero-container">
          <form onSubmit={handleSubmit(this.submit)} className="login-form">
            <Field
              name="email"
              component={RenderField}
              label="Email"
              type="text"
            />
            <Field
              name="firstName"
              component={RenderField}
              label="First Name"
              type="text"
            />
            <Field
              name="lastName"
              component={RenderField}
              label="Last Name"
              type="text"
            />
            <Field
              name="password"
              component={RenderField}
              label="Password"
              type="password"
            />{" "}
            {error && <strong>{error}</strong>}
            <button
              type="submit"
              disabled={invalid || (submitting && pristine)}
            >
              Register
            </button>
            <p className="message">
              Already registered? <a onClick={this.sigIn}>Sign In</a>
            </p>
            {this.state.isRegistrationFailed && (
              <p className="message">ERROR! User already exists</p>
            )}
          </form>
        </div>
      </section>
    );
  }
}

const mapDispatchToProps = dispatch => ({
  registerNewUser: (email, firstName, lastName, password) =>
    dispatch(registerNewUser(email, firstName, lastName, password))
});

const mapStateToProps = state => ({ user: state.user });

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(
    reduxForm({ form: "RegisterForm", validate: validate })(RegisterForm)
  )
);
