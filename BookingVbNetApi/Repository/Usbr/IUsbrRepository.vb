Imports BookingVbNetApi.Model

Namespace Repository
    Public Interface IUsbrRepository
        Function FindAllUsbr() As List(Of Usbr)

        Function FindAllUsbrAsync() As Task(Of List(Of Usbr))

        Function FindUsbrByDate(ByVal usbr_modified_date As String, usbr_borde_id As Integer) As Usbr

        Function CreateNewUsbr(Usbr As Usbr) As Usbr

        Function DeleteUsbr(ByVal usbr_modified_date As String, usbr_borde_id As Integer) As Integer

        Function UpdateUsbrBySp(usbr_modified_date As String,
                                usbr_borde_id As Integer,
                                usbr_total_vacant As Integer,
                                Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace