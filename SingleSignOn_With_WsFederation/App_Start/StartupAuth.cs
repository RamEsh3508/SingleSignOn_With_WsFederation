using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;

namespace SingleSignOn_With_WsFederation
{
	public partial class Startup
	{
		#region Constants
		private const string strRealm = "https://MSAzure01.onmicrosoft.com/SingleSignOn_With_WsFederation";
		private const string strInstance = "https://login.microsoftonline.com";
		private const string strTenant = "MSAzure01.onmicrosoft.com";
		#endregion

		#region Fields
		private readonly string strMetadata = $"{strInstance}/{strTenant}/federationmetadata/2007-06/federationmetadata.xml";
		#endregion

		#region Publics
		public void ConfigureAuth(IAppBuilder app)
		{
			app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

			app.UseCookieAuthentication(new CookieAuthenticationOptions());

			app.UseWsFederationAuthentication
				(
				 new WsFederationAuthenticationOptions
				 {
					 Wtrealm = strRealm,
					 MetadataAddress = strMetadata
				 }
				);

			app.UseStageMarker(PipelineStage.Authenticate);
		}
		#endregion
	}
}