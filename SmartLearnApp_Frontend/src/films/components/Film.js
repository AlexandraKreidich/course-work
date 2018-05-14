import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { DATE_FORMAT_FOR_FILM } from '../../shared/DateFormats';

import '../../bootstrap.css';
import '../../index.css';

class Film extends React.Component {
  constructor(props) {
    super(props);
    this.onFilm = this.onFilm.bind(this);
  }

  onFilm(e) {
    e.preventDefault();
    this.props.onFilmClick(this.props.id);
  }

  render() {
    return (
      <a
        onClick={this.onFilm}
        href="#"
        className="film-item list-group-item list-group-item-action flex-column align-items-start"
      >
        <div className="d-flex w-100 justify-content-between">
          <h5 className="mb-1">
            <strong>{this.props.name}</strong>
          </h5>
          <small>
            Start rent date: {moment(this.props.startRentDate).format(DATE_FORMAT_FOR_FILM)}
          </small>
        </div>
        <p className="mb-1">
          DESCRIPTION: Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget
          risus varius blandit.
        </p>
        <small>End rent date: {moment(this.props.endRentDate).format(DATE_FORMAT_FOR_FILM)}</small>
      </a>
    );
  }
}

Film.propTypes = {
  onFilmClick: PropTypes.func.isRequired
};

export { Film };
