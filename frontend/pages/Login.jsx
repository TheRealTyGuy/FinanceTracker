import { Link } from "react-router";
import { useState } from "react";
import EmailInput from "../components/EmailInput";
import PasswordInput from "../components/PasswordInput";
import AuthSubmitButton from "../components/AuthSubmitButton";

function Login() {
  const [ email, setEmail ] = useState("");
  const [ password, setPassword ] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("http://localhost:5290/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({
          email: email,
          password: password
        })
      });

      const tokens = await response.json();
      
      sessionStorage.setItem("accessToken", tokens.accessToken);
      
      console.log("Status: ", response.status);
    } catch (error) {
      console.error("Error: ", error);
    }
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100 px-4">
      <div className="w-full max-w-md rounded-lg bg-white p-8 shadow-md flex flex-col items-center">
        <h1 className="mb-6 text-3xl font-semibold text-gray-900">
          Sign in
        </h1>

        <form onSubmit={handleSubmit} className="w-full space-y-4">
          <EmailInput 
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />

          <PasswordInput 
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />

          <AuthSubmitButton />
        </form>

        <p className="mt-6 text-sm text-gray-600">
          New user?{" "}
          <Link
            to="/register"
            className="font-medium text-blue-600 hover:text-blue-500 hover:underline transition-colors"
          >
            Register
          </Link>
        </p>
        
      </div>
    </div>
  );
}

export default Login;