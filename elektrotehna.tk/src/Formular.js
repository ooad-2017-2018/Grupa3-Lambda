import React from 'react';
import Formsy from 'formsy-react';
import MyInput from './MyInput';
import { Form, Button } from 'reactstrap';
import { addValidationRule } from 'formsy-react';



addValidationRule('required', function (values, value) {
  return value && value.trim().length;
});

export default class Formular extends React.Component {
  constructor(props) {
    super(props);
    this.disableButton = this.disableButton.bind(this);
    this.enableButton = this.enableButton.bind(this);
    this.state = { canSubmit: false };
  }

  disableButton() {
    this.setState({ canSubmit: false });
  }

  enableButton() {
    this.setState({ canSubmit: true });
  }

  submit(model) {
    fetch('https://ambasadaapinet2018.azurewebsites.net/api/Podnosilac', {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(model)
    });
  }

  render() {
    return (
      <Form>
      <Formsy onValidSubmit={this.submit} onValid={this.enableButton} onInvalid={this.disableButton}>
        <MyInput
          name="naziv" naslov="Ime i prezime"
          validationError="Potrebno je upisati ime i prezime"
          validations="required"
        />
        <MyInput
          name="mjestoPrebivalista" naslov="Prebivalište"
          validationError="Potrebno je upisati prebivalište"
          validations="required"
        />
        <MyInput
          name="datumRodjenja" naslov="Datum rođenja" tip="date"
          validationError="Potrebno je upisati datum rođenja"
          validations="required"
        />        
        <MyInput
        name="jmbg" naslov="JMBG"
        validations="isNumeric"
        validationError="JMBG se sastoji od cifara"
        required
        />
        <MyInput
          name="email" naslov="Email"
          validations="isEmail"
          validationError="E-mail nije validan"
          required
        />
        <MyInput
        name="dodatneInformacije" naslov="Dodatne informacije" tip="textarea"        
        />

        <Button type="submit" size="lg" color="primary" className="float-right" disabled={!this.state.canSubmit}>Submit</Button>

      </Formsy>
      </Form>
    
    );
  }
}