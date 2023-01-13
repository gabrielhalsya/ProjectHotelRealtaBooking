Imports BookingVbNetApi.Model
Namespace Repository
    Public Interface IBordeRepository

        Function FindAllBorde() As List(Of Borde)

        Function FindAllBordeAsync() As Task(Of List(Of Borde))

        Function FindBordeById(ByVal borde_id As Integer) As Borde

        Function CreateNewBorde(borde As Borde) As Borde

        Function DeleteBorde(ByVal borde_id As Integer) As Integer

        Function UpdateBordeBySp(borde_id As Integer, borde_boor_id As Integer,
                                 borde_checkin As String, borde_checkout As String,
                                 borde_adults As Integer?, borde_kids As Integer?,
                                 borde_price As Decimal?, borde_extra As Decimal?,
                                 borde_discount As Decimal?, borde_tax As Decimal?,
                                 borde_subtotal As Decimal?, borde_faci_id As Integer,
                                 Optional showCommand As Boolean = False) As Boolean

    End Interface

End Namespace