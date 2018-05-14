import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';

import '../../bootstrap.css';
import '../../index.css';

class PlaceInfo extends React.Component {
  constructor(props) {
    super(props);
    this.onClick = this.onClick.bind(this);
  }

  onClick(e) {
    e.preventDefault();
    this.props.onBookBtnClick();
  }

  render() {
    return (
      <div className="row justify-content-md-center place-info">
        <div className="alert alert-light text-center">
          <h4>Place Information</h4>
          Row: {this.props.rowNumber}
          <br />
          Place: {this.props.placeNumber}
          <br />
          Type: {this.props.placeType}
          <br />
          Price: {this.props.placePrice}
          <br />
          <button type="button" onClick={this.onClick} className="btn btn-info order-ticket-btn">
            Book it
          </button>
        </div>
      </div>
    );
  }
}

export default PlaceInfo;
