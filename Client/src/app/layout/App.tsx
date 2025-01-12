import { useState, useEffect } from "react";
import { Product } from "../models/product";
import Catalog from "../../features/catalog/Catalog";
import {
  Box,
  Container,
  createTheme,
  CssBaseline,
  ThemeProvider,
} from "@mui/material";
import NavBar from "./NavBar";

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? "dark" : "light";
  const darkTheme = createTheme({
    palette: {
      mode: paletteType,
    },
  });

  useEffect(() => {
    fetch("https://localhost:7001/api/products")
      .then((res) => res.json())
      .then((data) => setProducts(data));
  }, []);

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
          <Catalog products={products} />
        </Container>
      </Box>
    </ThemeProvider>
  );
}

export default App;
