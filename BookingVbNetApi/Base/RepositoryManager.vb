Imports BookingVbNetApi.Repository
Imports BookingVbNetApi.Context
Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _bookingRepository As IBookingRepository
        Private _bordeRepository As IBordeRepository

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

        Public ReadOnly Property Borde As IBookingRepository Implements IRepositoryManager.Borde
            Get
                If _bordeRepository Is Nothing Then
                    _bordeRepository = New BordeRepository(_repositoryContext)
                End If
                Return _bordeRepository
            End Get
        End Property

        Public ReadOnly Property Boex As IBookingRepository Implements IRepositoryManager.Boex
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property Soco As IBookingRepository Implements IRepositoryManager.Soco
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property Spof As IBookingRepository Implements IRepositoryManager.Spof
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property Usbr As IBookingRepository Implements IRepositoryManager.Usbr
            Get
                Throw New NotImplementedException()
            End Get
        End Property
    End Class
End Namespace