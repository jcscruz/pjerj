
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.Extensions.Options;
// using System.Net.Http.Headers;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.Extensions.Logging;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// public class BasicAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
// {
//     public BasicAuthentication(
//         IOptionsMonitor<AuthenticationSchemeOptions> options,
//         ILoggerFactory logger,
//         UrlEncoder encoder,
//         ISystemClock clock)
//         : base(options, logger, encoder, clock)
//     {
//     }

//     protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//     {
//         if (!Request.Headers.ContainsKey("Authorization"))
//             return AuthenticateResult.Fail("Missing Authorization Header");

//         try
//         {
//             var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//             var credentials = Encoding.UTF8
//                 .GetString(Convert.FromBase64String(authHeader.Parameter))
//                 .Split(':', 2);
//             var username = credentials[0];
//             var password = credentials[1];

//             // Aqui você pode validar as credenciais
//             if (username != "usuario" || password != "senha")
//             {
//                 return AuthenticateResult.Fail("Invalid Username or Password");
//             }

//             var claims = new[] {
//                 new Claim(ClaimTypes.NameIdentifier, username),
//                 new Claim(ClaimTypes.Name, username),
//             };
//             var identity = new ClaimsIdentity(claims, Scheme.Name);
//             var principal = new ClaimsPrincipal(identity);
//             var ticket = new AuthenticationTicket(principal, Scheme.Name);

//             return AuthenticateResult.Success(ticket);
//         }
//         catch
//         {
//             return AuthenticateResult.Fail("Invalid Authorization Header");
//         }
//     }
// }
