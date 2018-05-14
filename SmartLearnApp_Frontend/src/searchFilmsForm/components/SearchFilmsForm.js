import React from 'react';
import { Throttle } from 'react-throttle';

import '../../index.css';

class SearchFilmsForm extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <form className="form-inline">
        <Throttle time="1000" handler="onInput">
          <input
            onInput={this.props.onInputChange}
            className="form-control mr-sm-2"
            type="search"
            placeholder="film name"
            aria-label="Search"
          />
        </Throttle>
        <button
          onClick={this.props.onSearchClick}
          type="button"
          className="btn btn-outline-success my-2 my-sm-0"
        >
          Search
        </button>
      </form>
    );
  }
}

export { SearchFilmsForm };
