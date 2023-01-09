Namespace Model

    Public Class Soco
        Private _soco_id As Integer
        Private _soco_borde_id As Integer
        Private _soco_spof_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(soco_borde_id As Integer, soco_spof_id As Integer)
            Me.Soco_borde_id = soco_borde_id
            Me.Soco_spof_id = soco_spof_id
        End Sub

        Public Sub New(soco_id As Integer, soco_borde_id As Integer, soco_spof_id As Integer)
            Me.Soco_id = soco_id
            Me.Soco_borde_id = soco_borde_id
            Me.Soco_spof_id = soco_spof_id
        End Sub

        Public Overrides Function ToString() As String
            Return $" _soco_id       : {Soco_id} 
 _soco_borde_id : {Soco_borde_id}
 _soco_spof_id  : {Soco_spof_id}"
        End Function

        Public Property Soco_id As Integer
            Get
                Return _soco_id
            End Get
            Set(value As Integer)
                _soco_id = value
            End Set
        End Property

        Public Property Soco_borde_id As Integer
            Get
                Return _soco_borde_id
            End Get
            Set(value As Integer)
                _soco_borde_id = value
            End Set
        End Property

        Public Property Soco_spof_id As Integer
            Get
                Return _soco_spof_id
            End Get
            Set(value As Integer)
                _soco_spof_id = value
            End Set
        End Property
    End Class

End Namespace