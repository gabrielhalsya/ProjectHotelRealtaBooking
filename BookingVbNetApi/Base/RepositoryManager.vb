Imports BookingVbNetApi.Repository
Imports BookingVbNetApi.Context
Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _bookingRepository As IBookingRepository
        Private _bordeRepository As IBordeRepository
        Private _socoRepository As ISocoRepository
        Private _usbrRepository As IUsbrRepository


        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public ReadOnly Property Booking As IBookingRepository Implements IRepositoryManager.Booking
            Get
                'get IBookingRepository & Implementation
                If _bookingRepository Is Nothing Then
                    _bookingRepository = New BookingRepository(_repositoryContext)
                End If
                Return _bookingRepository
            End Get
        End Property

        Public ReadOnly Property Borde As IBordeRepository Implements IRepositoryManager.Borde
            Get
                If _bordeRepository Is Nothing Then
                    _bordeRepository = New BordeRepository(_repositoryContext)
                End If
                Return _bordeRepository
            End Get
        End Property

        Public ReadOnly Property Soco As ISocoRepository Implements IRepositoryManager.Soco
            Get
                If _socoRepository Is Nothing Then
                    _socoRepository = New SocoRepository(_repositoryContext)
                End If
                Return _socoRepository
            End Get
        End Property

        Public ReadOnly Property Usbr As IUsbrRepository Implements IRepositoryManager.Usbr
            Get
                If _usbrRepository Is Nothing Then
                    _usbrRepository = New UsbrRepository(_repositoryContext)
                End If
                Return _usbrRepository
            End Get
        End Property
    End Class
End Namespace