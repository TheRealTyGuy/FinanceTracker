function EmailInput() {
    return <>
        <label for="email" className="block text-sm/6 font-medium">Email:</label>
        <input id="email" type="email" name="email" className="block w-full rounded-md bg-black/10 px-3 py-1.5 text-base text-black outline-1 -outline-offset-1 outline-black/10 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-500 sm:text-sm/6"/>
    </>
}

export default EmailInput;