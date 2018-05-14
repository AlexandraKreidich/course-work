import {
  HALL_MODEL_REQUEST,
  HALL_MODEL_RESPONSE
} from "../actions/ActionTypes";

const initialState = {
  hall: null,
  isHallLoading: false
};

const hallReducer = function(state = initialState, action) {
  switch (action.type) {
    case HALL_MODEL_REQUEST:
      return {
        ...state,
        isHallLoading: true
      };
    case HALL_MODEL_RESPONSE:
      return {
        ...state,
        hall: action.response,
        isHallLoading: false
      };
  }
  return state;
};

export { hallReducer };
