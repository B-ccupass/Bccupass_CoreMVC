﻿using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;
namespace Bccupass_CoreMVC.Repositories
{
    public class TicketRepository : DBRepository , ITicketRepository
    {
        public TicketRepository(BccupassDBContext context) : base(context)
        {

        }
    }
}
