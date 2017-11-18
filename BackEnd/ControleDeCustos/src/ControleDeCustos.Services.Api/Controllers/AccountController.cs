using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeCustos.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCustos.Services.Api.Controllers
{

    public class AccountController : BaseController
    {
        public AccountController(IUser user) : base(user)
        {
        }
    }
}