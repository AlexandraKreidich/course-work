import React from 'react';
import PropTypes from 'prop-types';
import { Session } from './Session';

import '../../bootstrap.css';
import '../../index.css';

const SessionsList = ({ sessions, onSessionClick }) => (
  <ul>
    {sessions.map((session, index) => (
      <Session onSessionClick={onSessionClick} key={index} {...session} />
    ))}
  </ul>
);

export { SessionsList };
