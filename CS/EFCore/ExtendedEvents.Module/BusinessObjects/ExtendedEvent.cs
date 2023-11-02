using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
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
    public virtual string CustomSimpleTypeField { get; set; }
    public virtual CustomReferenceTypeField CustomReferenceTypeField { get; set; }
}
public class CustomReferenceTypeField : BaseObject {
    public virtual string Name { get; set; }
}
