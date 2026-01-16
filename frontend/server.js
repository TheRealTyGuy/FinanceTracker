import { createRequestHandler } from "@react-router/express";
import express from "express";

const app = express();
app.use(express.static("build/client"));

// app is "just a request handler"
if (process.env.NODE_ENV == "production") {
    app.use(
        createRequestHandler({
            // result of `react-router build` is "just a module"
            build: await import("./build/server/index.js")
        })
    );
} else {
    const viteDevServer = await import("vite").then((vite) =>
        vite.createServer({
            server: { middlewareMode: true },
        })
    );
    app.use(viteDevServer.middlewares);
    app.use(
        createRequestHandler({
            build: () =>
                viteDevServer.ssrLoadModule(
                    "virtual:react-router/server-build"
                )
        })
    )
}

app.listen(3000, () => {
    console.log("App listening on http://localhost:3000")
})