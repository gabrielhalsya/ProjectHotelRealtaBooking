Imports BookingVbNetApi.Repository
Namespace Base
    Public Interface IRepositoryManager
        ReadOnly Property Booking As IBookingRepository

        ReadOnly Property Borde As IBookingRepository

        ReadOnly Property Boex As IBookingRepository

        ReadOnly Property Soco As IBookingRepository

        ReadOnly Property Spof As IBookingRepository

        ReadOnly Property Usbr As IBookingRepository




    End Interface
End Namespace