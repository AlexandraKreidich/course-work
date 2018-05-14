import React from 'react';
import Option from './Option';

import '../../bootstrap.css';
import '../../index.css';

class Select extends React.Component {
  constructor(props) {
    super(props);
    this.onChange = this.onChange.bind(this);
  }

  onChange(e) {
    e.preventDefault();
    this.props.onChange(e);
  }

  render() {
    return (
      <select onChange={this.onChange} className="search-bar__select">
        <Option key={100} text={this.props.name} />
        {this.props.options.map((option, index) => <Option key={index} text={option} />)}
      </select>
    );
  }
}

export default Select;
