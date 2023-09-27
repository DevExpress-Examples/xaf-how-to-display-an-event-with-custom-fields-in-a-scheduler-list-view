Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Design
Imports DevExpress.Persistent.BaseImpl.EF.PermissionPolicy
Imports DevExpress.Persistent.BaseImpl.EF
Imports DevExpress.ExpressApp.Design
Imports DevExpress.ExpressApp.EFCore.DesignTime

Namespace ExtendedEvents.Module.BusinessObjects

    ' This code allows our Model Editor to get relevant EF Core metadata at design time.
    ' For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
    Public Class ExtendedEventsContextInitializer
        Inherits DbContextTypesInfoInitializerBase

        Protected Overrides Function CreateDbContext() As DbContext
            Dim optionsBuilder = New DbContextOptionsBuilder(Of ExtendedEventsEFCoreDbContext)().UseSqlServer(";").UseChangeTrackingProxies().UseObjectSpaceLinkProxies()
            Return New ExtendedEventsEFCoreDbContext(optionsBuilder.Options)
        End Function
    End Class

    'This factory creates DbContext for design-time services. For example, it is required for database migration.
    Public Class ExtendedEventsDesignTimeDbContextFactory
        Implements IDesignTimeDbContextFactory(Of ExtendedEventsEFCoreDbContext)

        Public Function CreateDbContext(ByVal args As String()) As ExtendedEventsEFCoreDbContext Implements IDesignTimeDbContextFactory(Of ExtendedEventsEFCoreDbContext).CreateDbContext
            Throw New InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.")
        'var optionsBuilder = new DbContextOptionsBuilder<ExtendedEventsEFCoreDbContext>();
        'optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExtendedEvents");
        'optionsBuilder.UseChangeTrackingProxies();
        'optionsBuilder.UseObjectSpaceLinkProxies();
        'return new ExtendedEventsEFCoreDbContext(optionsBuilder.Options);
        End Function
    End Class

    <TypesInfoInitializer(GetType(ExtendedEventsContextInitializer))>
    Public Class ExtendedEventsEFCoreDbContext
        Inherits DbContext

        Public Sub New(ByVal options As DbContextOptions(Of ExtendedEventsEFCoreDbContext))
            MyBase.New(options)
        End Sub

        'public DbSet<ModuleInfo> ModulesInfo { get; set; }
        Public Property ModelDifferences As DbSet(Of ModelDifference)

        Public Property ModelDifferenceAspects As DbSet(Of ModelDifferenceAspect)

        Public Property Roles As DbSet(Of PermissionPolicyRole)

        Public Property Users As DbSet(Of ApplicationUser)

        Public Property UserLoginInfos As DbSet(Of ApplicationUserLoginInfo)

        'public DbSet<Event> Event { get; set; }
        Public Property ExtendedEvents As DbSet(Of ExtendedEvent)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues)
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
            modelBuilder.Entity(Of ApplicationUserLoginInfo)(Sub(b) b.HasIndex(NameOf(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), NameOf(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique())
            modelBuilder.Entity(Of ModelDifference)().HasMany(Function(t) t.Aspects).WithOne(Function(t) t.Owner).OnDelete(DeleteBehavior.Cascade)
        End Sub
    End Class
End Namespace
