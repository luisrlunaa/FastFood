using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.Repositories
{
    public class BusinessRepository
    {
        public BusinessInfo GetBusinessInfo()
        {
            ///llenar con base de datos
            var BusinessInfos = new BusinessInfo();
            BusinessInfos.Name = "Fast Food Rapidito";
            BusinessInfos.Address = "ahi ahi jhsknbchlsjhs kshhdudokfklf loidnkdhhd kjdhflfgf khdd Av.jiidhfdkfojf Esq.jhfljfho";
            BusinessInfos.Phone1 = "809-111-1111";
            BusinessInfos.Phone2 = "829-222-2222";
            BusinessInfos.RNC = "8-222225-23";
            return BusinessInfos;
        }
    }
}
