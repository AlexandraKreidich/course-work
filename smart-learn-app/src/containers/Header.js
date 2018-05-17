import React from "react";
import { HeaderComponent } from "../components/Header";
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { logout } from "../actions/User";

class Header extends React.Component {
  constructor(props) {
    super(props);
  }

  signIn = () => {
    this.props.history.push("/login");
  };

  signOut = () => {
    this.props.logout();
  };

  render() {
    return (
      <HeaderComponent
        signIn={this.signIn}
        signOut={this.props.logout}
        authorized={this.props.user.userData}
      />
    );
  }
}

const mapDispatchToProps = dispatch => ({
  logout: () => dispatch(logout())
});

const mapStateToProps = state => ({ user: state.user });

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Header));
