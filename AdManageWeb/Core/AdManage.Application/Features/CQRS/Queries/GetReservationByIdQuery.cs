﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Queries
{
    public class GetReservationByIdQuery
    {
        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
