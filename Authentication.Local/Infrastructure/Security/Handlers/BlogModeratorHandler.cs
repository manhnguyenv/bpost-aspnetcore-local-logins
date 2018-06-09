﻿namespace Authentication.Local.Infrastructure.Security
{
    using System.Threading.Tasks;
    using Authentication.Local.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.Options;

    public class BlogModeratorHandler : AuthorizationHandler<BlogAccessRequirement>
    {
        private readonly IOptions<Roles> _options;

        public BlogModeratorHandler(IOptions<Roles> options) => _options = options;

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            BlogAccessRequirement requirement)
        {
            if (context.User.IsInRole(_options.Value.Moderator))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
