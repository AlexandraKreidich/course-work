import React from "react";

class HeaderComponent extends React.Component {
  render() {
    return (
      <header id="header">
        <div className="container">
          <div id="logo" className="pull-left">
            <h1>
              <a>Smart Learn</a>
            </h1>
          </div>

          <nav id="nav-menu-container">
            <ul className="nav-menu">
              <li className="menu-active">
                <a href="/">Home</a>
              </li>
              <li>
                <a href="#about">About</a>
              </li>
              {this.props.authorized.token && (
                <React.Fragment>
                  <li>
                    <a href="/user">Hello {this.props.authorized.firstName}</a>
                  </li>
                  <li onClick={this.props.signOut}>
                    <a href="/">Sing out</a>
                  </li>
                </React.Fragment>
              )}
              {!this.props.authorized.token && (
                <li onClick={this.props.signIn}>
                  <a href="/login">Sing in</a>
                </li>
              )}
            </ul>
          </nav>
        </div>
      </header>
    );
  }
}

export { HeaderComponent };
