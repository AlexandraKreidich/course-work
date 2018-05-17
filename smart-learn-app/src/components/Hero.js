import React from "react";

import "../styles/index.css";

const Hero = () => (
  <section id="hero">
    <div className="hero-container">
      <h1>Welcome to Smart Learn</h1>
      <h2>App for spaced repetition to learn everything.</h2>
      <a href="#about" className="btn-get-started">
        Get Started
      </a>
    </div>
  </section>
);

export { Hero };
