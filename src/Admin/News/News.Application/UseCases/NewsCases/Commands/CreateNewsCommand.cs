﻿using MediatR;
using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.UseCases.NewsCases.Commands
{
    public class CreateNewsCommand : IRequest<ResponseModel>
    {
        public string Category { get; set; }

        // mashi joyga rasm qoyadigan model qowiw kk.
        public string PostedDate { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
    }
}
