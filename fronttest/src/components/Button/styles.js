import styled, { css } from 'styled-components'

export const ButtonComponent = styled.button`
  display: inline-block;
  border-radius: 3px;
  padding: 0.5rem 0;
  margin: 0.5rem 1rem;
  width: 11rem;
  background: black;
  color: white;
  border: 2px solid white;
  
  :hover {
      cursor: pointer;
      background: ${(props) => props.theme.palette.primary};
  }

  ${(props) => props.size === "deletar" && 
  css`
    width: 5rem;
    background: ${(props) => props.theme.palette.secondary};

    :hover {
      cursor: pointer;
    }
  `}

  ${(props) => props.size === "cadastrar" && 
  css`
    width: 60rem;
  `}

  ${(props) => props.size === "editar" && 
  css`
    width: 5rem;
    color: white;
    background: blue;

  `}
  
`