import { FILTERS_REQUEST, FILTERS_RESPONSE, VISIBILITY_FILTER_SET } from '../actions/ActionTypes';

const initialStateForVisibilityFilters = {
  film: '',
  city: '',
  cinema: '',
  date: '',
  freePlaces: '0'
};

const initialState = {
  isFiltersLoading: false,
  visibilityFilters: initialStateForVisibilityFilters,
  filtersInfo: {
    cities: [],
    films: [],
    cinemas: []
  }
};

const SearchBarReducer = function(state = initialState, action) {
  switch (action.type) {
    case FILTERS_REQUEST:
      return {
        ...state,
        isFiltersLoading: true
      };
    case FILTERS_RESPONSE:
      return {
        ...state,
        filtersInfo: {
          ...state.filtersInfo,
          films: action.response.filmNames,
          cinemas: action.response.cinemaNames,
          cities: action.response.cityNames
        },
        isFiltersLoading: false
      };
    case VISIBILITY_FILTER_SET:
      console.log(action.filters);
      return {
        ...state,
        visibilityFilters: {
          ...state.visibilityFilters,
          film:
            action.filters.film !== undefined ? action.filters.film : state.visibilityFilters.film,
          city:
            action.filters.city !== undefined ? action.filters.city : state.visibilityFilters.city,
          cinema:
            action.filters.cinema !== undefined
              ? action.filters.cinema
              : state.visibilityFilters.cinema,
          date:
            action.filters.date !== undefined ? action.filters.date : state.visibilityFilters.date,
          freePlaces: action.filters.freePlaces
            ? action.filters.freePlaces
            : state.visibilityFilters.freePlaces
        }
      };
  }
  return state;
};

export { SearchBarReducer };
