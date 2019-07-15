
Imports UKLE.TeamUnitor.Unitor

Public Class PrepareRequest
    Public chain As Integer
    Public x As String
    Public y As Integer
    Public LEDList_initial As New List(Of UKLE.TeamUnitor.Unitor.UKLE.LEDStructure)
    Sub New(ByVal chain_ As Integer, ByVal x_ As String, ByVal y_ As Integer, ByVal LEDList_initial_ As List(Of UKLE.TeamUnitor.Unitor.UKLE.LEDStructure))
        chain = chain_
        x = x_
        y = y_
        LEDList_initial = LEDList_initial_
    End Sub
End Class
