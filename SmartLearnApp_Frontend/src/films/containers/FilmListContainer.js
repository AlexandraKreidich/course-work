import React from 'react';
import { connect } from 'react-redux';
import { FilmList } from '../components/FilmList';
import { fetchFilteredFilms } from '../actions/Actions';
import loadImg from '../../load-img.gif';
import { withRouter } from 'react-router-dom';

import '../../bootstrap.css';
import '../../index.css';

class FilmContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  onFilmClick = id => {
    this.props.history.push('/films/' + id + '/sessions');
  };

  render() {
    return (
      <div className="top-indent justify-content-md-center">
        {this.props.isLoading && (
          <div className="text-center div-load-img">
            <img className="img-responsive" width="50px" height="50px" src={loadImg} />
          </div>
        )}
        {this.props.films && <FilmList films={this.props.films} onFilmClick={this.onFilmClick} />}
      </div>
    );
  }
}

const mapStateToProps = function(store) {
  return {
    isLoading: store.film.isFilmsLoading,
    films: store.film.films
  };
};

const FilmListContainer = withRouter(connect(mapStateToProps)(FilmContainer));

export { FilmListContainer };
