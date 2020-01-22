using Owin;

namespace SingleSignOn_With_WsFederation
{
	public partial class Startup
	{
		#region Publics
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
		#endregion
	}
}