Imports BookingVbNetApi.Model
Imports BookingVbNetApi.Context
Imports System.Data.SqlClient

Namespace Repository
    Public Class BookingRepository
        Implements IBookingRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Private Shared Function NoNull(ByVal checkValue As Object, ByVal returnIfNull As Object) As Object
            If checkValue Is DBNull.Value Then
                Return returnIfNull
            Else
                Return checkValue
            End If
        End Function

        Public Function FindAllBookingOrders() As List(Of Booking_orders) Implements IBookingRepository.FindAllBookingOrders
            Dim bookingList = New List(Of Booking_orders)

            'declare query sql
            'Dim stmt As String = "select boor_id from Booking.booking_orders"
            Dim stmt As String = "select boor_id, boor_order_number,boor_order_date,boor_arrival_date," &
                "boor_total_room,boor_total_guest,boor_discount,boor_total_tax,boor_total_ammount," &
                "boor_down_payment,boor_pay_type,boor_is_paid,boor_type,boor_cardnumber,boor_member_type," &
                "boor_status,boor_user_id,boor_hotel_id from booking.booking_orders"

            'try connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    Try
                        conn.Open()
                        Dim Reader = cmd.ExecuteReader()

                        While Reader.Read()
                            bookingList.Add(New Booking_orders() With {
                                .BoorId = If(Reader.IsDBNull(0), 0, Reader.GetInt32(0)),
                                .Boor_order_number = If(Reader.IsDBNull(1), "", Reader.GetString(1)),
                                .Boor_order_date = If(Reader.IsDBNull(2), "", Reader.GetDateTime(2).ToLongDateString),
                                .Boor_arrival_date = If(Reader.IsDBNull(3), "", Reader.GetDateTime(3).ToLongDateString),
                                .Boor_total_room = If(Reader.IsDBNull(4), 0, Reader.GetInt16(4)),
                                .Boor_total_guest = If(Reader.IsDBNull(5), 0, Reader.GetInt16(5)),
                                .Boor_discount = If(Reader.IsDBNull(6), 0, Reader.GetDecimal(6)),
                                .Boor_total_tax = If(Reader.IsDBNull(7), 0, Reader.GetSqlDecimal(7)),
                                .Boor_total_amount = If(Reader.IsDBNull(8), 0, Reader.GetDecimal(8)),
                                .Boor_down_payment = If(Reader.IsDBNull(9), 0, Reader.GetDecimal(9)),
                                .Boor_pay_type = If(Reader.IsDBNull(10), "", Reader.GetString(10)),
                                .Boor_is_paid = If(Reader.IsDBNull(11), "", Reader.GetString(11)),
                                .Boor_type = If(Reader.IsDBNull(12), "", Reader.GetString(12)),
                                .Boor_cardnumber = If(Reader.IsDBNull(13), "", Reader.GetString(13)),
                                .Boor_member_type = If(Reader.IsDBNull(14), "", Reader.GetString(14)),
                                .Boor_status = If(Reader.IsDBNull(15), "", Reader.GetString(15)),
                                .Boor_user_id = If(Reader.IsDBNull(16), "", Reader.GetInt32(16)),
                                .Boor_hotel_id = If(Reader.IsDBNull(17), "", Reader.GetInt32(17))
                                })
                        End While
                        Reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                        Console.WriteLine(bookingList)
                    End Try
                End Using
            End Using
            Return bookingList
        End Function


        Public Function CreateNewOrder(bookingOrders As Booking_orders) As Booking_orders Implements IBookingRepository.CreateNewOrder
            Dim NewOrder As New Booking_orders()

            Dim stmt As String =
                "INSERT INTO Booking.booking_orders(boor_order_number,boor_order_date, boor_arrival_date," &
                "boor_total_room, boor_total_guest,boor_discount, boor_total_tax,boor_total_ammount," &
                "boor_down_payment,boor_pay_type,boor_is_paid,boor_type,boor_cardnumber,boor_member_type," &
                "boor_status,boor_user_id,boor_hotel_id)" &
                "VALUES (@orderNumber,@orderDate,@arrivalDate,@totalRoom,@totalGuest,@discount," &
                "@totalTax,@totalAmount,@DP,@payType,@isPaid,@orderType,@cardnumber,@memberType," &
                "@orderStatus,@orderUserID,@orderHotelID);" &
                "SELECT CAST(scope_identity() AS Integer)"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    'cmd.Parameters.AddWithValue("@id", bookingOrders.BoorId)
                    cmd.Parameters.AddWithValue("@orderNumber", bookingOrders.Boor_order_number)
                    cmd.Parameters.AddWithValue("@orderDate", bookingOrders.Boor_order_date)
                    cmd.Parameters.AddWithValue("@arrivalDate", bookingOrders.Boor_arrival_date)
                    cmd.Parameters.AddWithValue("@totalRoom", bookingOrders.Boor_total_room)
                    cmd.Parameters.AddWithValue("@totalGuest", bookingOrders.Boor_total_guest)
                    cmd.Parameters.AddWithValue("@discount", bookingOrders.Boor_discount)
                    cmd.Parameters.AddWithValue("@totalTax", bookingOrders.Boor_total_tax)
                    cmd.Parameters.AddWithValue("@totalAmount", bookingOrders.Boor_total_amount)
                    cmd.Parameters.AddWithValue("@DP", bookingOrders.Boor_down_payment)
                    cmd.Parameters.AddWithValue("@payType", bookingOrders.Boor_pay_type)
                    cmd.Parameters.AddWithValue("@isPaid", bookingOrders.Boor_is_paid)
                    cmd.Parameters.AddWithValue("@orderType", bookingOrders.Boor_type)
                    cmd.Parameters.AddWithValue("@cardnumber", bookingOrders.Boor_cardnumber)
                    cmd.Parameters.AddWithValue("@memberType", bookingOrders.Boor_member_type)
                    cmd.Parameters.AddWithValue("@orderStatus", bookingOrders.Boor_status)
                    cmd.Parameters.AddWithValue("@orderUserID", bookingOrders.Boor_user_id)
                    cmd.Parameters.AddWithValue("@orderHotelID", bookingOrders.Boor_hotel_id)

                    Try
                        conn.Open()
                        Dim boorID As Integer = cmd.ExecuteScalar()
                        NewOrder = FindOrderById(boorID)
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using
            Return NewOrder
        End Function

        Public Function FindOrderById(id As Integer) As Booking_orders Implements IBookingRepository.FindOrderById
            Dim boor As New Booking_orders With {.BoorId = id}
            Dim stmt As String = "select boor_order_number,boor_order_date,boor_arrival_date," &
                "boor_total_room,boor_total_guest,boor_discount,boor_total_tax,boor_total_ammount," &
                "boor_down_payment,boor_pay_type,boor_is_paid,boor_type,boor_cardnumber,boor_member_type," &
                "boor_status,boor_user_id,boor_hotel_id from booking.booking_orders where boor_id=@boor_id"
            'Dim stmt As String = "select boor_user_id from Booking.booking_orders where boor_id=@boor_id"

            Using con As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@boor_id", id)
                    Try
                        con.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            boor.Boor_order_number = If(reader.IsDBNull(0), "", reader.GetString(0))
                            boor.Boor_order_date = If(reader.IsDBNull(1), "", reader.GetDateTime(1).ToString)
                            boor.Boor_arrival_date = If(reader.IsDBNull(2), "", reader.GetDateTime(2).ToString)
                            boor.Boor_total_room = If(reader.IsDBNull(3), 0, reader.GetInt16(3))
                            boor.Boor_total_guest = If(reader.IsDBNull(4), 0, reader.GetInt16(4))
                            boor.Boor_discount = If(reader.IsDBNull(5), 0, reader.GetDecimal(5))
                            boor.Boor_total_tax = If(reader.IsDBNull(6), 0, reader.GetDecimal(6))
                            boor.Boor_total_amount = If(reader.IsDBNull(7), 0, reader.GetSqlMoney(7).ToDouble)
                            boor.Boor_down_payment = If(reader.IsDBNull(8), 0, reader.GetSqlMoney(8).ToDouble)
                            boor.Boor_pay_type = If(reader.IsDBNull(9), "", reader.GetString(9))
                            boor.Boor_is_paid = If(reader.IsDBNull(10), "", reader.GetString(10))
                            boor.Boor_type = If(reader.IsDBNull(11), "", reader.GetString(11))
                            boor.Boor_cardnumber = If(reader.IsDBNull(12), "", reader.GetString(12))
                            boor.Boor_member_type = If(reader.IsDBNull(13), "", reader.GetString(13))
                            boor.Boor_status = If(reader.IsDBNull(14), "", reader.GetString(14))
                            boor.Boor_user_id = If(reader.IsDBNull(15), 0, reader.GetInt32(15))
                            boor.Boor_hotel_id = If(reader.IsDBNull(16), 0, reader.GetInt32(16))
                        End If
                        reader.Close()
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)

                    End Try
                End Using
            End Using
            Return boor
        End Function

        Public Function DeleteRegion(id As Integer) As Integer Implements IBookingRepository.DeleteRegion
            Dim rowEffect As Int32 = 0

            Dim stmt As String = "delete from Booking.booking_orders where boor_id =@id"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@id", id)

                    Try
                        conn.Open()
                        rowEffect = cmd.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return rowEffect
        End Function

 
        Public Function UpdateBookingById(id As Integer, orderDateValue As String, arrivalDateValue As String, totalRoomvalue As Integer, totalGuestValue As Integer, discountValue As Decimal, totalTaxValue As Decimal, totalAmountValue As Double, DpValue As Integer, payTypeValue As String, isPaidValue As String, orderTypeValue As String, cardnumberValue As Integer, memberTypeValue As String, statusValue As String, userIdValue As Integer, hotelIdValue As Integer, Optional showCommand As Boolean = False) As Boolean Implements IBookingRepository.UpdateBookingById
            Dim updatebooking As New Booking_orders()

            Dim stmt As String = "Update Booking.Booking_orders " &
                                 "SET " &
                                 "boor_order_date=@orderDate, " &
                                 "boor_arrival_date=@arrivalDate, " &
                                 "boor_total_room=@totalRoom, " &
                                 "boor_total_guest=@totalGuest, " &
                                 "boor_discount=@discount, " &
                                 "boor_total_tax=@totalTax, " &
                                 "boor_total_ammount=@totalAmount, " &
                                 "boor_down_payment=@DP, " &
                                 "boor_pay_type=@payType, " &
                                 "boor_is_paid=@isPaid, " &
                                 "boor_type=@orderType, " &
                                 "boor_cardnumber=@cardnumber, " &
                                 "boor_member_type=@memberType, " &
                                 "boor_status=@orderStatus, " &
                                 "boor_user_id=@orderUserID, " &
                                 "boor_hotel_id=@orderHotelID " &
                                 "WHERE boor_id = @id; "

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@orderDate", orderDateValue)
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDateValue)
                    cmd.Parameters.AddWithValue("@totalRoom", totalRoomvalue)
                    cmd.Parameters.AddWithValue("@totalGuest", totalGuestValue)
                    cmd.Parameters.AddWithValue("@discount", discountValue)
                    cmd.Parameters.AddWithValue("@totalTax", totalTaxValue)
                    cmd.Parameters.AddWithValue("@totalAmount", totalAmountValue)
                    cmd.Parameters.AddWithValue("@DP", DpValue)
                    cmd.Parameters.AddWithValue("@payType", payTypeValue)
                    cmd.Parameters.AddWithValue("@isPaid", isPaidValue)
                    cmd.Parameters.AddWithValue("@orderType", orderTypeValue)
                    cmd.Parameters.AddWithValue("@cardnumber", cardnumberValue)
                    cmd.Parameters.AddWithValue("@memberType", memberTypeValue)
                    cmd.Parameters.AddWithValue("@orderStatus", statusValue)
                    cmd.Parameters.AddWithValue("@orderUserID", userIdValue)
                    cmd.Parameters.AddWithValue("@orderHotelID", hotelIdValue)
                    cmd.Parameters.AddWithValue("@id", id)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function

        Public Function UpdateBookingBySp(id As Integer, Optional orderNumberValue As String = "", Optional orderDateValue As String = "",
                                          Optional arrivalDateValue As String = "", Optional totalRoomvalue As Integer = 0,
                                          Optional totalGuestValue As Integer = 0, Optional discountValue As Decimal = 0.0,
                                          Optional totalTaxValue As Decimal = 0.11, Optional totalAmountValue As Double = 0,
                                          Optional DpValue As Double = 0, Optional payTypeValue As String = "",
                                          Optional isPaidValue As String = "", Optional orderTypeValue As String = "",
                                          Optional cardnumberValue As String = "", Optional memberTypeValue As String = "",
                                          Optional statusValue As String = "", Optional userIdValue As Integer = 0,
                                          Optional hotelIdValue As Integer = 0, Optional showCommand As Boolean = False) As Booking_orders Implements IBookingRepository.UpdateBookingBySp
            Dim stmt As String = "Booking.spUpdateBookingOrder"
            Dim updatebooking As New Booking_orders()
            Dim defaultBoor = FindOrderById(id)

            If orderNumberValue = "" Then
                orderNumberValue = defaultBoor.Boor_order_number
            End If

            If orderDateValue = "" Then
                orderDateValue = defaultBoor.Boor_order_date
            End If

            If arrivalDateValue = "" Then
                arrivalDateValue = defaultBoor.Boor_arrival_date
            End If

            If totalRoomvalue = 0 Then
                totalRoomvalue = defaultBoor.Boor_total_room
            End If

            If totalGuestValue = 0 Then
                totalGuestValue = defaultBoor.Boor_total_guest
            End If

            If discountValue = 0 Then
                discountValue = defaultBoor.Boor_discount
            End If

            If totalTaxValue = 0 Then
                totalTaxValue = defaultBoor.Boor_total_tax
            End If

            If totalAmountValue = 0 Then
                totalAmountValue = defaultBoor.Boor_total_amount
            End If

            If DpValue = 0 Then
                DpValue = defaultBoor.Boor_down_payment
            End If

            If payTypeValue = "" Then
                payTypeValue = defaultBoor.Boor_pay_type
            End If

            If isPaidValue = "" Then
                isPaidValue = defaultBoor.Boor_is_paid
            End If

            If orderTypeValue = "" Then
                orderTypeValue = defaultBoor.Boor_type
            End If

            If cardnumberValue = "" Then
                cardnumberValue = defaultBoor.Boor_cardnumber
            End If

            If memberTypeValue = "" Then
                memberTypeValue = defaultBoor.Boor_member_type
            End If

            If statusValue = "" Then
                statusValue = defaultBoor.Boor_status
            End If
            If userIdValue = 0 Then
                userIdValue = defaultBoor.Boor_user_id
            End If
            If hotelIdValue = 0 Then
                hotelIdValue = defaultBoor.Boor_hotel_id
            End If

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@boor_id", id)
                    cmd.Parameters.AddWithValue("@boor_order_number", orderNumberValue)
                    cmd.Parameters.AddWithValue("@boor_order_date", orderDateValue)
                    cmd.Parameters.AddWithValue("@boor_arrival_date", arrivalDateValue)
                    cmd.Parameters.AddWithValue("@boor_total_room", totalRoomvalue)
                    cmd.Parameters.AddWithValue("@boor_total_guest", totalGuestValue)
                    cmd.Parameters.AddWithValue("@boor_discount", discountValue)
                    cmd.Parameters.AddWithValue("@boor_total_tax", totalTaxValue)
                    cmd.Parameters.AddWithValue("@boor_total_amount", totalAmountValue)
                    cmd.Parameters.AddWithValue("@boor_down_payment", DpValue)
                    cmd.Parameters.AddWithValue("@boor_pay_type", payTypeValue)
                    cmd.Parameters.AddWithValue("@boor_is_paid", isPaidValue)
                    cmd.Parameters.AddWithValue("@boor_type", orderTypeValue)
                    cmd.Parameters.AddWithValue("@boor_cardnumber", cardnumberValue)
                    cmd.Parameters.AddWithValue("@boor_member_type", memberTypeValue)
                    cmd.Parameters.AddWithValue("@boor_status", statusValue)
                    cmd.Parameters.AddWithValue("@boor_user_id", userIdValue)
                    cmd.Parameters.AddWithValue("@boor_hotel_id", hotelIdValue)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        If cmd.ExecuteNonQuery() Then
                            updatebooking = FindOrderById(id)
                        End If
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return updatebooking
        End Function
    End Class
End Namespace