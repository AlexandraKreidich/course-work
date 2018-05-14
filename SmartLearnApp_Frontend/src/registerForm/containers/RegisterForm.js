import React from 'react';
import { Field, reduxForm } from 'redux-form';
import { RenderField } from '../components/RenderField';
import { registerNewUser } from '../../user/actions/Actions';
import { validate } from '../components/FormValidation';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

import '../../index.css';

class RegisterForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isRegistrationFailed: false
    };
  }

  submit = values => {
    this.props.reset();
    this.props.registerNewUser(values.email, values.firstName, values.lastName, values.password);
  };

  componentWillReceiveProps(newProps) {
    if (newProps.user.isRegistrationFailed) {
      this.setState({ isRegistrationFailed: true });
    } else if (!newProps.user.isRegistrationFailed) {
      this.setState({ isRegistrationFailed: false });
    }

    if (newProps.user.userData.token !== this.props.user.userData.token) {
      this.props.history.push('/films');
    }
  }

  render() {
    const { handleSubmit, error, pristine, submitting } = this.props;

    return (
      <div className="top-indent">
        <form onSubmit={handleSubmit(this.submit)}>
          <Field name="email" component={RenderField} label="Email" type="text" />
          <Field name="firstName" component={RenderField} label="First Name" type="text" />
          <Field name="lastName" component={RenderField} label="Last Name" type="text" />
          <Field name="password" component={RenderField} label="Password" type="password" />{' '}
          {error && <strong>{error}</strong>}
          <div>
            <button type="submit" className="btn btn-primary" disabled={pristine || submitting}>
              Register
            </button>
          </div>
          {this.state.isRegistrationFailed ? (
            <div className="alert alert-danger form-danger">
              <strong>Error!</strong>
              <p>User already exists</p>
            </div>
          ) : (
            <div />
          )}
        </form>
      </div>
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
    reduxForm({ form: 'RegisterForm', validate: validate })(RegisterForm)
  )
);
