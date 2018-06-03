import React, { Component } from 'react';
import Formular from './Formular.js';
import { Jumbotron, Container } from 'reactstrap';

class App extends Component {
  render() {
    return (
      <Container>
        <br/> <br/>
        <Jumbotron>
        <h1 className="display-3">Prijava vize</h1>
        <hr className="my-2" />
        <p className="lead">Molimo vas da čitko i uredno popunite formular.</p>
        </Jumbotron>
        <Formular />
        <br/>
        
      </Container>
    );
  }
}

export default App;
