﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.BlobStoring.Minio
{
    public class DefaultMinioBlobNameCalculator : IMinioBlobNameCalculator, ITransientDependency
    {
        protected ICurrentTenant CurrentTenant { get; }

        public DefaultMinioBlobNameCalculator(ICurrentTenant currentTenant)
        {
            CurrentTenant = currentTenant;
        }

        public virtual string Calculate(BlobProviderArgs args)
        {
            if (!args.Configuration.IsMultiTenant)
            {
                return args.BlobName;
            }

            return CurrentTenant.Id == null
                ? $"host/{args.BlobName}"
                : $"tenants/{CurrentTenant.Id.Value.ToString("D")}/{args.BlobName}";
        }
    }
}
