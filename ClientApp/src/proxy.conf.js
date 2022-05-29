const PROXY_CONFIG = [
    {
        context: [
            "/api",
            "/many",
            "/endpoints",
            "/i",
            "/need",
            "/to",
            "/proxy"
        ],
        target: "http://localhost:7890",
        secure: false
    }
]

module.exports = PROXY_CONFIG;