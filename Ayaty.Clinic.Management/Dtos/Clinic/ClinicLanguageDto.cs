namespace Ayaty.Clinic.Management.Dtos.Clinic
{
    public class ClinicLanguageDto
    {
        public ClinicLanguageDto(){}

        public ClinicLanguageDto(ClinicLanguageDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Latitude = dto.Latitude;
            Longitude = dto.Longitude;
            Logo = dto.Logo;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Logo { get; set; }
    }
}