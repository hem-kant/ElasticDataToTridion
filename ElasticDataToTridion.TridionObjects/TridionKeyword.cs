﻿using CoreServiceFramework.CoreServiceFramework;
using System;
using Tridion.ContentManager.CoreService.Client;

namespace ElasticDataToTridion.TridionObjects
{
    public class TridionKeyword
    {


        #region Generate new Keyword
        /// <summary>
        /// Create Keyword using KeywordData class
        /// </summary>
        /// <param name="coreService"></param>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static string GenerateKeyword(ICoreServiceFrameworkContext coreService, string value, string key, string CategoryID)
        {
            try
            {
                KeywordData keyword = (KeywordData)coreService.Client.GetDefaultData(ItemType.Keyword, CategoryID, new ReadOptions());
                keyword.Id = "tcm:0-0-0";
                keyword.Title = value;
                keyword.Key = key;

                keyword = (KeywordData)coreService.Client.Create(keyword, new ReadOptions());

                return keyword.Id.ToString();
            }
            catch (Exception ex)
            {

                return "";
            }

        }
        #endregion
    }
}
