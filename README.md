<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/697301496/23.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1192313)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# XAF - How to Display an Event with Custom Fields in a Scheduler List View

This example demonstrates how to extend Scheduler events with custom fields and display these values in UI.

**ASP.NET Core Blazor**  

![|](xaf-blazor-extended-event-with-custom-fields-devexpress.png)

**Windows Forms**  

![](xaf-winforms-extended-event-with-custom-fields-devexpress.png)

1. Inherit from the `Event` class and implement new properties. For details, see the following file: [ExtendedEvent.cs](./CS/EFCore/ExtendedEvents.Module/BusinessObjects/ExtendedEvent.cs).
2. Map new properties to appropriate data fields.  
   
   In an ASP.NET Core Blazor application, create a `SchedulerListEditor` descendant and specify `CustomFieldMappings`. For details, see the following file: [ExtendedSchedulerListEditor.cs](./CS/EFCore/ExtendedEvents.Blazor.Server/Editors/ExtendedSchedulerListEditor.cs).  

   In a Windows Forms application, specify `CustomFieldMappings`. For details, see the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Win/Controllers/SchedulerCustomFieldMappingsController.cs).
4. Display field values in event cards of a Scheduler List View.

   In an XAF ASP.NET Core Blazor application:
   - Create a Razor component. For implementation details, refer to the following file: [CustomAppointmentTemplate.razor](./CS/EFCore/ExtendedEvents.Blazor.Server/CustomAppointmentTemplate.razor).
   - Specify `VerticalAppointmentTemplate` and `HorizontalAppointmentTemplate` properties of the Scheduler View. For implementation details, refer to the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Blazor.Server/Controllers/SchedulerCustomFieldMappingsController.cs).

   In an XAF Windows Forms application:
   - Handle the `InitAppointmentDisplayText` event. For implementation details, refer to the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Win/Controllers/SchedulerCustomFieldMappingsController.cs).

## Files to Review

- [ExtendedEvent.cs](./CS/EFCore/ExtendedEvents.Module/BusinessObjects/ExtendedEvent.cs)
- [CustomAppointmentTemplate.razor](./CS/EFCore/ExtendedEvents.Blazor.Server/CustomAppointmentTemplate.razor) (ASP.NET Core Blazor)
- [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Blazor.Server/Controllers/SchedulerCustomFieldMappingsController.cs) (ASP.NET Core Blazor)
- [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Win/Controllers/SchedulerCustomFieldMappingsController.cs) (Windows Forms)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-display-an-event-with-custom-fields-in-a-scheduler-list-view&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-display-an-event-with-custom-fields-in-a-scheduler-list-view&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
