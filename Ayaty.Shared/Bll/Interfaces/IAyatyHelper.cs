using System;
using System.Collections.Generic;
using Ayaty.Context.Interfaces;
using Ayaty.Shared.Dto;

namespace Ayaty.Shared.Bll.Interfaces
{
    public interface IAyatyHelper
    {
        /// <summary>
        /// validate count of language 
        /// validate ids of languages
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dtos"></param>
        /// <param name="errorCodeMissingLanguages"></param>
        /// <param name="errorCodeInvalidLanguage"></param>
        /// <returns></returns>
        BllResponse<TEntity> ValidateLanguageCount<TEntity>(IEnumerable<ILanguageId> dtos,
            Enum errorCodeMissingLanguages, Enum errorCodeInvalidLanguage);
    }
}