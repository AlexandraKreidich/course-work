import React from 'react';
import PropTypes from 'prop-types';
import { Row } from './Row';

import '../../bootstrap.css';
import '../../index.css';

const Hall = ({ rows, onPlaceClick }) => (
  <div className="container margin-top-indent">
    {rows.map((row, index) => <Row onPlaceClick={onPlaceClick} key={index} {...row} />)}
  </div>
);

export { Hall };
