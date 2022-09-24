using FastFood.Models.Entities;
using System;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class BusinessRepository
    {
        public (BusinessInfo, string) GetBusinessInfo()
        {
            var BusinessInfos = new BusinessInfo();
            try
            {
                BusinessInfos.Name = "Fast Food Rapidito";
                BusinessInfos.Address = "ahi ahi jhsknbchlsjhs kshhdudokfklf loidnkdhhd kjdhflfgf khdd Av.jiidhfdkfojf Esq.jhfljfho";
                BusinessInfos.Phone1 = "809-111-1111";
                BusinessInfos.Phone2 = "829-222-2222";
                BusinessInfos.RNC = "8-222225-23";
                return (BusinessInfos, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (BusinessInfos, "Error al Cargar Data, Metodo BusinessRepository.GetBusinessInfo \n" + ex.Message.ToString());
            }
        }
    }
}
