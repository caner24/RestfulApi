﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Dto
{
    public record GetProductByIdDto
    {
        public Guid Id { get; init; }
    }
}
