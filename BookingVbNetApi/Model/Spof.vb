Namespace Model

    Public Class Spof
        Private _spof_id As Integer
        Private _spof_name As String
        Private _spof_description As String
        Private _spof_type As String
        Private _spof_discount As Double
        Private _spof_start_date As String
        Private _spof_end_date As String
        Private _spof_min_qty As Integer
        Private _spof_max_qty As Integer
        Private _spof_modified_date As String

        Public Sub New()
        End Sub

        Public Sub New(spof_name As String, spof_description As String, spof_type As String, spof_discount As Double, spof_start_date As String, spof_end_date As String, spof_min_qty As Integer, spof_max_qty As Integer, spof_modified_date As String)
            Me.Spof_name = spof_name
            Me.Spof_description = spof_description
            Me.Spof_type = spof_type
            Me.Spof_discount = spof_discount
            Me.Spof_start_date = spof_start_date
            Me.Spof_end_date = spof_end_date
            Me.Spof_min_qty = spof_min_qty
            Me.Spof_max_qty = spof_max_qty
            Me.Spof_modified_date = spof_modified_date
        End Sub

        Public Sub New(spof_id As Integer, spof_name As String, spof_description As String, spof_type As String, spof_discount As Double, spof_start_date As String, spof_end_date As String, spof_min_qty As Integer, spof_max_qty As Integer, spof_modified_date As String)
            Me.Spof_id = spof_id
            Me.Spof_name = spof_name
            Me.Spof_description = spof_description
            Me.Spof_type = spof_type
            Me.Spof_discount = spof_discount
            Me.Spof_start_date = spof_start_date
            Me.Spof_end_date = spof_end_date
            Me.Spof_min_qty = spof_min_qty
            Me.Spof_max_qty = spof_max_qty
            Me.Spof_modified_date = spof_modified_date
        End Sub

        Public Overrides Function ToString() As String
            Return $" _spof_id               : {Spof_id} 
 _spof_name             : {Spof_name} 
 _spof_description      : {Spof_description}
 _spof_type             : {Spof_type}
 _spof_discount         : {Spof_discount} 
 _spof_start_date       : {Spof_start_date} 
 _spof_end_date         : {Spof_end_date}
 _spof_min_qty          : {Spof_min_qty}
 _spof_max_qty          : {Spof_max_qty}
 _spof_modified_date    : {Spof_modified_date}"
        End Function

        Public Property Spof_id As Integer
            Get
                Return _spof_id
            End Get
            Set(value As Integer)
                _spof_id = value
            End Set
        End Property

        Public Property Spof_name As String
            Get
                Return _spof_name
            End Get
            Set(value As String)
                _spof_name = value
            End Set
        End Property

        Public Property Spof_description As String
            Get
                Return _spof_description
            End Get
            Set(value As String)
                _spof_description = value
            End Set
        End Property

        Public Property Spof_type As String
            Get
                Return _spof_type
            End Get
            Set(value As String)
                _spof_type = value
            End Set
        End Property

        Public Property Spof_discount As Double
            Get
                Return _spof_discount
            End Get
            Set(value As Double)
                _spof_discount = value
            End Set
        End Property

        Public Property Spof_start_date As String
            Get
                Return _spof_start_date
            End Get
            Set(value As String)
                _spof_start_date = value
            End Set
        End Property

        Public Property Spof_end_date As String
            Get
                Return _spof_end_date
            End Get
            Set(value As String)
                _spof_end_date = value
            End Set
        End Property

        Public Property Spof_min_qty As Integer
            Get
                Return _spof_min_qty
            End Get
            Set(value As Integer)
                _spof_min_qty = value
            End Set
        End Property

        Public Property Spof_max_qty As Integer
            Get
                Return _spof_max_qty
            End Get
            Set(value As Integer)
                _spof_max_qty = value
            End Set
        End Property

        Public Property Spof_modified_date As String
            Get
                Return _spof_modified_date
            End Get
            Set(value As String)
                _spof_modified_date = value
            End Set
        End Property
    End Class

End Namespace