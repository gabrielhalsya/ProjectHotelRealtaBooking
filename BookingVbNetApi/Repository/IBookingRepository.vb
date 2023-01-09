Imports BookingVbNetApi.Model
Namespace Repository
    Public Interface IBookingRepository
        Function FindAllBookingOrders() As List(Of Booking_orders)

        Function FindOrderById(ByVal id As Int32) As Booking_orders

        Function CreateNewOrder(bookingOrders As Booking_orders) As Booking_orders

        Function DeleteRegion(ByVal id As Int32) As Int32

        Function UpdateBookingById(id As Integer,
                                          orderDateValue As String,
                                          arrivalDateValue As String,
                                          totalRoomvalue As Integer,
                                          totalGuestValue As Integer,
                                          discountValue As Decimal,
                                          totalTaxValue As Decimal,
                                          totalAmountValue As Double,
                                          DpValue As Integer,
                                          payTypeValue As String,
                                          isPaidValue As String,
                                          orderTypeValue As String,
                                          cardnumberValue As Integer,
                                          memberTypeValue As String,
                                          statusValue As String,
                                          userIdValue As Integer,
                                          hotelIdValue As Integer,
                                   Optional showCommand As Boolean = False) As Boolean
        Function UpdateBookingBySp(id As Integer,
                                         Optional orderNumberValue As String = "",
                                          Optional orderDateValue As String = "",
                                          Optional arrivalDateValue As String = "",
                                          Optional totalRoomvalue As Integer = 0,
                                          Optional totalGuestValue As Integer = 0,
                                          Optional discountValue As Decimal = 0.0,
                                          Optional totalTaxValue As Decimal = 0.11,
                                          Optional totalAmountValue As Double = 0,
                                          Optional DpValue As Double = 0,
                                          Optional payTypeValue As String = "",
                                          Optional isPaidValue As String = "",
                                          Optional orderTypeValue As String = "",
                                          Optional cardnumberValue As String = "",
                                          Optional memberTypeValue As String = "",
                                          Optional statusValue As String = "",
                                          Optional userIdValue As Integer = 0,
                                          Optional hotelIdValue As Integer = 0,
                                   Optional showCommand As Boolean = False) As Booking_orders

    End Interface
End Namespace
