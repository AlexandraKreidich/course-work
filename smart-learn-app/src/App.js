import React, { Component } from "react";
import Header from "./containers/Header";

import "./styles/lib/bootstrap.min.css";
import "./styles/lib/font-awesome/css/font-awesome.min.css";
import "./styles/index.css";

import BrainImg from "./img/brain.png";
import Routes from "./Routes";

class App extends Component {
  render() {
    return (
      <div>
        <Header />
        <Routes />
        <main id="main">
          <section id="about">
            <div className="container">
              <div className="row about-container">
                <div className="col-lg-6 content order-lg-1 order-2">
                  <h2 className="title">Few Words About App</h2>
                  <p>
                    Spaced repetition is a learning technique that incorporates
                    increasing intervals of time between subsequent review of
                    previously learned material in order to exploit the
                    psychological spacing effect. In 1939, Spitzer tested over
                    3600 students in Iowa and showed that spaced repetition was
                    effective. This early work went unnoticed, and the field was
                    relatively quiet until the late 1960s. In 1973 Sebastian
                    Leitner devised his "Leitner system", an all-purpose spaced
                    repetition learning system based on flashcards.
                  </p>

                  <div className="icon-box wow fadeInUp">
                    <div className="icon">
                      <i className="fa fa-shopping-bag" />
                    </div>
                    <h4 className="title">
                      <a href="">Fact</a>
                    </h4>
                    <p className="description">
                      over 90% of the information disappears within a few days
                    </p>
                  </div>

                  <div className="icon-box wow fadeInUp" data-wow-delay="0.2s">
                    <div className="icon">
                      <i className="fa fa-photo" />
                    </div>
                    <h4 className="title">
                      <a href="">How it works</a>
                    </h4>
                    <p className="description">
                      Each day, check the Smart Learn App: it will present you
                      with a list of flashcards, which have been scheduled for
                      repetition on that day.
                    </p>
                  </div>

                  <div className="icon-box wow fadeInUp" data-wow-delay="0.4s">
                    <div className="icon">
                      <i className="fa fa-bar-chart" />
                    </div>
                    <h4 className="title">
                      <a href="">What is more</a>
                    </h4>
                    <p className="description">
                      For each flashcard Smart Learn App will show you the
                      answer and you rate your performance on this flashcard.
                    </p>
                  </div>
                </div>
                <div className="col-lg-6 background order-lg-2 order-1 wow fadeInRight">
                  <img className="brain-img img-fluid" src={BrainImg} />{" "}
                </div>
              </div>
            </div>
          </section>
          <section id="call-to-action">
            <div className="container wow fadeIn">
              <div className="row">
                <div className="col-lg-9 text-center text-lg-left">
                  <h3 className="cta-title">
                    Keep moving forward. One step at a time.
                  </h3>
                  <p className="cta-text">
                    The advantage of spaced repetition software is that it
                    automatically manages and schedules revisions in your
                    learning process.{" "}
                  </p>
                </div>
                <div className="col-lg-3 cta-btn-container text-center">
                  <a className="cta-btn align-middle" href="#">
                    Get Started
                  </a>
                </div>
              </div>
            </div>
          </section>
        </main>
      </div>
    );
  }
}

export default App;
