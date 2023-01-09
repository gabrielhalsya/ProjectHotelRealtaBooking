Namespace Model
    Public Class Booking_orders
        Private _boorId As Integer
        Private _boor_order_number As String
        Private _boor_order_date As String
        Private _boor_arrival_date As String
        Private _boor_total_room As Integer
        Private _boor_total_guest As Integer
        Private _boor_discount As Decimal
        Private _boor_total_tax As Decimal
        Private _boor_total_amount As Double
        Private _boor_down_payment As Double
        Private _boor_pay_type As String
        Private _boor_is_paid As String
        Private _boor_type As String
        Private _boor_cardnumber As String
        Private _boor_member_type As String
        Private _boor_status As String
        Private _boor_user_id As Integer
        Private _boor_hotel_id As Integer

        Public Sub New()
        End Sub

        Public Sub New(boor_order_number As String, boor_order_date As String, boor_arrival_date As String, boor_total_room As Integer, boor_total_guest As Integer, boor_discount As Double, boor_total_tax As Decimal, boor_total_amount As Double, boor_down_payment As Double, boor_pay_type As String, boor_is_paid As String, boor_type As String, boor_cardnumber As String, boor_member_type As String, boor_status As String, boor_user_id As Integer, boor_hotel_id As Integer)
            Me.Boor_order_number = boor_order_number
            Me.Boor_order_date = boor_order_date
            Me.Boor_arrival_date = boor_arrival_date
            Me.Boor_total_room = boor_total_room
            Me.Boor_total_guest = boor_total_guest
            Me.Boor_discount = boor_discount
            Me.Boor_total_tax = boor_total_tax
            Me.Boor_total_amount = boor_total_amount
            Me.Boor_down_payment = boor_down_payment
            Me.Boor_pay_type = boor_pay_type
            Me.Boor_is_paid = boor_is_paid
            Me.Boor_type = boor_type
            Me.Boor_cardnumber = boor_cardnumber
            Me.Boor_member_type = boor_member_type
            Me.Boor_status = boor_status
            Me.Boor_user_id = boor_user_id
            Me.Boor_hotel_id = boor_hotel_id
        End Sub

        Public Sub New(boorId As Integer, boor_order_number As String,
                       boor_order_date As String, boor_arrival_date As String,
                       boor_total_room As Integer, boor_total_guest As Integer,
                       boor_discount As Double, boor_total_tax As Double, boor_total_amount As Double,
                       boor_down_payment As Double, boor_pay_type As String, boor_is_paid As String, boor_type As String,
                       boor_cardnumber As String, boor_member_type As String, boor_status As String,
                       boor_user_id As Integer, boor_hotel_id As Integer)
            Me.BoorId = boorId
            Me.Boor_order_number = boor_order_number
            Me.Boor_order_date = boor_order_date
            Me.Boor_arrival_date = boor_arrival_date
            Me.Boor_total_room = boor_total_room
            Me.Boor_total_guest = boor_total_guest
            Me.Boor_discount = boor_discount
            Me.Boor_total_tax = boor_total_tax
            Me.Boor_total_amount = boor_total_amount
            Me.Boor_down_payment = boor_down_payment
            Me.Boor_pay_type = boor_pay_type
            Me.Boor_is_paid = boor_is_paid
            Me.Boor_type = boor_type
            Me.Boor_cardnumber = boor_cardnumber
            Me.Boor_member_type = boor_member_type
            Me.Boor_status = boor_status
            Me.Boor_user_id = boor_user_id
            Me.Boor_hotel_id = boor_hotel_id
        End Sub

        Public Property BoorId As Integer
            Get
                Return _boorId
            End Get
            Set(value As Integer)
                _boorId = value
            End Set
        End Property

        Public Property Boor_order_number As String
            Get
                Return _boor_order_number
            End Get
            Set(value As String)
                _boor_order_number = value
            End Set
        End Property

        Public Property Boor_order_date As String
            Get
                Return _boor_order_date
            End Get
            Set(value As String)
                _boor_order_date = value
            End Set
        End Property

        Public Property Boor_arrival_date As String
            Get
                Return _boor_arrival_date
            End Get
            Set(value As String)
                _boor_arrival_date = value
            End Set
        End Property

        Public Property Boor_total_room As Integer
            Get
                Return _boor_total_room
            End Get
            Set(value As Integer)
                _boor_total_room = value
            End Set
        End Property

        Public Property Boor_total_guest As Integer
            Get
                Return _boor_total_guest
            End Get
            Set(value As Integer)
                _boor_total_guest = value
            End Set
        End Property

        Public Property Boor_discount As Decimal
            Get
                Return _boor_discount
            End Get
            Set(value As Decimal)
                _boor_discount = value
            End Set
        End Property

        Public Property Boor_total_tax As Decimal
            Get
                Return _boor_total_tax
            End Get
            Set(value As Decimal)
                _boor_total_tax = value
            End Set
        End Property

        Public Property Boor_total_amount As Double
            Get
                Return _boor_total_amount
            End Get
            Set(value As Double)
                _boor_total_amount = value
            End Set
        End Property

        Public Property Boor_down_payment As Double
            Get
                Return _boor_down_payment
            End Get
            Set(value As Double)
                _boor_down_payment = value
            End Set
        End Property

        Public Property Boor_pay_type As String
            Get
                Return _boor_pay_type
            End Get
            Set(value As String)
                _boor_pay_type = value
            End Set
        End Property

        Public Property Boor_is_paid As String
            Get
                Return _boor_is_paid
            End Get
            Set(value As String)
                _boor_is_paid = value
            End Set
        End Property

        Public Property Boor_type As String
            Get
                Return _boor_type
            End Get
            Set(value As String)
                _boor_type = value
            End Set
        End Property

        Public Property Boor_cardnumber As String
            Get
                Return _boor_cardnumber
            End Get
            Set(value As String)
                _boor_cardnumber = value
            End Set
        End Property

        Public Property Boor_member_type As String
            Get
                Return _boor_member_type
            End Get
            Set(value As String)
                _boor_member_type = value
            End Set
        End Property

        Public Property Boor_status As String
            Get
                Return _boor_status
            End Get
            Set(value As String)
                _boor_status = value
            End Set
        End Property

        Public Property Boor_user_id As Integer
            Get
                Return _boor_user_id
            End Get
            Set(value As Integer)
                _boor_user_id = value
            End Set
        End Property

        Public Property Boor_hotel_id As Integer
            Get
                Return _boor_hotel_id
            End Get
            Set(value As Integer)
                _boor_hotel_id = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim v As String = $"
Order ID        : {BoorId}
Order Number    : {Boor_order_number}
Order Date      : {Boor_order_date}
Arrival Date    : {Boor_arrival_date}
Total Room      : {Boor_total_room}
Total Guest     : {Boor_total_guest}
Discount        : {Boor_discount}
Total Tax       : {Boor_total_tax}
Total Amount    : {Boor_total_amount}
DP              : {Boor_down_payment}
Payment Type    : {Boor_pay_type}
Paid            : {Boor_is_paid}
Customer Type   : {Boor_type}
Cardnumber      : {Boor_cardnumber}
Member Type     : {Boor_member_type}
Order Status    : {Boor_status}
User ID         : {Boor_user_id}
Hotel ID        : {Boor_hotel_id}"
            Return v
        End Function
    End Class
End Namespace