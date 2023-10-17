<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/697301496/23.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1192313)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# XAF - How to Display an Event with Custom Fields in a Scheduler List View

This example demonstrates how to extend an event with custom fields and display them in Scheduler.

**ASP.NET Core Blazor**  

![|](xaf-blazor-extended-event-with-custom-fields-devexpress.png)

**Windows Forms**  

![](xaf-winforms-extended-event-with-custom-fields-devexpress.png)

1. Inherit from the `Event` class and implement new properties. For details, see the following file: [ExtendedEvent.cs](./CS/EFCore/ExtendedEvents.Module/BusinessObjects/ExtendedEvent.cs).
2. Map the new properties to the appropriate data fields.  
   
   In an ASP.NET Core Blazor application, create a `SchedulerListEditor` descendant and specify `CustomFieldMappings`. For details, see the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Blazor.Server/Controllers/SchedulerCustomFieldMappingsController.cs).  

   In a Windows Forms application, specify `CustomFieldMappings`. For details, see the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Win/Controllers/SchedulerCustomFieldMappingsController.cs).
4. Display the fields in the event card in Scheduler List View.

   In an XAF ASP.NET Core Blazor application:
   - Create a Razor component. For implementation details, refer to the following file: [CustomAppointmentTemplate.razor](./CS/EFCore/ExtendedEvents.Blazor.Server/CustomAppointmentTemplate.razor).
   - Specify the `VerticalAppointmentTemplate` and `HorizontalAppointmentTemplate` properties of the Scheduler View. For implementation details, refer to the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Blazor.Server/Controllers/SchedulerCustomFieldMappingsController.cs).

   In an XAF Windows Forms application:
   - Handle the `InitAppointmentDisplayText` event. For implementation details, refer to the following file: [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Win/Controllers/SchedulerCustomFieldMappingsController.cs).

## Files to Review

- [ExtendedEvent.cs](./CS/EFCore/ExtendedEvents.Module/BusinessObjects/ExtendedEvent.cs)
- [CustomAppointmentTemplate.razor](./CS/EFCore/ExtendedEvents.Blazor.Server/CustomAppointmentTemplate.razor) (ASP.NET Core Blazor)
- [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Blazor.Server/Controllers/SchedulerCustomFieldMappingsController.cs) (ASP.NET Core Blazor)
- [SchedulerCustomFieldMappingsController.cs](./CS/EFCore/ExtendedEvents.Win/Controllers/SchedulerCustomFieldMappingsController.cs) (Windows Forms)
