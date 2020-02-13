using Dolittle.Tenancy;
using Microsoft.AspNetCore.Builder;

namespace Core
{
    public static class DefaultTenantAppBuilderExtension
    {
        /// <summary>
        /// <para>
        /// If there is no tenant-header the application won't know which
        /// tenant to load resources (i.e. database connection-strings, etc)
        /// for.
        /// </para>
        /// <para>
        /// Ensures that at least the "unknown" tenant is set, or that the
        /// fallback tenant id provided is set.
        /// </para>
        /// <para>If a tenant id is set on the request this will no-op.</para>
        /// </summary>
        /// <param name="application">The application builder to modify</param>
        /// <param name="fallbackTenantId">
        /// The tenant to fall back to if none is set. If none is given the
        /// unknown tenant (762a4bd5-2ee8-4d33-af06-95806fb73f4e) will be set.
        /// </param>
        /// <returns>
        /// The application builder for further middleware chaingin
        /// </returns>
        public static IApplicationBuilder EnsureFallbackTenant(
            this IApplicationBuilder application,
            TenantId fallbackTenantId = null
        )
        {
            application
                .Use(
                    async (context, next) =>
                    {
                        if (!context.Request.Headers.ContainsKey("Tenant-Id"))
                        {
                            var fallback = fallbackTenantId ?? TenantId.Unknown;

                            context
                                .Request
                                .Headers
                                .Add(
                                    "Tenant-Id",
                                    $"{fallback}"
                                );
                        }
                        await next();
                    }
                );

            return application;
        }
    }
}