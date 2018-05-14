import React from 'react';
import Select from '../components/Select';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import { fetchFilters } from '../actions/Actions';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { setVisibilityFilter } from '../actions/ActionCreators';
import { fetchFilteredFilms } from '../../films/actions/Actions';

import '../../bootstrap.css';
import '../../index.css';
import 'react-datepicker/dist/react-datepicker.css';

class SearchBarContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      date: moment()
    };
    this.handleChange = this.handleChange.bind(this);
    this.onCitiesSelectChange = this.onCitiesSelectChange.bind(this);
    this.onCinemasSelectChange = this.onCinemasSelectChange.bind(this);
    this.onFreePlacesInputChange = this.onFreePlacesInputChange.bind(this);
    this.onResetDateClick = this.onResetDateClick.bind(this);
  }

  componentDidMount() {
    this.props.fetchFilters();
    this.props.fetchFilteredFilms(this.props.visibilityFilters);
  }

  handleChange(date) {
    this.setState({
      date: date
    });
    this.props.setVisibilityFilter({
      date: date.format('YYYY-DD-MM') ? date.format('YYYY-DD-MM') : ''
    });
  }

  onCitiesSelectChange(e) {
    if (e.target.value == 'All Cities') {
      this.props.setVisibilityFilter({
        city: ''
      });
    } else {
      this.props.setVisibilityFilter({
        city: e.target.value
      });
    }
  }

  onCinemasSelectChange(e) {
    if (e.target.value == 'All Cinemas') {
      this.props.setVisibilityFilter({
        cinema: ''
      });
    } else {
      this.props.setVisibilityFilter({
        cinema: e.target.value
      });
    }
  }

  onFreePlacesInputChange(e) {
    this.props.setVisibilityFilter({
      freePlaces: e.target.value
    });
  }

  onResetDateClick() {
    this.props.setVisibilityFilter({
      date: ''
    });
  }

  componentWillReceiveProps(newProps) {
    if (
      newProps.visibilityFilters.date === '' &&
      this.props.visibilityFilters.date !== newProps.visibilityFilters.date
    ) {
      this.props.fetchFilteredFilms(newProps.visibilityFilters);
    }
  }

  render() {
    return (
      <div className="container-fluid search-bar">
        {this.props.isFiltersLoading ? (
          <p>Loading...</p>
        ) : (
          <div className="row justify-content-md-center">
            <Select
              onChange={this.onCitiesSelectChange}
              name={'All Cities'}
              options={this.props.filters.cities}
            />
            <Select
              onChange={this.onCinemasSelectChange}
              name={'All Cinemas'}
              options={this.props.filters.cinemas}
            />
            <input
              type="number"
              onInput={this.onFreePlacesInputChange}
              className="search-bar__input"
              placeholder="free places"
            />
            <DatePicker
              className="search-bar__select"
              selected={this.state.date}
              onChange={this.handleChange}
            />
            <button
              type="button"
              onClick={this.onResetDateClick}
              className="btn btn-outline-info reset-btn"
            >
              Reset date
            </button>
          </div>
        )}
      </div>
    );
  }
}

const mapStateToProps = function(store) {
  return {
    filters: store.searchBar.filtersInfo,
    isFiltersLoading: store.searchBar.isFiltersLoading,
    visibilityFilters: store.searchBar.visibilityFilters
  };
};

const mapDispatchToProps = dispatch => ({
  fetchFilters: () => dispatch(fetchFilters()),
  setVisibilityFilter: filters => dispatch(setVisibilityFilter(filters)),
  fetchFilteredFilms: filters => dispatch(fetchFilteredFilms(filters))
});

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(SearchBarContainer));
