import {
    requestServicesForSession,
    receiveServicesForSession
  } from '../actions/ActionCreators';
  
  import {
    SERVICES_FOR_SESSION_REQUEST,
    SERVICES_FOR_SESSION_RESPONSE
  } from '../actions/ActionTypes';
  
  const initialState = {
    services: [],
    isServicesLoading: false
  };
  
  const serviceReducer = function(state = initialState, action) {
    switch (action.type) {
      case SERVICES_FOR_SESSION_REQUEST:
        return {
          ...state,
          isServicesLoading: true
        };
      case SERVICES_FOR_SESSION_RESPONSE:
        return {
          ...state,
          services: action.response,
          isServicesLoading: false
        };
    }
    return state;
  };
  
  export { serviceReducer };
  