using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace MoviesDbDotNetAngular.Server.Handlers
{
	public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		public BasicAuthenticationHandler
			(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder){ }

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			var endpoint = Context.GetEndpoint();
			if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
			{
				return AuthenticateResult.NoResult();
			}

			if (!Request.Headers.ContainsKey("Authorization"))
			{
				return AuthenticateResult.Fail("Missing authorization header");
			}

			try
			{
				var authHeader = Request.Headers["Authorization"].ToString();
				var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Substring("Basic ".Length))).Split(':');
				var username = credentials[0];
				var password = credentials[1];

				// Hardcoded user validation
				if (username == "userTest" && password == "plainPassword")
				{
					var claims = new[] { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, "Admin") };
					var identity = new ClaimsIdentity(claims, Scheme.Name);
					var principal = new ClaimsPrincipal(identity);
					var ticket = new AuthenticationTicket(principal, Scheme.Name);

					return AuthenticateResult.Success(ticket);
				}
				else
				{
					return AuthenticateResult.Fail("Invalid username or password");
				}
			}
			catch
			{
				return AuthenticateResult.Fail("Invalid authorization header");
			}
		}
	}
}
