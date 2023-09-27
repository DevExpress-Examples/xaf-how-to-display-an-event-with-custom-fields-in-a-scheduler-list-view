Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Persistent.BaseImpl

Namespace ExtendedEvents.Win

    <ToolboxItemFilter("Xaf.Platform.Win")>
    ' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    Public NotInheritable Class ExtendedEventsWinModule
        Inherits ModuleBase

        'private void Application_CreateCustomModelDifferenceStore(object sender, CreateCustomModelDifferenceStoreEventArgs e) {
        '    e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Win");
        '    e.Handled = true;
        '}
        Private Sub Application_CreateCustomUserModelDifferenceStore(ByVal sender As Object, ByVal e As CreateCustomModelDifferenceStoreEventArgs)
            e.Store = New ModelDifferenceDbStore(CType(sender, XafApplication), GetType(ModelDifference), False, "Win")
            e.Handled = True
        End Sub

        Public Sub New()
            FormattingProvider.UseMaskSettings = True
        End Sub

        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Return ModuleUpdater.EmptyModuleUpdaters
        End Function

        Public Overrides Sub Setup(ByVal application As XafApplication)
            MyBase.Setup(application)
            'application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
            application.CreateCustomUserModelDifferenceStore += AddressOf Application_CreateCustomUserModelDifferenceStore
        End Sub
    End Class
End Namespace