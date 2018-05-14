import { HALL_MODEL_REQUEST, HALL_MODEL_RESPONSE } from './ActionTypes';

export function requestHallModel() {
  return { type: HALL_MODEL_REQUEST };
}

export function receiveHallModel(response) {
  return { type: HALL_MODEL_RESPONSE, response: response };
}
