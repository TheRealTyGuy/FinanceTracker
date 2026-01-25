function PasswordInput() {
    return (
        <div>
            <label
                htmlFor="password"
                className="block text-sm/6 font-medium text-gray-900"
            >
                Password
            </label>
            <input
                id="password"
                name="password"
                type="password"
                autoComplete="current-password"
                required
                className="block w-full rounded-md bg-black/10 px-3 py-1.5 text-base text-black outline outline-1 outline-black/10 focus:outline-2 focus:outline-indigo-500 sm:text-sm"
            />
        </div>
    );
}

export default PasswordInput;
