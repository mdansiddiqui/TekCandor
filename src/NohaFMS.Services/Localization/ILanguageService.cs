/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;

namespace NohaFMS.Services
{
    /// <summary>
    /// Language service interface
    /// </summary>
    public partial interface ILanguageService : IBaseService
    {
        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="language">Language</param>
        void DeleteLanguage(Language language);

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <returns>Languages</returns>
        IList<Language> GetAllLanguages();

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Language</returns>
        Language GetLanguageById(long languageId);

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="language">Language</param>
        void InsertLanguage(Language language);

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="language">Language</param>
        void UpdateLanguage(Language language);

        IEnumerable<Language> GetLanguages(string expression,
            dynamic parameters,
            int pageIndex = 0, 
            int pageSize = 2147483647, 
            IEnumerable<Sort> sort = null); //Int32.MaxValue
    }
}
