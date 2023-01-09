Namespace Model

    Public Class Usbr
        Private _usbr_borde_id As Integer
        Private _usbr_modified_date As String
        Private _usbr_total_vacant As Integer

        Public Sub New()
        End Sub

        Public Sub New(usbr_borde_id As Integer, usbr_modified_date As String, usbr_total_vacant As Integer)
            Me.Usbr_borde_id = usbr_borde_id
            Me.Usbr_modified_date = usbr_modified_date
            Me.Usbr_total_vacant = usbr_total_vacant
        End Sub

        Public Overrides Function ToString() As String
            Return $"_usbr_borde_id      : {Usbr_borde_id}
_usbr_modified_date : {Usbr_modified_date}
_usbr_total_vacant  : {Usbr_total_vacant}"
        End Function

        Public Property Usbr_borde_id As Integer
            Get
                Return _usbr_borde_id
            End Get
            Set(value As Integer)
                _usbr_borde_id = value
            End Set
        End Property

        Public Property Usbr_modified_date As String
            Get
                Return _usbr_modified_date
            End Get
            Set(value As String)
                _usbr_modified_date = value
            End Set
        End Property

        Public Property Usbr_total_vacant As Integer
            Get
                Return _usbr_total_vacant
            End Get
            Set(value As Integer)
                _usbr_total_vacant = value
            End Set
        End Property
    End Class

End Namespace