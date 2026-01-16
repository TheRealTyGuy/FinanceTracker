import { Outlet, Scripts } from "react-router";

export default function App() {
    return (
        <html>
            <head>
                <link
                    rel="icon"
                    href="data:image/x-icon;base64,AA"
                />
            </head>
            <body>
                <h1>Hello world 2!</h1>
                <Outlet />
                <Scripts />
            </body>
        </html>
    )
}