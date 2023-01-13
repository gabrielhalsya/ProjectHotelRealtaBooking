Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports BookingVbNetApi.Context
Imports BookingVbNetApi.Model

Namespace Repository
    Public Class SocoRepository
        Implements ISocoRepository

        Private _context As IRepositoryContext

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllSoco() As List(Of Soco) Implements ISocoRepository.FindAllSoco
            Dim socoList As New List(Of Soco)
            Dim stmt = "select * from Booking.special_offer_coupons"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    Try
                        con.Open()
                        Dim reader = cmd.ExecuteReader()
                        While reader.Read()
                            socoList.Add(New Soco With {
                            .Soco_id = reader.GetInt32(0),
                            .Soco_borde_id = reader.GetInt32(1),
                            .Soco_spof_id = reader.GetInt32(2)
                            })
                        End While
                        reader.Close()
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return socoList
        End Function

        Public Async Function FindAllSocoAsync() As Task(Of List(Of Soco)) Implements ISocoRepository.FindAllSocoAsync
            Dim socoList = New List(Of Soco)
            Dim stmt = "select * from Booking.special_offer_coupons"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    Try
                        con.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()
                        While reader.Read()
                            socoList.Add(New Soco With {
                            .Soco_id = reader.GetInt32(0),
                            .Soco_borde_id = reader.GetInt32(1),
                            .Soco_spof_id = reader.GetInt32(2)
                            })
                        End While
                        reader.Close()
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using
            Return socoList
        End Function

        Public Function FindSocoById(soco_id As Integer) As Soco Implements ISocoRepository.FindSocoById
            Dim soco As New Soco() With {.Soco_id = soco_id}
            Dim stmt As String = "select * from Booking.special_offer_coupons where soco_id=@soco_id"

            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@soco_id", soco_id)
                    Try
                        con.Open()
                        Dim reader = cmd.ExecuteReader
                        If reader.HasRows Then
                            reader.Read()
                            soco.Soco_id = reader.GetInt32(0)
                            soco.Soco_borde_id = reader.GetInt32(1)
                            soco.Soco_spof_id = reader.GetInt32(2)
                        End If
                        reader.Close()
                        con.Close()

                    Catch ex As Exception

                    End Try
                End Using

            End Using
            Return soco
        End Function

        Public Function CreateNewSoco(soco As Soco) As Soco Implements ISocoRepository.CreateNewSoco
            Dim newSoco = New Soco()
            Dim stmt As String =
                "insert into Booking.special_offer_coupons(soco_borde_id,soco_spof_id)" &
                "values (2,3);" &
                "SELECT CAST(SCOPE_IDENTITY()as Integer)"

            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@soco_borde_id", soco.Soco_borde_id)
                    cmd.Parameters.AddWithValue("@soco_spof_id", soco.Soco_spof_id)
                    Try
                        con.Open()
                        Dim soco_id As Integer = cmd.ExecuteScalar()
                        newSoco = FindSocoById(soco_id)
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newSoco
        End Function

        Public Function DeleteSoco(soco_id As Integer) As Integer Implements ISocoRepository.DeleteSoco
            Dim rowAffected As Int16 = 0
            Dim stmt As String = "delete from Booking.special_offer_coupons where soco_id=@soco_id"
            Using con As New SqlConnection() With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand() With {.Connection = con, .CommandText = stmt}
                    cmd.Parameters.AddWithValue("@soco_id", soco_id)
                    Try
                        con.Open()
                        rowAffected = cmd.ExecuteNonQuery
                        con.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return rowAffected
        End Function

        Public Function UpdateSocoBySp(soco_id As Integer, soco_borde_id As Integer, soco_spof_id As Integer, Optional showCommand As Boolean = False) As Boolean Implements ISocoRepository.UpdateSocoBySp
            Dim stmt = "Booking.updateSpecialOfferCoupons"
            Dim socoExists = FindSocoById(soco_id)

            Using con As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = con, .CommandText = stmt, .CommandType = CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@soco_id", soco_id)
                    cmd.Parameters.AddWithValue("@soco_borde_id", soco_borde_id)
                    cmd.Parameters.AddWithValue("@soco_spof_id", soco_spof_id)
                    If showCommand Then
                        Console.WriteLine(cmd.ExecuteNonQuery)
                    End If

                    Try
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                    Catch ex As Exception

                    End Try
                End Using
            End Using
            Return True
        End Function
    End Class

End Namespace