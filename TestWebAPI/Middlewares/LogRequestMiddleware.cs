namespace TestWebAPI.Middlewares
{
    public class LogRequestMiddleware
    {
        #region Fields
        private RequestDelegate _next = null;
        private ILogger<LogRequestMiddleware> _logger = null;
        #endregion
        #region MyRegion

        #endregion Constructors
        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        #region Public Methods
        public async Task Invoke(HttpContext context)
        {
           this._logger.LogDebug(context.Request.Path.Value);
            
            await this._next(context);
        }
        #endregion
    }
}
