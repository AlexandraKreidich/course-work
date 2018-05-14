import React from 'react';
import PropTypes from 'prop-types';
import { PlaceStatus } from '../../shared/PlaceStatus';

import '../../bootstrap.css';
import '../../index.css';

class Place extends React.Component {
  constructor(props) {
    super(props);
    this.onClick = this.onClick.bind(this);
  }

  onClick(e) {
    e.preventDefault();
    this.props.onPlaceClick(this.props.rowNumber, this.props.placeNumber, this.props.placeStatus);
  }

  render() {
    if(this.props.placeStatus === PlaceStatus.Free){
      return (
        (<button onClick={this.onClick}  type="button" className="btn btn-outline-primary">
          {this.props.placeNumber}
        </button>)
      );
    }else{
      return (
        (<button onClick={this.onClick}  type="button" disabled className="btn btn-secondary">
          {this.props.placeNumber}
        </button>)
      );
    }
    
  }
}

export { Place };
