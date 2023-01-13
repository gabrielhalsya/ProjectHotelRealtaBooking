Imports BookingVbNetApi.Repository
Namespace Base
    Public Interface IRepositoryManager
        ReadOnly Property Booking As IBookingRepository

        ReadOnly Property Borde As IBordeRepository

        ReadOnly Property Soco As ISocoRepository

        ReadOnly Property Usbr As IUsbrRepository

    End Interface
End Namespace