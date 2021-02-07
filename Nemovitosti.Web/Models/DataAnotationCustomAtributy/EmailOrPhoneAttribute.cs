﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemovitosti.Web.Models.DataAnotationCustomAtributy
{
    public class EmailOrPhoneAttribute : RegularExpressionAttribute
    {
        public EmailOrPhoneAttribute() : base(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}")
        {
            ErrorMessage = "Tento tvar Emailu není správný";
        }

    }
}