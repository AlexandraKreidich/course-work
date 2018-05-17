import React from "react";

import "../styles/lib/bootstrap.min.css";

class UserContentComponent extends React.Component {
  render() {
    return (
      <section id="hero">
        <div className="hero-container">
          <section className="user-content-container">
            <div className="container wow fadeIn">
              <div className="row text-center justify-content-center">
                <h1>User Content</h1>
              </div>
              <div className="row" />
            </div>
          </section>
        </div>
      </section>
    );
  }
}

export default UserContentComponent;
