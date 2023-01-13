Imports System.Data.SqlClient
Imports BookingVbNetApi.Context
Imports BookingVbNetApi.Model

Namespace Repository
    Public Class BordeRepository
        Implements IBordeRepository

        Private _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllBorde() As List(Of Borde) Implements IBordeRepository.FindAllBorde
            Dim bordeList = New List(Of Borde)
            Dim stmt = "SELECT * FROM Booking.booking_order_detail"
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            bordeList.Add(New Borde With {
                                .Borde_boor_id = reader.GetInt32(0),
                                .Borde_id = reader.GetInt32(1),
                                .Borde_checkin = reader.GetDateTime(2),
                                .Borde_checkout = reader.GetDateTime(3),
                                .Borde_adults = If(reader.IsDBNull(4), Nothing, reader.GetInt32(4)),
                                .Borde_kids = If(reader.IsDBNull(5), Nothing, reader.GetInt32(5)),
                                .Borde_price = If(reader.IsDBNull(6), Nothing, reader.GetDecimal(6)),
                                .Borde_extra = If(reader.IsDBNull(7), Nothing, reader.GetDecimal(7)),
                                .Borde_discount = If(reader.IsDBNull(8), Nothing, reader.GetDecimal(8)),
                                .Borde_tax = If(reader.IsDBNull(9), Nothing, reader.GetDecimal(9)),
                                .Borde_subtotal = If(reader.IsDBNull(10), Nothing, reader.GetDecimal(10)),
                                .Borde_faci_id = reader.GetInt32(11)
                            })
                        End While
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return bordeList
        End Function

        Public Async Function FindAllBordeAsync() As Task(Of List(Of Borde)) Implements IBordeRepository.FindAllBordeAsync
            Dim bordeList = New List(Of Borde)
            Dim stmt = "SELECT * FROM Booking.booking_order_detail"
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    Try
                        conn.Open()
                        Dim Reader = Await cmd.ExecuteReaderAsync()

                        While Reader.Read()
                            bordeList.Add(New Borde With {
                                .Borde_boor_id = Reader.GetInt32(0),
                                .Borde_id = Reader.GetInt32(1),
                                .Borde_checkin = Reader.GetDateTime(2),
                                .Borde_checkout = If(Reader.IsDBNull(3), Nothing, Reader.GetDateTime(3)),
                                .Borde_adults = If(Reader.IsDBNull(4), Nothing, Reader.GetInt32(4)),
                                .Borde_kids = If(Reader.IsDBNull(5), Nothing, Reader.GetInt32(5)),
                                .Borde_price = If(Reader.IsDBNull(6), Nothing, Reader.GetDecimal(6)),
                                .Borde_extra = If(Reader.IsDBNull(7), Nothing, Reader.GetDecimal(7)),
                                .Borde_discount = If(Reader.IsDBNull(8), Nothing, Reader.GetDecimal(8)),
                                .Borde_tax = If(Reader.IsDBNull(9), Nothing, Reader.GetDecimal(9)),
                                .Borde_subtotal = If(Reader.IsDBNull(10), Nothing, Reader.GetDecimal(10)),
                                .Borde_faci_id = Reader.GetInt32(11)
                            })
                        End While
                        Reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return bordeList
        End Function

        Public Function FindBordeById(borde_id As Integer) As Borde Implements IBordeRepository.FindBordeById
            Dim borde As New Borde() With {.Borde_id = borde_id}
            Dim stmt As String = "select * from Booking.booking_order_detail where borde_id=@borde_id"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@borde_id", borde_id)
                    Try
                        con.Open()
                        Dim reader = cmd.ExecuteReader
                        If reader.HasRows Then
                            reader.Read()
                            borde.Borde_boor_id = reader.GetInt32(0)
                            'borde.Bordeid = reader.GetInt32(1)
                            borde.Borde_checkin = reader.GetSqlDateTime(2).ToString
                            borde.Borde_checkout = If(reader.IsDBNull(3), Nothing, reader.GetDateTime(3))
                            borde.Borde_adults = If(reader.IsDBNull(4), Nothing, reader.GetInt32(4))
                            borde.Borde_kids = If(reader.IsDBNull(5), Nothing, reader.GetInt32(5))
                            borde.Borde_price = If(reader.IsDBNull(6), Nothing, reader.GetDecimal(6))
                            borde.Borde_extra = If(reader.IsDBNull(7), Nothing, reader.GetDecimal(7))
                            borde.Borde_discount = If(reader.IsDBNull(8), Nothing, reader.GetDecimal(8))
                            borde.Borde_tax = If(reader.IsDBNull(9), Nothing, reader.GetDecimal(9))
                            borde.Borde_subtotal = If(reader.IsDBNull(10), Nothing, reader.GetDecimal(10))
                            borde.Borde_faci_id = reader.GetInt32(11)
                        End If
                        reader.Close()
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return borde
        End Function

        Public Function CreateNewBorde(borde As Borde) As Borde Implements IBordeRepository.CreateNewBorde
            Dim newBorde = New Borde()
            Dim stmt As String =
                "INSERT INTO Booking.booking_order_detail(" &
                "borde_boor_id,borde_checkin,borde_checkout," &
                "borde_adults,borde_kids,borde_price,borde_extra," &
                "borde_discount,borde_tax,borde_subtotal,borde_faci_id) " &
                " VALUES (@borde_boor_id,@borde_checkin,@borde_checkout," &
                "@borde_adults,@borde_kids,@borde_price,@borde_extra," &
                "@borde_discount,@borde_tax,@borde_subtotal,@borde_faci_id); " &
                "SELECT CAST(SCOPE_IDENTITY()as Integer)"

            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    'cmd.Parameters.AddWithValue("@borde_id", borde.Borde_boor_id)  'disabled cause identity insert not setted in statement string
                    cmd.Parameters.AddWithValue("@borde_boor_id", borde.Borde_boor_id)
                    cmd.Parameters.AddWithValue("@borde_checkin", borde.Borde_checkin)
                    cmd.Parameters.AddWithValue("@borde_checkout", borde.Borde_checkout)
                    cmd.Parameters.AddWithValue("@borde_adults", If(borde.Borde_adults, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_kids", If(borde.Borde_kids, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_price", If(borde.Borde_price, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_extra", If(borde.Borde_extra, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_discount", If(borde.Borde_discount, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_tax", If(borde.Borde_tax, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_subtotal", If(borde.Borde_subtotal, DBNull.Value))
                    cmd.Parameters.AddWithValue("@borde_faci_id", borde.Borde_faci_id)
                    Try
                        con.Open()
                        Dim borde_id As Integer = cmd.ExecuteScalar()
                        newBorde = FindBordeById(borde_id)
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newBorde
        End Function

        Public Function DeleteBorde(borde_id As Integer) As Integer Implements IBordeRepository.DeleteBorde
            Dim rowEffect As Int16 = 0
            Dim stmt As String = "delete from Booking.booking_order_detail where borde_id=@borde_id"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@borde_id", borde_id)
                    Try
                        con.Open()
                        rowEffect = cmd.ExecuteNonQuery
                        con.Close()

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return rowEffect
        End Function

        Public Function UpdateBordeBySp(borde_id As Integer, borde_boor_id As Integer, borde_checkin As String,
                                        borde_checkout As String, borde_adults As Integer?, borde_kids As Integer?,
                                        borde_price As Decimal?, borde_extra As Decimal?, borde_discount As Decimal?,
                                        borde_tax As Decimal?, borde_subtotal As Decimal?, borde_faci_id As Integer,
                                        Optional showCommand As Boolean = False) As Boolean Implements IBordeRepository.UpdateBordeBySp
            Dim stmt = "Booking.updateBookingOrderDetail" &
                "@borde_boor_id,@borde_id,@borde_checkin,@borde_checkout," &
                "@borde_adults,@borde_kids,@borde_price,@borde_extra," &
                "@borde_discount,@borde_tax,@borde_subtotal,@borde_faci_id"

            Dim bordeExists = FindBordeById(borde_id)

            Using con As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@borde_boor_id", borde_boor_id)
                    cmd.Parameters.AddWithValue("@borde_id", borde_id)
                    cmd.Parameters.AddWithValue("@borde_checkin", borde_checkin)
                    cmd.Parameters.AddWithValue("@borde_checkout", borde_checkout)
                    cmd.Parameters.AddWithValue("@borde_adults", If(borde_adults, bordeExists.Borde_adults))
                    cmd.Parameters.AddWithValue("@borde_kids", If(borde_kids, bordeExists.Borde_kids))
                    cmd.Parameters.AddWithValue("@borde_price", If(borde_price, bordeExists.Borde_price))
                    cmd.Parameters.AddWithValue("@borde_extra", If(borde_extra, bordeExists.Borde_extra))
                    cmd.Parameters.AddWithValue("@borde_discount", If(borde_discount, bordeExists.Borde_discount))
                    cmd.Parameters.AddWithValue("@borde_tax", If(borde_tax, bordeExists.Borde_tax))
                    cmd.Parameters.AddWithValue("@borde_subtotal", If(borde_subtotal, bordeExists.Borde_subtotal))
                    cmd.Parameters.AddWithValue("@borde_faci_id", borde_faci_id)
                    Try
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function

    End Class
End Namespace
