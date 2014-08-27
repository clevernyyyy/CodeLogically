Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Collections.Specialized

<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
<Script.Services.ScriptService()> _
Public Class AddQuestion
    Inherits System.Web.Services.WebService


    Dim instance As CreateNewSurvey

    Public Sub New()
        instance = New CreateNewSurvey
    End Sub

    <WebMethod()> _
    Public Sub UpdateQuestion()
        Try
            instance.SaveCurrentList()
            instance.NewQuestion()

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

End Class