﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.UseCases.NewsCases.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<string>>
    {

    }
}
