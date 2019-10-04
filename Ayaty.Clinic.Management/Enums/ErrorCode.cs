namespace Ayaty.Clinic.Management.Enums
{
    public enum ErrorCode
    {
        ItemNotSaved=1,
        RequiredId = 2,
        IdRange0IntMax = 3,


        RequiredLatitude,
        RequiredLongitude,
        RequiredComminicationWays,
        RequiredClinicLanguages,
        ClinicMissingLanguages,
        ClientDuplicatename,
        ClinicInvalidLanguage,
        ClinicInvalidCommincationWay,
        ClinicRequiredCityId,
        ClinicCityIdRange0IntMax
    }

}