namespace Ayaty.Setup.Enums
{
    public enum ErrorCode
    {
        ItemNotSaved,

        CountryNotFound,
        CountryMissingLanguages,
        CountryInvalidLanguage,
        CountryDuplicatename,
        CountryRelatedWithState,


        StateNotFound,
        StateMissingLanguages,
        StateInvalidLanguage,
        StateDuplicatename,
        StateCountryNotFound,
        StateRelatedWithCity,
        

        CityNotFound,
        CityDuplicatename,
        CityStateNotFound,
        CityMissingLanguages,
        CityInvalidLanguage,
        CityRelatedWithClinic
    }
}