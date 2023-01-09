Namespace Model

    Public Class Borde

        Private _borde_id As Integer
        Private _borde_boor_id As Integer
        Private _borde_checkin As String
        Private _borde_checkout As String
        Private _borde_adults As Integer
        Private _borde_kids As Integer
        Private _borde_price As Double
        Private _borde_extra As Double
        Private _borde_discount As Double
        Private _borde_tax As Double
        Private _borde_subtotal As Double
        Private _borde_faci_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(borde_boor_id As Integer, borde_checkin As String, borde_checkout As String, borde_adults As Integer, borde_kids As Integer, borde_price As Double, borde_extra As Double, borde_discount As Double, borde_tax As Double, borde_subtotal As Double, borde_faci_id As Integer)
            Me.Borde_boor_id = borde_boor_id
            Me.Borde_checkin = borde_checkin
            Me.Borde_checkout = borde_checkout
            Me.Borde_adults = borde_adults
            Me.Borde_kids = borde_kids
            Me.Borde_price = borde_price
            Me.Borde_extra = borde_extra
            Me.Borde_discount = borde_discount
            Me.Borde_tax = borde_tax
            Me.Borde_subtotal = borde_subtotal
            Me.Borde_faci_id = borde_faci_id
        End Sub

        Public Sub New(borde_id As Integer, borde_boor_id As Integer, borde_checkin As String, borde_checkout As String, borde_adults As Integer, borde_kids As Integer, borde_price As Double, borde_extra As Double, borde_discount As Double, borde_tax As Double, borde_subtotal As Double, borde_faci_id As Integer)
            Me.Borde_id = borde_id
            Me.Borde_boor_id = borde_boor_id
            Me.Borde_checkin = borde_checkin
            Me.Borde_checkout = borde_checkout
            Me.Borde_adults = borde_adults
            Me.Borde_kids = borde_kids
            Me.Borde_price = borde_price
            Me.Borde_extra = borde_extra
            Me.Borde_discount = borde_discount
            Me.Borde_tax = borde_tax
            Me.Borde_subtotal = borde_subtotal
            Me.Borde_faci_id = borde_faci_id
        End Sub

        Public Overrides Function ToString() As String
            Return $"
borde_id        : {Borde_id}
borde_boor_id   : {Borde_boor_id}
borde_checkin   : {Borde_checkin}
borde_checkout  : {Borde_checkout}
borde_adults    : {Borde_adults}
borde_kids      : {Borde_kids}
borde_price     : {Borde_price}
borde_extra     : {Borde_extra}
borde_discount  : {Borde_discount}
borde_tax       : {Borde_tax}
borde_subtotal  : {Borde_subtotal}
borde_faci_id   : {Borde_faci_id}
"

        End Function

        Public Property Borde_id As Integer
            Get
                Return _borde_id
            End Get
            Set(value As Integer)
                _borde_id = value
            End Set
        End Property

        Public Property Borde_boor_id As Integer
            Get
                Return _borde_boor_id
            End Get
            Set(value As Integer)
                _borde_boor_id = value
            End Set
        End Property

        Public Property Borde_checkin As String
            Get
                Return _borde_checkin
            End Get
            Set(value As String)
                _borde_checkin = value
            End Set
        End Property

        Public Property Borde_checkout As String
            Get
                Return _borde_checkout
            End Get
            Set(value As String)
                _borde_checkout = value
            End Set
        End Property

        Public Property Borde_adults As Integer
            Get
                Return _borde_adults
            End Get
            Set(value As Integer)
                _borde_adults = value
            End Set
        End Property

        Public Property Borde_kids As Integer
            Get
                Return _borde_kids
            End Get
            Set(value As Integer)
                _borde_kids = value
            End Set
        End Property

        Public Property Borde_price As Double
            Get
                Return _borde_price
            End Get
            Set(value As Double)
                _borde_price = value
            End Set
        End Property

        Public Property Borde_extra As Double
            Get
                Return _borde_extra
            End Get
            Set(value As Double)
                _borde_extra = value
            End Set
        End Property

        Public Property Borde_discount As Double
            Get
                Return _borde_discount
            End Get
            Set(value As Double)
                _borde_discount = value
            End Set
        End Property

        Public Property Borde_tax As Double
            Get
                Return _borde_tax
            End Get
            Set(value As Double)
                _borde_tax = value
            End Set
        End Property

        Public Property Borde_subtotal As Double
            Get
                Return _borde_subtotal
            End Get
            Set(value As Double)
                _borde_subtotal = value
            End Set
        End Property

        Public Property Borde_faci_id As Integer
            Get
                Return _borde_faci_id
            End Get
            Set(value As Integer)
                _borde_faci_id = value
            End Set
        End Property
    End Class

End Namespace