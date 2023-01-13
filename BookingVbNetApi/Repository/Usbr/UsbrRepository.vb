Imports System.Data.SqlClient
Imports BookingVbNetApi.Context
Imports BookingVbNetApi.Model

Namespace Repository
    Public Class UsbrRepository
        Implements IUsbrRepository

        Private _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllUsbr() As List(Of Usbr) Implements IUsbrRepository.FindAllUsbr
            Dim listUsbr = New List(Of Usbr)
            Dim stmt = "select * from Booking.user_breakfast"
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            listUsbr.Add(New Usbr With {
                                .Usbr_borde_id = reader.GetInt32(0),
                                .Usbr_modified_date = reader.GetDateTime(1),
                                .Usbr_total_vacant = reader.GetInt16(2)
                            })
                        End While
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return listUsbr
        End Function

        Public Async Function FindAllUsbrAsync() As Task(Of List(Of Usbr)) Implements IUsbrRepository.FindAllUsbrAsync
            Dim listUsbr = New List(Of Usbr)
            Dim stmt = "select * from Booking.user_breakfast"
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()
                        While reader.Read()
                            listUsbr.Add(New Usbr With {
                                .Usbr_borde_id = reader.GetInt32(0),
                                .Usbr_modified_date = reader.GetDateTime(1),
                                .Usbr_total_vacant = reader.GetInt16(2)
                            })
                        End While
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return listUsbr
        End Function

        Public Function FindUsbrByDate(usbr_modified_date As String, usbr_borde_id As Integer) As Usbr Implements IUsbrRepository.FindUsbrByDate
            Dim usbr As New Usbr()
            Dim stmt As String =
                "select * from Booking.user_breakfast " &
                " where usbr_modified_date=@usbr_modified_date and usbr_borde_id=@usbr_borde_id"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@usbr_modified_date", usbr_modified_date)
                    cmd.Parameters.AddWithValue("@usbr_borde_id", usbr_borde_id)
                    Try
                        con.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            usbr.Usbr_borde_id = reader.GetInt32(0)
                            usbr.Usbr_modified_date = reader.GetDateTime(1)
                            usbr.Usbr_total_vacant = reader.GetInt16(2)
                        End If
                        reader.Close()
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return usbr
        End Function

        Public Function CreateNewUsbr(Usbr As Usbr) As Usbr Implements IUsbrRepository.CreateNewUsbr
            Dim newUsbr = New Usbr()
            Dim stmt As String =
                "INSERT INTO Booking.user_breakfast (usbr_borde_id, usbr_modified_date, usbr_total_vacant) " &
                " VALUES (@usbr_borde_id, @usbr_modified_date, @usbr_total_vacant)"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}

                    cmd.Parameters.AddWithValue("@usbr_borde_id", Usbr.Usbr_borde_id)
                    cmd.Parameters.AddWithValue("@usbr_modified_date", Usbr.Usbr_modified_date)
                    cmd.Parameters.AddWithValue("@usbr_total_vacant", Usbr.Usbr_total_vacant)
                    Try
                        con.Open()
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        If rowsAffected Then
                            newUsbr = FindUsbrByDate(Usbr.Usbr_modified_date, Usbr.Usbr_borde_id)
                        End If
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    con.Open()
                End Using
            End Using
            Return newUsbr
        End Function

        Public Function DeleteUsbr(usbr_modified_date As String, usbr_borde_id As Integer) As Integer Implements IUsbrRepository.DeleteUsbr
            Dim rowEffect As Int16 = 0
            Dim stmt As String =
                "DELETE FROM Booking.user_breakfast " &
                "WHERE usbr_modified_date=@usbr_modified_date AND usbr_borde_id=@usbr_borde_id"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
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

        Public Function UpdateUsbrBySp(usbr_modified_date As String,
                                usbr_borde_id As Integer,
                                usbr_total_vacant As Integer,
                                Optional showCommand As Boolean = False) As Boolean Implements IUsbrRepository.UpdateUsbrBySp
            Dim stmt = "Booking.updateUserBreakfast"

            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@usbr_borde_id", usbr_borde_id)
                    cmd.Parameters.AddWithValue("@usbr_modified_date", usbr_modified_date)
                    cmd.Parameters.AddWithValue("@usbr_usbr_total_vacant", usbr_total_vacant)
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