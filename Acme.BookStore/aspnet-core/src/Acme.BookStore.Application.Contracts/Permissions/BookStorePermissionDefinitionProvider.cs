using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookStorePermissions.GroupName);

            myGroup.AddPermission(BookStorePermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(BookStorePermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
            var authorsPermission = myGroup.AddPermission(BookStorePermissions.Authors.Default, L("Permission:Authors"));

            authorsPermission.AddChild( BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
            authorsPermission.AddChild( BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}