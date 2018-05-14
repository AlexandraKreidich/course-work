import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { fetchHallModel } from '../actions/Actions';
import { Hall } from '../components/Hall';
import PlaceInfo from '../components/PlaceInfo';

function createRows(places, scheme) {
  const rows = scheme.map(elem => {
    let row = new Object();
    let rowPlaces = new Array();
    row.rowNumber = elem.rowNumber;

    places.forEach(element => {
      if (element.rowNumber === elem.rowNumber) {
        rowPlaces.push({
          placeId: element.id,
          placeNumber: element.placeNumber,
          rowNumber: element.rowNumber,
          placePrice: element.price,
          placePriceId: element.priceId,
          placeType: element.type.name,
          placeStatus: element.placeStatus
        });
      }
    });
    row.places = rowPlaces;
    return row;
  });
  return rows;
}

class HallModelContainer extends React.Component {
  constructor(props) {
    super(props);
    this.onPlaceClick = this.onPlaceClick.bind(this);
    this.onBookBtnClick = this.onBookBtnClick.bind(this);
    this.state = {
      rows: [],
      isPlaceChoosen: false,
      placeInfo: null
    };
  }

  componentDidMount() {
    this.props
      .fetchHallModel(this.props.match.params.hallId, this.props.match.params.sessionId)
      .then(() => {
        this.setState({
          rows: createRows(this.props.hall.hall.placesApi, this.props.hall.hall.hallSchemeApiModels)
        });
      });
  }

  onPlaceClick(rowNumber, placeNumber) {
    if (!this.state.isPlaceChoosen) {
      this.setState({
        isPlaceChoosen: true,
        placeInfo: this.state.rows[rowNumber - 1].places[placeNumber - 1]
      });
    } else {
      if (
        this.state.placeInfo.rowNumber == rowNumber &&
        this.state.placeInfo.placeNumber == placeNumber
      ) {
        this.setState({
          isPlaceChoosen: false,
          placeInfo: null
        });
      } else {
        this.setState({
          isPlaceChoosen: true,
          placeInfo: this.state.rows[rowNumber - 1].places[placeNumber - 1]
        });
      }
    }
  }

  onBookBtnClick() {
    // placePriceId -> setTicket and go to the ticketComponent
    console.log(this.state.placeInfo.placePriceId);
  }

  render() {
    console.log('render');
    return (
      <div className="text-center hall-container">
        {this.props.hall.hall && (
          <h3>
            <strong> Cinema: </strong> {this.props.hall.hall.cinemaName} <strong> Hall: </strong>{' '}
            {this.props.hall.hall.hallName}
          </h3>
        )}
        {this.props.hall.hall && <Hall onPlaceClick={this.onPlaceClick} rows={this.state.rows} />}
        {this.state.isPlaceChoosen && (
          <PlaceInfo {...this.state.placeInfo} onBookBtnClick={this.onBookBtnClick} />
        )}
      </div>
    );
  }
}

const mapStateToProps = function(store) {
  return {
    hall: store.hall
  };
};

const mapDispatchToProps = dispatch => ({
  fetchHallModel: (hallId, sessionId) => dispatch(fetchHallModel(hallId, sessionId))
});

const HallContainer = withRouter(connect(mapStateToProps, mapDispatchToProps)(HallModelContainer));

export { HallContainer };
