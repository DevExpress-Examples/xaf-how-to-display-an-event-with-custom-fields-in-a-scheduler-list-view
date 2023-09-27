using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Scheduler.Blazor.Editors;
using ExtendedEvents.Module.BusinessObjects;

namespace ExtendedEvents.Blazor.Server.Controllers; 
public class SchedulerCustomFieldMappingsController : ObjectViewController<ListView, ExtendedEvent> {
    protected override void OnViewControlsCreated() {
        base.OnViewControlsCreated();
        var schedulerAdapter = ((SchedulerListEditor)View.Editor).GetSchedulerAdapter();
        schedulerAdapter.SchedulerModel.DataStorage.AppointmentMappings.CustomFieldMappings = new[] {
            new DxSchedulerCustomFieldMapping {
                Name = "SimpleField",
                Mapping = nameof(ExtendedEvent.CustomSimpleTypeField)
            },
            new DxSchedulerCustomFieldMapping {
                Name = "ReferenceField",
                Mapping = $"{nameof(ExtendedEvent.CustomReferenceTypeField)}.{nameof(CustomReferenceTypeField.Name)}"
            }
        };

        schedulerAdapter.DayViewModel.VerticalAppointmentTemplate = CustomAppointmentTemplate.Create();
        schedulerAdapter.DayViewModel.HorizontalAppointmentTemplate = CustomAppointmentTemplate.Create();
    }
}
