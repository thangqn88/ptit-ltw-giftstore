import { useState } from "react";
import {
  Box,
  Container,
  createTheme,
  CssBaseline,
  ThemeProvider,
} from "@mui/material";
import NavBar from "./NavBar";
import { Outlet } from "react-router-dom";

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? "dark" : "light";
  const darkTheme = createTheme({
    palette: {
      mode: paletteType,
    },
  });

  const toggleDarkMode = () => {
    setDarkMode(!darkMode);
  };
  return (
    <ThemeProvider theme={darkTheme}>
      <CssBaseline />
      <NavBar darkMode={darkMode} toggleDarkMode={toggleDarkMode} />
      <Box
        sx={{
          minHeight: "100vh",
          background: darkMode
            ? "radial-gradient(circle, #1e3aBa, #111B27"
            : "radial-gradient(circle, #baecf9, #f0f9ff",
          py: 6,
        }}
      >
        <Container maxWidth="xl" sx={{ mt: 14 }}>
          <Outlet />
        </Container>
      </Box>
    </ThemeProvider>
  );
}

export default App;
