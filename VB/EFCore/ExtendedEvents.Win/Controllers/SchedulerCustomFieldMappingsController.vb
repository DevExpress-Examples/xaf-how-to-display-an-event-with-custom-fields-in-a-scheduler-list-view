Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Scheduler.Win
Imports DevExpress.XtraScheduler
Imports ExtendedEvents.Module.BusinessObjects

Namespace ExtendedEvents.Win.Controllers

    Public Class SchedulerCustomFieldMappingsController
        Inherits ObjectViewController(Of ListView, ExtendedEvents.Module.BusinessObjects.ExtendedEvent)

        Private listEditor As SchedulerListEditor

        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            listEditor = TryCast(View.Editor, SchedulerListEditor)
            listEditor.SchedulerControl.Storage.Appointments.CustomFieldMappings.AddRange({New AppointmentCustomFieldMapping("SimpleField", NameOf(ExtendedEvents.[Module].BusinessObjects.ExtendedEvent.CustomSimpleTypeField)), New AppointmentCustomFieldMapping("ReferenceField", NameOf(ExtendedEvents.[Module].BusinessObjects.ExtendedEvent.CustomReferenceTypeField))})
            Dim scheduler As SchedulerControl = listEditor.SchedulerControl
            RemoveHandler scheduler.InitAppointmentDisplayText, AddressOf scheduler_InitAppointmentDisplayText
            AddHandler scheduler.InitAppointmentDisplayText, AddressOf scheduler_InitAppointmentDisplayText
        End Sub

        Protected Overrides Sub OnDeactivated()
            MyBase.OnDeactivated()
            If listEditor IsNot Nothing AndAlso listEditor.SchedulerControl IsNot Nothing Then
                Dim scheduler As SchedulerControl = listEditor.SchedulerControl
                RemoveHandler scheduler.InitAppointmentDisplayText, AddressOf scheduler_InitAppointmentDisplayText
            End If
        End Sub

        Private Sub scheduler_InitAppointmentDisplayText(ByVal sender As Object, ByVal e As AppointmentDisplayTextEventArgs)
            Dim appointment As Appointment = e.Appointment
            If appointment.IsRecurring Then appointment = e.Appointment.RecurrencePattern
            ' obtain source object if needed
            'ExtendedEvent obj = (ExtendedEvent)listEditor.SourceObjectHelper.GetSourceObject(appointment); 
            Dim referencePropertyValue = CType(appointment.CustomFields("ReferenceField"), ExtendedEvents.[Module].BusinessObjects.CustomReferenceTypeField)?.Name
            e.Text = $"{appointment.CustomFields("SimpleField")} - {referencePropertyValue}"
        End Sub
    End Class
End Namespace
