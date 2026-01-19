import Home from "../pages/Home.jsx";
import About from "../pages/About.jsx";
import { Routes, Route } from "react-router-dom";

function AppRoutes() {
    return (
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
        </Routes>
    );
}

export default AppRoutes;