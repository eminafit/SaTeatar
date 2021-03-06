using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SaTeatar.Model.Models;
using SaTeatar.Services;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IKorisniciService _korisniciService;
        private readonly IKupciService _kupciService;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IKorisniciService korisniciService, IKupciService kupciService) 
            : base(options, logger, encoder, clock)
        {
            _korisniciService = korisniciService;
            _kupciService = kupciService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            mKorisnici user = null;
            mKupci kupac = null;

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
            var username = credentials[0];
            var password = credentials[1];

            user = await _korisniciService.Login(username, password);
            kupac = await _kupciService.Login(username, password);

            
                if (user!=null)
                {
                    //_korisniciService.SetTrenutniKorisnik(user);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.KorisnickoIme),
                        new Claim(ClaimTypes.Name, user.Ime),
                    };

                    foreach (var role in user.KorisniciUloges)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Uloga.Naziv));
                    }

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else if (kupac != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, kupac.KorisnickoIme),
                        new Claim(ClaimTypes.Name, kupac.Ime),
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Incorrect password or username");
                }


        }
    }
}
