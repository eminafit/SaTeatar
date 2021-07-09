﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;


namespace SaTeatar.WebAPI.Services
{
    public interface IIzvodjenjaService : ICRUDService <mIzvodjenja,rIzvodjenjaSearch,rIzvodjenjaInsert,rIzvodjenjaUpdate>
    {
    }
}
