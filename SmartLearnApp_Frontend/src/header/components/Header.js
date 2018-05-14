import React from 'react';
import { Link } from 'react-router-dom';
import { SearchFilmsForm } from '../../searchFilmsForm/components/SearchFilmsForm';

import '../../index.css';
import '../../bootstrap.css';

const Header = props => (
  <nav className="navbar navbar-light bg-light justify-content-between">
    <Link to="/" className="navbar-brand">
      <img className="logo-img" src="logo.svg" width="30" height="30" alt="" />
      TicketsOnline
    </Link>
    <SearchFilmsForm onInputChange={props.onInputChange} onSearchClick={props.onSearchClick} />
    <div className="btn-group" role="group">
      <button type="button" className="btn btn-link">
        <Link to="/login">Login</Link>
      </button>
      <button type="button" className="btn btn-link">
        <Link to="/register">Register</Link>
      </button>
    </div>
  </nav>
);

export { Header };
