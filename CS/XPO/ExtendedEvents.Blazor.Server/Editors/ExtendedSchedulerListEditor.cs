using DevExpress.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Scheduler.Blazor.Editors;
using ExtendedEvents.Module.BusinessObjects;

namespace ExtendedEvents.Blazor.Server.Editors;

[ListEditor(typeof(ExtendedEvent))]
public class ExtendedSchedulerListEditor : SchedulerListEditor {
    public ExtendedSchedulerListEditor(IModelListView model) : base(model) {
    }
    public override DxSchedulerDataStorage CreateSchedulerDataSource() {
        var dataSource = base.CreateSchedulerDataSource();
        dataSource.AppointmentMappings.CustomFieldMappings = new[] {
        new DxSchedulerCustomFieldMapping {
            Name = "SimpleField",
            Mapping = nameof(ExtendedEvent.CustomSimpleTypeField)
        },
        new DxSchedulerCustomFieldMapping {
            Name = "ReferenceField",
            Mapping = $"{nameof(ExtendedEvent.CustomReferenceTypeField)}.{nameof(CustomReferenceTypeField.Name)}"
        }
    };
        return dataSource;
    }
}
