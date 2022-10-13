using Ekom.Services;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Ekom.U10.Services;

class SecurityService : ISecurityService
{
    readonly BackofficeUserAccessor _backofficeUserAccessor;
    readonly IUserService _userService;

    public SecurityService(BackofficeUserAccessor backofficeUserAccessor, IUserService userService)
    {
        _backofficeUserAccessor = backofficeUserAccessor;
        _userService = userService;
    }

    public IEnumerable<string> GetUmbracoUserGroups()
    {
        var userTicket = _backofficeUserAccessor.BackofficeUser;

        // ToDo: Does claim contain the groups ?

        if (userTicket.IsAuthenticated)
        {
            var u = _userService.GetByUsername(userTicket.GetUserName());

            return u?.Groups.Select(x => x.Alias) ?? Enumerable.Empty<string>();
        }

        return Enumerable.Empty<string>();
    }
}
