namespace clinicProject.Middlewares
{
    public class ClinicMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ClinicMiddleware> _logger;

        // הגדרת שעות הפעילות של הקליניקה (9:00-17:00)
        private readonly TimeSpan _clinicOpeningTime = new TimeSpan(9  , 0, 0); // 09:00
        private readonly TimeSpan _clinicClosingTime = new TimeSpan(22, 0, 0); // 22:00

        public ClinicMiddleware(RequestDelegate next, ILogger<ClinicMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // בודקים אם היום שבת
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("הגישה לאתר לא אפשרית בשבת");
                return;
            }

            // בודקים אם הזמן הנוכחי בתוך שעות הפעילות של הקליניקה
            var currentTime = DateTime.Now.TimeOfDay;

            if (currentTime < _clinicOpeningTime || currentTime > _clinicClosingTime)
            {
                // אם מחוץ לשעות הפעילות, מחזירים תשובה עם סטטוס 503 Service Unavailable
                context.Response.StatusCode = 503;
                await context.Response.WriteAsync("הקליניקה סגורה בשעות אלו.");
                //Console.WriteLine("הקליניקה סגורה בשעות אלו.");
                return;
            }

            // אם לא שבת ויש לנו גם זמן תקין, נמשיך לביצוע בקשת HTTP
            await _next(context);
        }
    }
}
