import { ThemeProvider } from "styled-components";
import Routes from "./router/routes";
import GlobalStyles from "./styles/globalStyles";
import { lightTheme } from "./styles/theme";

const App = () => {
  return (
    <ThemeProvider theme={lightTheme}>
      <GlobalStyles />
      <Routes />
    </ThemeProvider>
  );
};

export default App