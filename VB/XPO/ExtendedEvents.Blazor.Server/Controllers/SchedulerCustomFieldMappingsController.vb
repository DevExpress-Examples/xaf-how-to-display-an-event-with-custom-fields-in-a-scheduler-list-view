Imports DevExpress.Blazor
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Scheduler.Blazor.Editors
Imports ExtendedEvents.Module.BusinessObjects

Namespace ExtendedEvents.Blazor.Server.Controllers

    Public Class SchedulerCustomFieldMappingsController
        Inherits ObjectViewController(Of ListView, ExtendedEvents.Module.BusinessObjects.ExtendedEvent)

        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            Dim schedulerAdapter = CType(View.Editor, SchedulerListEditor).GetSchedulerAdapter()
            schedulerAdapter.SchedulerModel.DataStorage.AppointmentMappings.CustomFieldMappings = {New DxSchedulerCustomFieldMapping With {.Name = "SimpleField", .Mapping = NameOf(ExtendedEvents.[Module].BusinessObjects.ExtendedEvent.CustomSimpleTypeField)}, New DxSchedulerCustomFieldMapping With {.Name = "ReferenceField", .Mapping = $"{NameOf(ExtendedEvents.[Module].BusinessObjects.ExtendedEvent.CustomReferenceTypeField)}.{NameOf(ExtendedEvents.[Module].BusinessObjects.CustomReferenceTypeField.Name)}"}}
            schedulerAdapter.DayViewModel.VerticalAppointmentTemplate = CustomAppointmentTemplate.Create()
            schedulerAdapter.DayViewModel.HorizontalAppointmentTemplate = CustomAppointmentTemplate.Create()
        End Sub
    End Class
End Namespace
