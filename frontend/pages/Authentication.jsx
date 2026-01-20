import EmailInput from "../components/EmailInput";
import PasswordInput from "../components/PasswordInput"
import AuthSubmitButton from "../components/AuthSubmitButton"
import AuthTypeToggler from "../components/AuthTypeToggler"

function Authentication() {
    return <>
        <h1>Login</h1>
        <EmailInput />
        <PasswordInput />
        <AuthSubmitButton />
        <AuthTypeToggler />
    </>
}

export default Authentication;