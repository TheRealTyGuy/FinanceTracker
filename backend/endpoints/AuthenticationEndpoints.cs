// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Authentication.Google;

// namespace Endpoints
// {
//     public static class AuthenticationEndpoints
//     {
//         public static void AddAuthenticationEndpoints(this WebApplication app)
//         {
//             app.MapGet("/login/google", RequestLogin);
//             app.MapGet("/login/google/callback", HandleLogin);
//             app.MapGet("/logout", RequestLogout);
//         }

//         public static IResult RequestLogin(HttpContext context)
//         {
//             var properties = new AuthenticationProperties
//             {
//                 RedirectUri = "/"
//             };

//             return Results.Challenge(
//                 properties,
//                 new[] { GoogleDefaults.AuthenticationScheme });
//         }

//         public static IResult HandleLogin(HttpContext context)
//         {
//             if(!context.User.Identity.IsAuthenticated ?? true)
//             {
//                 return Results.Redirect("/login/google");
//             }

//             return Results.Redirect("/");
//         }

//         public static async Task RequestLogout(HttpContext context)
//         {
//             await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//             context.Response.Redirect("/");
//         }
//     }
// }