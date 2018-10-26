using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoterDataService.Models.Services
{
    public partial interface ICampaignService
    {
        Campaign FindByCode(string code);
    }

    public partial class CampaignService : ICampaignService
    {
        public Campaign FindByCode(string code)
        {
            return repository.FirstOrDefault(c => c.Code == code);
        }
    }
}
