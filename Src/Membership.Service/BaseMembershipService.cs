using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Membership.Data;
using Membership.Contract;
using AutoMapper;
using Membership.Data.Entity;

namespace Membership.Service
{
    public class BaseMembershipService
    {
        protected MembershipDB db = new MembershipDB();

        public BaseMembershipService()
        {
            AutoMapperConfiguration.CreateMaps();
        }
        
    }
}
