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
            Dim AllbordeList = New List(Of Borde)

            Dim stmt = "SELECT * FROM booking_order_detail"

            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = stmt}
                    Try
                        conn.Open()
                        Dim Reader = cmd.ExecuteReader()

                        While Reader.Read()
                            AllbordeList.Add(New Borde With {
                                .Borde_boor_id = If(Reader.IsDBNull(0), 0, Reader.GetInt32(0)),
                                .Borde_id = If(Reader.IsDBNull(1), "", Reader.GetInt32(1)),
                                .Borde_checkin = If(Reader.IsDBNull(2), "", Reader.GetDateTime(2).ToLongDateString),
                                .Borde_checkout = If(Reader.IsDBNull(3), "", Reader.GetDateTime(3).ToLongDateString),
                                .Borde_adults = If(Reader.IsDBNull(4), 0, Reader.GetInt16(4)),
                                .Borde_kids = If(Reader.IsDBNull(5), 0, Reader.GetInt16(5)),
                                .Borde_price = If(Reader.IsDBNull(6), 0, Reader.GetInt16(6)),
                                .Borde_extra = If(Reader.IsDBNull(7), 0, Reader.GetInt16(7)),
                                .Borde_discount = If(Reader.IsDBNull(8), 0, Reader.GetSqlDecimal(8)),
                                .Borde_tax = If(Reader.IsDBNull(9), 0, Reader.GetSqlDecimal(9)),
                                .Borde_subtotal = If(Reader.IsDBNull(10), 0, Reader.GetInt16(10)),
                                .Borde_faci_id = If(Reader.IsDBNull(11), 0, Reader.GetInt16(11))
                            })
                        End While
                        Reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return AllbordeList
        End Function

        Public Function FindBordeById(borde_id As Integer) As Borde Implements IBordeRepository.FindBordeById
            Throw New NotImplementedException()
        End Function

        Public Function CreateNewBorde(borde As Borde) As Borde Implements IBordeRepository.CreateNewBorde
            Throw New NotImplementedException()
        End Function

        Public Function DeleteBorde(borde_id As Integer) As Integer Implements IBordeRepository.DeleteBorde
            Throw New NotImplementedException()
        End Function

        Public Function UpdateBordeBySp(borde_id As Integer, borde_boor_id As Integer, borde_checkin As String, borde_checkouot As String, borde_adults As Integer, borde_kids As Integer, borde_price As Double, borde_extra As Double, borde_discount As Double, borde_tax As Double, borde_subtotal As Double, borde_faci_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements IBordeRepository.UpdateBordeBySp
            Throw New NotImplementedException()
        End Function
    End Class


End Namespace
