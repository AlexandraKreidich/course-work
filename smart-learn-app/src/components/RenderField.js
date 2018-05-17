import React from "react";

import "../styles/lib/bootstrap.min.css";
import "../styles/index.css";

const RenderField = ({ input, label, type, meta: { touched, error } }) => (
  <React.Fragment>
    {touched && error && <span className="validation-error-text">{error}</span>}
    <input
      {...input}
      placeholder={label}
      type={type}
      autoComplete="new-password"
    />
  </React.Fragment>
);

export { RenderField };
