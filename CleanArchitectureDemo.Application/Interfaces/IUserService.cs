﻿using CleanArchitectureDemo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDemo.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetListUser();
    }
}
