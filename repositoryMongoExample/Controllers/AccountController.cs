using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using repositoryMongoExample.JWT;
using repositoryMongoExample.Models;
using repositoryMongoExample.Responses;
using repositoryMongoExample.ViewModel;

namespace repositoryMongoExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public UserManager<ApplicationUser> _userManager { get; set; }
        public SignInManager<ApplicationUser> _signInManager { get; set; }
        public TokenManager _tokenManager { get; set; }


        public AccountController(UserManager<ApplicationUser> userManager,
            TokenManager tokenManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenManager = tokenManager;
            //var _userManager = provider.GetService<UserManager<ApplicationUser>>();

        }


        [HttpPost("register")]
        public async Task<BaseResponse> Register(Register userRegister)
        {
            try
            {
                var applicationUser = new ApplicationUser()
                {
                    Email = userRegister.Email,
                    PhoneNumber = userRegister.PhoneNumber,
                    UserName = userRegister.UserName,
                    Id = ObjectId.GenerateNewId().ToString(),
                };
                var user = await _userManager.CreateAsync(applicationUser,userRegister.Password);
                if (user.Succeeded)
                {
                    var userAfterRegiser = await _userManager.FindByEmailAsync(applicationUser.Email);
                    return new BaseResponse().Succeed("User Added with success", userAfterRegiser);
                }

                return new BaseResponse().Failed("0001", string.Join(' ', user.Errors.Select(x => x.Description).ToList()));

            }
            catch (Exception ex )
            {

                return new BaseResponse().Exeption(ex);
            }
        }

        [HttpPost("login")]
        public async Task<BaseResponse> Login(Login login)
        {
            try
            {
                
                var signIn = await _signInManager.PasswordSignInAsync(login.UserName, login.Password,true,false);
                if (signIn.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(login.UserName);
                    var token = _tokenManager.GenerateToken(user.Id);
                    var userInfo  = new UserInfo(){
                        token = token,
                        user = user
                    };
                    return new BaseResponse().Succeed("Login Success", userInfo);
                }

                return new BaseResponse().Failed("0001", "Wrong Login or password");

            }
            catch (Exception ex)
            {

                return new BaseResponse().Exeption(ex);
            }
        }


    }
}