using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Scheduler.Win;
using DevExpress.XtraScheduler;
using ExtendedEvents.Module.BusinessObjects;

namespace ExtendedEvents.Win.Controllers;
public class SchedulerCustomFieldMappingsController : ObjectViewController<ListView, ExtendedEvent> {
    private SchedulerListEditor listEditor;

    protected override void OnViewControlsCreated() {
        base.OnViewControlsCreated();
        if (View.Editor is SchedulerListEditor listEditor) {
            listEditor.SchedulerControl.Storage.Appointments.CustomFieldMappings.AddRange(new[] {
            new AppointmentCustomFieldMapping("SimpleField", nameof(ExtendedEvent.CustomSimpleTypeField)),
            new AppointmentCustomFieldMapping("ReferenceField", nameof(ExtendedEvent.CustomReferenceTypeField))
        });

            SchedulerControl scheduler = listEditor.SchedulerControl;
            scheduler.InitAppointmentDisplayText -= scheduler_InitAppointmentDisplayText;
            scheduler.InitAppointmentDisplayText += scheduler_InitAppointmentDisplayText;
        }
    }
    protected override void OnDeactivated() {
        base.OnDeactivated();
        if (listEditor != null && listEditor.SchedulerControl != null) {
            SchedulerControl scheduler = listEditor.SchedulerControl;
            scheduler.InitAppointmentDisplayText -= scheduler_InitAppointmentDisplayText;
        }
    }
    private void scheduler_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e) {
        Appointment appointment = e.Appointment;
        if (appointment.IsRecurring)
            appointment = e.Appointment.RecurrencePattern;
        // Obtain source object if needed
        //ExtendedEvent obj = (ExtendedEvent)listEditor.SourceObjectHelper.GetSourceObject(appointment); 
        var referencePropertyValue = ((CustomReferenceTypeField)appointment.CustomFields["ReferenceField"])?.Name;
        e.Text = $"{appointment.CustomFields["SimpleField"]} - {referencePropertyValue}";
    }
}

