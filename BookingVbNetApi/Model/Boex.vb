Namespace Model

    Public Class Border
        Private _boex_id As Integer
        Private _boex_price As Double
        Private _boex_qty As Integer
        Private _boex_subtotal As Double
        Private _boex_measure_unit As String
        Private _boex_borde_id As Integer
        Private _boex_prit_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(boex_price As Double, boex_qty As Integer, boex_subtotal As Double, boex_measure_unit As String, boex_borde_id As Integer, boex_prit_id As Integer)
            Me.Boex_price = boex_price
            Me.Boex_qty = boex_qty
            Me.Boex_subtotal = boex_subtotal
            Me.Boex_measure_unit = boex_measure_unit
            Me.Boex_borde_id = boex_borde_id
            Me.Boex_prit_id = boex_prit_id
        End Sub

        Public Sub New(boex_id As Integer, boex_price As Double, boex_qty As Integer, boex_subtotal As Double, boex_measure_unit As String, boex_borde_id As Integer, boex_prit_id As Integer)
            Me.Boex_id = boex_id
            Me.Boex_price = boex_price
            Me.Boex_qty = boex_qty
            Me.Boex_subtotal = boex_subtotal
            Me.Boex_measure_unit = boex_measure_unit
            Me.Boex_borde_id = boex_borde_id
            Me.Boex_prit_id = boex_prit_id
        End Sub

        Public Overrides Function ToString() As String
            Return $"boex_id             : {Boex_id} 
boex_price          : {Boex_price}
boex_qty            : {Boex_qty}
boex_subtotal       : {Boex_subtotal}
boex_measure_unit   : {Boex_measure_unit}
boex_borde_id       : {Boex_borde_id}
boex_prit_id        : {Boex_prit_id}"
        End Function

        Public Property Boex_id As Integer
            Get
                Return _boex_id
            End Get
            Set(value As Integer)
                _boex_id = value
            End Set
        End Property

        Public Property Boex_price As Double
            Get
                Return _boex_price
            End Get
            Set(value As Double)
                _boex_price = value
            End Set
        End Property

        Public Property Boex_qty As Integer
            Get
                Return _boex_qty
            End Get
            Set(value As Integer)
                _boex_qty = value
            End Set
        End Property

        Public Property Boex_subtotal As Double
            Get
                Return _boex_subtotal
            End Get
            Set(value As Double)
                _boex_subtotal = value
            End Set
        End Property

        Public Property Boex_measure_unit As String
            Get
                Return _boex_measure_unit
            End Get
            Set(value As String)
                _boex_measure_unit = value
            End Set
        End Property

        Public Property Boex_borde_id As Integer
            Get
                Return _boex_borde_id
            End Get
            Set(value As Integer)
                _boex_borde_id = value
            End Set
        End Property

        Public Property Boex_prit_id As Integer
            Get
                Return _boex_prit_id
            End Get
            Set(value As Integer)
                _boex_prit_id = value
            End Set
        End Property
    End Class

End Namespace