import EmailInput from "../components/EmailInput";
import PasswordInput from "../components/PasswordInput"
import AuthSubmitButton from "../components/AuthSubmitButton"
import AuthTypeToggler from "../components/AuthTypeToggler"

function Authentication() {
    return <div class="flex-column justify-center">
        <h1 class="text-3xl font-bold underline" >Login</h1>
        <EmailInput />
        <PasswordInput />
        <AuthSubmitButton />
        <AuthTypeToggler />
    </div>
}

export default Authentication;