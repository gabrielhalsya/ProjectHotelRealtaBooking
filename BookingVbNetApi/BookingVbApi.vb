Imports BookingVbNetApi.Base
Imports BookingVbNetApi.Context
Public Class BookingVbApi
    Implements IBookingVbApi

    Private Property _repoManager As IRepositoryManager
    Private ReadOnly _repositoryContext As IRepositoryContext 'buat variabel untuk menyimpan variabel untuk IRepo

    Public Sub New(ByVal connString As String)
        'Console.WriteLine($"Cek connString apakah ketangkap : {connString}")
        If _repositoryContext Is Nothing Then
            _repositoryContext = New RepositoryContext(connString)
        End If
    End Sub

    Public ReadOnly Property RepositoryManager As IRepositoryManager Implements IBookingVbApi.RepositoryManager
        Get
            If _repoManager Is Nothing Then
                _repoManager = New RepositoryManager(_repositoryContext)
            End If
            Return _repoManager
        End Get
    End Property

    Public Sub SayHello() Implements IBookingVbApi.SayHello
        Console.WriteLine("Test")
    End Sub
End Class
