Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace ExtendedEvents.Module.BusinessObjects

    <DefaultClassOptions>
    Public Class ExtendedEvent
        Inherits [Event]

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Property CustomSimpleTypeField As String
            Get
                Return GetPropertyValue(Of String)(NameOf(ExtendedEvent.CustomSimpleTypeField))
            End Get

            Set(ByVal value As String)
                SetPropertyValue(NameOf(ExtendedEvent.CustomSimpleTypeField), value)
            End Set
        End Property

        Public Property CustomReferenceTypeField As CustomReferenceTypeField
            Get
                Return GetPropertyValue(Of CustomReferenceTypeField)(NameOf(ExtendedEvent.CustomReferenceTypeField))
            End Get

            Set(ByVal value As CustomReferenceTypeField)
                SetPropertyValue(NameOf(ExtendedEvent.CustomReferenceTypeField), value)
            End Set
        End Property
    End Class

    Public Class CustomReferenceTypeField
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Property Name As String
            Get
                Return GetPropertyValue(Of String)(NameOf(CustomReferenceTypeField.Name))
            End Get

            Set(ByVal value As String)
                SetPropertyValue(NameOf(CustomReferenceTypeField.Name), value)
            End Set
        End Property
    End Class
End Namespace
