﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Catalogo.API
{
    public class Autenticacao : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public Autenticacao(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = null;
            try
            {
                
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credenciais = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                username = credenciais.FirstOrDefault();
                var senha = credenciais.LastOrDefault();
                if (username != "teste@gmail.com" || senha != "1234")
                {
                    throw new ArgumentException("Senha ou Username errado");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Erro: {ex.Message}") ;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };
            var identidade = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identidade);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);

        }
    }
}
