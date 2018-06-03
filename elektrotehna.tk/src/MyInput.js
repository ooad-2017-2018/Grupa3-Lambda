import { withFormsy } from 'formsy-react';
import React from 'react';
import { FormGroup, Label, Input } from 'reactstrap';

class MyInput extends React.Component {
  constructor(props) {
    super(props);
    this.changeValue = this.changeValue.bind(this);
  }

  changeValue(event) {
    // setValue() will set the value of the component, which in
    // turn will validate it and the rest of the form
    // Important: Don't skip this step. This pattern is required
    // for Formsy to work.
    this.props.setValue(event.currentTarget.value);
  }

  render() {
    // An error message is returned only if the component is invalid
    const errorMessage = this.props.getErrorMessage();

    return (
      <FormGroup>
            <Label className="h2" for={this.props.id}>{this.props.naslov}</Label>
            <Input size="lg" valid={this.props.isValid()} invalid = {!this.props.isValid() && !this.props.isPristine()}
            onChange={this.changeValue}
            type={this.props.tip || "text"} id={this.props.id}
            value={this.props.getValue() || ''}
            />
            <span>{this.props.isPristine() ? ' ' : errorMessage}</span>
      </FormGroup>
    );
  }
}

export default withFormsy(MyInput);