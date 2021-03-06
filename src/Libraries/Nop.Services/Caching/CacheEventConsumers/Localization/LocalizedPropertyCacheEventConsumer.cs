﻿using Nop.Core.Domain.Localization;
using Nop.Services.Caching.CachingDefaults;

namespace Nop.Services.Caching.CacheEventConsumers.Localization
{
    /// <summary>
    /// Represents a localized property cache event consumer
    /// </summary>
    public partial class LocalizedPropertyCacheEventConsumer : CacheEventConsumer<LocalizedProperty>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(LocalizedProperty entity)
        {
            Remove(NopLocalizationCachingDefaults.LocalizedPropertyAllCacheKey);

            var cacheKey = NopLocalizationCachingDefaults.LocalizedPropertyCacheKey
                .FillCacheKey(entity.LanguageId, entity.EntityId, entity.LocaleKeyGroup, entity.LocaleKey);

            Remove(cacheKey);
        }
    }
}
