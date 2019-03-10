﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Abp.FeatureManagement.MongoDB
{
    [ConnectionStringName("FeatureManagement")]
    public interface IFeatureManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
