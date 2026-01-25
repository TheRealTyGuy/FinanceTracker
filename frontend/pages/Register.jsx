import { Link } from "react-router";
import EmailInput from "../components/EmailInput";
import PasswordInput from "../components/PasswordInput";
import AuthSubmitButton from "../components/AuthSubmitButton";

function Authentication() {
  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100 px-4">
      <div className="w-full max-w-md rounded-lg bg-white p-8 shadow-md flex flex-col items-center">
        <h1 className="mb-6 text-3xl font-semibold text-gray-900">
          Sign up
        </h1>

        <div className="w-full space-y-4">
          <EmailInput />
          <PasswordInput />
          <AuthSubmitButton />
        </div>
        
        <p className="mt-6 text-sm text-gray-600">
          Already have an account?{" "}
          <Link
            to="/login"
            className="font-medium text-blue-600 hover:text-blue-500 hover:underline transition-colors"
          >
            Log in
          </Link>
        </p>

      </div>
    </div>
  );
}

export default Authentication;