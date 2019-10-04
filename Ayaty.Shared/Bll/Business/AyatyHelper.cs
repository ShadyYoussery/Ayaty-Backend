using System;
using System.Collections.Generic;
using System.Linq;
using Ayaty.Context.Enums;
using Ayaty.Context.Interfaces;
using Ayaty.Shared.Bll.Interfaces;
using Ayaty.Shared.Dto;

namespace Ayaty.Shared.Bll.Business
{
    public class AyatyHelperManagement : IAyatyHelper
    {
        #region Feilds



        #endregion Feilds

        #region Ctor

        public AyatyHelperManagement()
        {
        }

        #endregion Ctor

        #region Public Methods

        public BllResponse<TEntity> ValidateLanguageCount<TEntity>(IEnumerable<ILanguageId> dtos, Enum errorCodeMissingLanguages,
            Enum errorCodeInvalidLanguage)
        {
            var languageIds = (int[])Enum.GetValues(typeof(LanguageEnum));
            if (dtos.Count() != languageIds.Length)
                return new BllResponse<TEntity>(errorCodeMissingLanguages);
            if (dtos.Any(t => !languageIds.Contains(t.LanguageId)))
                return new BllResponse<TEntity>(errorCodeInvalidLanguage);
            return null;
        }

        #endregion Public Methods

        #region private Methods



        #endregion private Methods



    }
}