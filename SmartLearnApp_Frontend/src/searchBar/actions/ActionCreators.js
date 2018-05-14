import {
  FILTERS_REQUEST,
  FILTERS_RESPONSE,
  VISIBILITY_FILTER_SET,
  VISIBILITY_FILTER_RESET
} from './ActionTypes';

export function requestFilters() {
  return { type: FILTERS_REQUEST };
}

export function receiveFilters(response) {
  return { type: FILTERS_RESPONSE, response: response };
}

export function setVisibilityFilter(filters) {
  return { type: VISIBILITY_FILTER_SET, filters: filters };
}
