import React from 'react';
import { Field, reduxForm } from 'redux-form';
import { RenderField } from '../components/RenderField';
import { logInUser } from '../../user/actions/Actions';
import { validate } from '../components/FormValidation';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

class LoginForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoginFailed: false
    };
    this.submit = this.submit.bind(this);
  }

  submit(values) {
    this.props.reset();
    this.props.untouch();
    this.props.logInUser(values.email, values.password);
  }

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
      this.props.history.push('/films');
    }
  }

  render() {
    const { handleSubmit, error, pristine, submitting } = this.props;

    return (
      <div className="top-indent">
        <form onSubmit={handleSubmit(this.submit)}>
          <Field name="email" component={RenderField} label="Email" type="text" />
          <Field
            name="password"
            component={RenderField}
            label="Password"
            type="password"
          /> <br /> {error && <strong>{error}</strong>}
          <div>
            <button type="submit" className="btn btn-primary" disabled={pristine || submitting}>
              Log in
            </button>
          </div>
        </form>
        {this.state.isLoginFailed ? (
          <div className="alert alert-danger form-danger">
            <strong>Error!</strong>
            <p> Invalid login or email</p>
          </div>
        ) : (
          <div />
        )}
      </div>
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
    reduxForm({ form: 'loginForm', validate: validate })(LoginForm)
  )
);
