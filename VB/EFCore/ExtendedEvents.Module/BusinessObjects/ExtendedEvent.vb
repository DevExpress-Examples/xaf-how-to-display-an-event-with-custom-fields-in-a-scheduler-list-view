Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl.EF

Namespace ExtendedEvents.Module.BusinessObjects

    <DefaultClassOptions>
    Public Class ExtendedEvent
        Inherits [Event]

        Public Overridable Property CustomSimpleTypeField As String

        Public Overridable Property CustomReferenceTypeField As CustomReferenceTypeField
    End Class

    Public Class CustomReferenceTypeField
        Inherits BaseObject

        Public Overridable Property Name As String
    End Class
End Namespace
