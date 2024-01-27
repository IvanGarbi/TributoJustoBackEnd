﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TributoJusto.API.Extension;
using TributoJusto.API.ViewModels;
using System.Text.Json;

namespace TributoJusto.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager,
                      IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create the service.
            //using (HttpClient client = new HttpClient())
            //{

            //    string searchTerm = "Harry Potter";

            //    string apiKey = ""; // Substitua com sua chave de API do Google Books
            //    string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={searchTerm}&key={apiKey}";

            //    HttpResponseMessage response = await client.GetAsync(apiUrl);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        string result = await response.Content.ReadAsStringAsync();

            //        var responseObject = JsonSerializer.Deserialize<RootBookObject>(result);

            //        Console.WriteLine(result);
            //        // Aqui você pode processar os dados retornados conforme necessário
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
            //    }
            //}


            using (HttpClient client = new HttpClient())
            {

                string searchTerm = "Fast";

                string apiKey = ""; // Substitua com sua chave de API do Google Books
                string apiUrl = $"http://www.omdbapi.com/?i=tt3896198&apikey={apiKey}&t={searchTerm}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<RootMovieObject>(result);

                    Console.WriteLine(result);
                    // Aqui você pode processar os dados retornados conforme necessário
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }

        

            return Ok();
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistroViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = userRegisterViewModel.Email,
                Email = userRegisterViewModel.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegisterViewModel.Senha);

            if (result.Succeeded)
            {
                return CustomResponse("Usuário criado com sucesso");
            }

            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(usuarioLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }

        //public async Task<IActionResult> SignOut()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return CustomResponse("Logout com sucesso");
        //}

        #region MétodosPrivados

        private async Task<UsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await GetUserClaims(claims, user);
            var encodedToken = EncodeToken(identityClaims);

            return GetResponseToken(encodedToken, user, claims);
        }

        private UsuarioRespostaLogin GetResponseToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {
            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

        private async Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())); // quando token irá expirar
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)); // quando token foi emitido

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole)); // tratando roles e claims da mesma forma!!!
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string EncodeToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            });

            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        #endregion
    }
}


public class RootBookObject
{
    public Item[] items { get; set; }
}

public class Item
{
    public VolumeInfo volumeInfo { get; set; }
    public AccessInfo accessInfo { get; set; }
    public SaleInfo saleInfo { get; set; }
}

public class VolumeInfo
{
    public string title { get; set; }
    public string[] authors { get; set; }
    public string[] categories { get; set; }
    public string publisher { get; set; }
    public int pageCount { get; set; }
    public string description { get; set; }
}

public class AccessInfo
{
    public string country { get; set; }
}

public class SaleInfo
{
    public string country { get; set; }
    public RetailPrice retailPrice { get; set; }
    public string saleability { get; set; }
}

public class RetailPrice
{
    public decimal amount { get; set; }
    public string currencyCode { get; set; }
}











public class RootMovieObject
{
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Actors { get; set; }
    public string Plot { get; set; }
    public string Country { get; set; }
    public string imdbRating { get; set; }
    
}

