﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectUser.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public FooterViewComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
