import { Map, GoogleApiWrapper, Marker } from 'google-maps-react';

const MapContainer = (props) =>{
  const mapStyles = {
    width: '45%',
    height: '70%',
  };
  return (
    <Map
      google={props.google}
      zoom={18}
      style={mapStyles}
      initialCenter={{ lat: 10.424228, lng: -75.551054}}
    >
      <Marker position={{ lat: 10.424228, lng:-75.551054}} />
    </Map>
);
}

export default GoogleApiWrapper({
  apiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY || '' // definir en variable de entorno
})(MapContainer);