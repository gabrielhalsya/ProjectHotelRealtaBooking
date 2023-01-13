Imports BookingVbNetApi.Model

Namespace Repository
    Public Interface ISocoRepository
        Function FindAllSoco() As List(Of Soco)

        Function FindAllSocoAsync() As Task(Of List(Of Soco))

        Function FindSocoById(ByVal soco_id As Integer) As Soco

        Function CreateNewSoco(soco As Soco) As Soco

        Function DeleteSoco(ByVal soco_id As Integer) As Integer

        Function UpdateSocoBySp(soco_id As Integer, soco_borde_id As Integer, soco_spof_id As Integer,
                                Optional showCommand As Boolean = False) As Boolean

    End Interface


End Namespace