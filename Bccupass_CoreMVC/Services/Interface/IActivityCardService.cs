using Bccupass_CoreMVC.Models.DTO.Activity;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IActivityCardService
    {
        public IEnumerable<ActivityCardDto> GetLatestActivity();
       
    }
}
