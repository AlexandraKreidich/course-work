import React from 'react';

import '../../bootstrap.css';
import '../../index.css';

const Option = ({ text }) => (
  <option
    onClick={e => {
      console.log(e);
    }}
    value={text}
  >
    {text}
  </option>
);

export default Option;
