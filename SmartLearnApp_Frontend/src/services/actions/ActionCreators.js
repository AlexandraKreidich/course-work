import {
    SERVICES_FOR_SESSION_REQUEST,
    SERVICES_FOR_SESSION_RESPONSE
} from './ActionTypes';


export function requestServicesForSession() {
    return { type: SERVICES_FOR_SESSION_REQUEST };
}
  
export function receiveServicesForSession(response) {
    return { type: SERVICES_FOR_SESSION_RESPONSE, response: response };
}