using System.Collections.Generic;
using Ayaty.Clinic.Management.Dtos.ClinicComminicationWay;
using Ayaty.Clinic.Management.Dtos.ClinicLanguage;

namespace Ayaty.Clinic.Management.Dtos.Clinic
{
    public class ClinicLanguageFullDto : ClinicLanguageDto
    {
        public ClinicLanguageFullDto()
        {
        }

        public ClinicLanguageFullDto(ClinicLanguageDto dto) : base(dto)
        {
        }

        public IEnumerable<ClinicComminicationWayDto> ClinicComminicationWays { get; set; }
        public IEnumerable<ClinicLanguage.ClinicLanguageDto> ClinicLanguages { get; set; }
    }
}