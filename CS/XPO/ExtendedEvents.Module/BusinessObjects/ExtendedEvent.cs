using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedEvents.Module.BusinessObjects;
[DefaultClassOptions]
public class ExtendedEvent : Event {
    public ExtendedEvent(Session session) : base(session) {
    }
    public string CustomSimpleTypeField {
        get => GetPropertyValue<string>(nameof(CustomSimpleTypeField));
        set => SetPropertyValue(nameof(CustomSimpleTypeField), value);
    }
    public CustomReferenceTypeField CustomReferenceTypeField {
        get => GetPropertyValue<CustomReferenceTypeField>(nameof(CustomReferenceTypeField));
        set => SetPropertyValue(nameof(CustomReferenceTypeField), value);
    }
}
public class CustomReferenceTypeField : BaseObject {
    public CustomReferenceTypeField(Session session) : base(session) {
    }
    public string Name {
        get => GetPropertyValue<string>(nameof(Name));
        set => SetPropertyValue(nameof(Name), value);
    }
}
