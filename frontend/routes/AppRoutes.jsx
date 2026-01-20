import Authentication from "../pages/Authentication.jsx";
import About from "../pages/About.jsx";
import { Routes, Route } from "react-router-dom";

function AppRoutes() {
    return (
        <Routes>
            <Route path="/" element={<Authentication />} />
            <Route path="/about" element={<About />} />
        </Routes>
    );
}

export default AppRoutes;