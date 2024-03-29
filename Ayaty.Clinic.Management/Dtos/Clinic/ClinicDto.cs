﻿using System;
using System.Collections.Generic;
using Ayaty.Clinic.Management.Dtos.ClinicComminicationWay;
using Ayaty.Clinic.Management.Enums;
using Ayaty.Shared.Attributes;

namespace Ayaty.Clinic.Management.Dtos.Clinic
{
    /// <summary>
    /// Dto used for add clinic or edit 
    /// </summary>
    public class ClinicDto
    {
        /// <summary>
        /// Id auto generated by system
        /// </summary>
        [AyatyRequired((int)ErrorCode.RequiredId)]
        [AyatyRange(0,Int32.MaxValue, (int)ErrorCode.IdRange0IntMax)]
        public int Id { get; set; }

        /// <summary>
        /// gis Latitude
        /// </summary>
        [AyatyRequired((int)ErrorCode.RequiredLatitude)]
        public decimal Latitude { get; set; }

        /// <summary>
        /// gis Longitude
        /// </summary>
        [AyatyRequired((int)ErrorCode.RequiredLongitude)]
        public decimal Longitude { get; set; }

        /// <summary>
        /// id of city
        /// sevice url "city/list"
        /// </summary>
        [AyatyRequired((int)ErrorCode.ClinicRequiredCityId)]
        [AyatyRange(0, Int32.MaxValue, (int)ErrorCode.ClinicCityIdRange0IntMax)]
        public int CityId { get; set; }

        /// <summary>
        /// Commincation ways of this Clinic
        /// </summary>
        [AyatyRequired((int)ErrorCode.RequiredComminicationWays)]
        public IEnumerable<ClinicComminicationWayDto> ClinicComminicationWays { get; set; }

        /// <summary>
        /// data of clinic in deferant languages
        /// </summary>
        [AyatyRequired((int)ErrorCode.RequiredClinicLanguages)]
        public IEnumerable<ClinicLanguage.ClinicLanguageDto> ClinicLanguages { get; set; }
    }

    
}