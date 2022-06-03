import { ButtonComponent } from "./styles";

const Button = (props) => {
  return (
    <ButtonComponent
      onClick={props.onClick}
      size={props.size}
    >
      {props.text}
    </ButtonComponent>
  );
};

export default Button;
