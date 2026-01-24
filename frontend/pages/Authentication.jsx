import EmailInput from "../components/EmailInput";
import PasswordInput from "../components/PasswordInput"
import AuthSubmitButton from "../components/AuthSubmitButton"
import AuthTypeToggler from "../components/AuthTypeToggler"

function Authentication() {
    return <div className="flex justify-center">
                <div className="flex flex-col items-center">
                    <h1 className="text-3xl font-bold underline" >Login</h1>
                    <EmailInput />
                    <PasswordInput />
                    <AuthSubmitButton />
                    <AuthTypeToggler />
            </div>
        </div>;
}

export default Authentication;