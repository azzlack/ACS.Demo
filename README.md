ACS.Demo
=============================

Demo solution for showcasing logging onto a MVC site and protecting a WebAPI using Azure ACS.

### How to use ###

##### Set up Azure ACS #####
You need to set up an Access Control Namespace on Windows Azure. Please follow this guide: http://www.windowsazure.com/en-us/develop/net/how-to-guides/access-control/#create-namespace

##### Configure Azure ACS Indentity Providers #####
The Access Control Service currently supports authentication using Google, Yahoo, Facebook, Microsoft Account, [Windows Azure Active Directory](http://www.cloudidentity.com/blog/2012/11/07/provisioning-a-directory-tenant-as-an-identity-provider-in-an-acs-namespace), [custom Identity Providers](http://blogs.msdn.com/b/mcsuksoldev/archive/2012/11/02/azure-access-control-services-creating-a-custom-identity-provider.aspx) and ADFS 2.0. Read more about how to set up the different Identity Providers here: http://msdn.microsoft.com/en-us/library/windowsazure/gg185971.aspx

##### Add ACS configuration #####
Edit the `App_Start\SecurityConfig.cs` file and change the authentication configuration to suit your project.
