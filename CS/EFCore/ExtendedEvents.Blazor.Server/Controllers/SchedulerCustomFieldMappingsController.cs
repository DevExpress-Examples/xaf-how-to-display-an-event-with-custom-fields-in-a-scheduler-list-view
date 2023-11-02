using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Scheduler.Blazor.Editors;
using ExtendedEvents.Module.BusinessObjects;

namespace ExtendedEvents.Blazor.Server.Controllers; 
public class SchedulerCustomFieldMappingsController : ObjectViewController<ListView, ExtendedEvent> {
    protected override void OnViewControlsCreated() {
        base.OnViewControlsCreated();
        var schedulerAdapter = ((SchedulerListEditor)View.Editor).GetSchedulerAdapter();
        schedulerAdapter.DayViewModel.VerticalAppointmentTemplate = CustomAppointmentTemplate.Create();
        schedulerAdapter.DayViewModel.HorizontalAppointmentTemplate = CustomAppointmentTemplate.Create();
    }
}
