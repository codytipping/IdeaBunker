using Microsoft.AspNetCore.Authorization;

namespace IdeaBunker.Authorizations;

internal class PermissionPolicyProvider : IAuthorizationPolicyProvider
{
    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        return Task.FromResult(policy);
    }

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith("Permission", StringComparison.OrdinalIgnoreCase))
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new PermissionRequirement(policyName));
            return Task.FromResult(policy?.Build());
        }
        return Task.FromResult<AuthorizationPolicy?>(null);
    }

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy?>(null);
}