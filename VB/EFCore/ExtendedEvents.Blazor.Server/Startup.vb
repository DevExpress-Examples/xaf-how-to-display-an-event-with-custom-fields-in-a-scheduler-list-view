Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.ApplicationBuilder
Imports DevExpress.ExpressApp.Blazor.ApplicationBuilder
Imports DevExpress.ExpressApp.Blazor.Services
Imports DevExpress.Persistent.Base
Imports Microsoft.AspNetCore.Authentication.Cookies
Imports Microsoft.AspNetCore.Components.Server.Circuits
Imports Microsoft.EntityFrameworkCore
Imports ExtendedEvents.Blazor.Server.Services
Imports DevExpress.Persistent.BaseImpl.EF.PermissionPolicy

Namespace ExtendedEvents.Blazor.Server

    Public Class Startup

        Public Sub New(ByVal configuration As IConfiguration)
            Me.Configuration = configuration
        End Sub

        Public ReadOnly Property Configuration As IConfiguration

        ' This method gets called by the runtime. Use this method to add services to the container.
        ' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        Public Sub ConfigureServices(ByVal services As IServiceCollection)
            services.AddSingleton(GetType(Microsoft.AspNetCore.SignalR.HubConnectionHandler(Of )), GetType(ProxyHubConnectionHandler(Of )))
            services.AddRazorPages()
            services.AddServerSideBlazor()
            services.AddHttpContextAccessor()
            services.AddScoped(Of CircuitHandler, CircuitHandlerProxy)()
            services.AddXaf(Configuration, Function(builder)
                builder.UseApplication(Of ExtendedEventsBlazorApplication)()
                builder.Modules.AddConditionalAppearance().AddScheduler().AddValidation(Function(options)
                    options.AllowValidationDetailsAccess = False
                End Function).Add(Of ExtendedEvents.Module.ExtendedEventsModule)().Add(Of ExtendedEventsBlazorModule)()
                builder.ObjectSpaceProviders.AddSecuredEFCore(Function(options) options.PreFetchReferenceProperties()).WithDbContext(Of ExtendedEvents.Module.BusinessObjects.ExtendedEventsEFCoreDbContext)(Function(serviceProvider, options)
                    ' Uncomment this code to use an in-memory database. This database is recreated each time the server starts. With the in-memory database, you don't need to make a migration when the data model is changed.
                    ' Do not use this code in production environment to avoid data loss.
                    ' We recommend that you refer to the following help topic before you use an in-memory database: https://docs.microsoft.com/en-us/ef/core/testing/in-memory
                    'options.UseInMemoryDatabase("InMemory");
                    Dim connectionString As String = Nothing
                    If Configuration.GetConnectionString("ConnectionString") IsNot Nothing Then
                        connectionString = Configuration.GetConnectionString("ConnectionString")
                    End If

#If EASYTEST
                        if(Configuration.GetConnectionString("EasyTestConnectionString") != null) {
                            connectionString = Configuration.GetConnectionString("EasyTestConnectionString");
                        }
#End If
                    ArgumentNullException.ThrowIfNull(connectionString)
                    options.UseSqlServer(connectionString)
                    options.UseChangeTrackingProxies()
                    options.UseObjectSpaceLinkProxies()
                    options.UseXafServiceProviderContainer(serviceProvider)
                    options.UseLazyLoadingProxies()
                End Function).AddNonPersistent()
                builder.Security.UseIntegratedMode(Function(options)
                    options.RoleType = GetType(PermissionPolicyRole)
                    ' ApplicationUser descends from PermissionPolicyUser and supports the OAuth authentication. For more information, refer to the following topic: https://docs.devexpress.com/eXpressAppFramework/402197
                    ' If your application uses PermissionPolicyUser or a custom user type, set the UserType property as follows:
                    options.UserType = GetType(ExtendedEvents.Module.BusinessObjects.ApplicationUser)
                    ' ApplicationUserLoginInfo is only necessary for applications that use the ApplicationUser user type.
                    ' If you use PermissionPolicyUser or a custom user type, comment out the following line:
                    options.UserLoginInfoType = GetType(ExtendedEvents.Module.BusinessObjects.ApplicationUserLoginInfo)
                    options.Events.OnSecurityStrategyCreated += Function(securityStrategy)
                        ' Use the 'PermissionsReloadMode.NoCache' option to load the most recent permissions from the database once
                        ' for every DbContext instance when secured data is accessed through this instance for the first time.
                        ' Use the 'PermissionsReloadMode.CacheOnFirstAccess' option to reduce the number of database queries.
                        ' In this case, permission requests are loaded and cached when secured data is accessed for the first time
                        ' and used until the current user logs out. 
                        ' See the following article for more details: https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Security.SecurityStrategy.PermissionsReloadMode.
                        CType(securityStrategy, SecurityStrategy).PermissionsReloadMode = PermissionsReloadMode.NoCache
                    End Function
                End Function).AddPasswordAuthentication(Function(options)
                    options.IsSupportChangePassword = True
                End Function)
            End Function)
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Function(options)
                options.LoginPath = "/LoginPage"
            End Function)
        End Sub

        ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
            If env.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
            Else
                app.UseExceptionHandler("/Error")
                ' The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
                app.UseHsts()
            End If

            app.UseHttpsRedirection()
            app.UseRequestLocalization()
            app.UseStaticFiles()
            app.UseRouting()
            app.UseAuthentication()
            app.UseAuthorization()
            app.UseXaf()
            app.UseEndpoints(Function(endpoints)
                endpoints.MapXafEndpoints()
                endpoints.MapBlazorHub()
                endpoints.MapFallbackToPage("/_Host")
                endpoints.MapControllers()
            End Function)
        End Sub
    End Class
End Namespace
