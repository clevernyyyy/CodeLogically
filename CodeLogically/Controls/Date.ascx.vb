Public Class _Date
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Private Property dMinDate As Nullable(Of Date) = Nothing
    Public Property MinDate As Nullable(Of Date)
        Get
            Return dMinDate
        End Get
        Set(value As Nullable(Of Date))
            dMinDate = value
        End Set
    End Property
    Private Property dMaxDate As Nullable(Of Date) = Nothing
    Public Property MaxDate As Nullable(Of Date)
        Get
            Return dMaxDate
        End Get
        Set(value As Nullable(Of Date))
            dMaxDate = value
        End Set
    End Property
#End Region

#Region "Events"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#End Region

#Region "Public"
    Public Sub ClearData()
        txtDate.Text = ""
    End Sub
    Public Sub FillData(ByVal d As Nullable(Of Date))
        If d Is Nothing Then
            txtDate.Text = ""
        Else
            txtDate.Text = CType(d, Date).ToStdDateString()
        End If
    End Sub

    Public Function Modified(ByVal dOrig As Nullable(Of Date)) As Boolean
        Dim lModified As Boolean = False

        If Validate(lAddErrorClass:=False) Then
            If dOrig Is Nothing OrElse Not dOrig.HasValue Then
                lModified = True
            Else
                Dim dNew As Date
                Save(dNew)
                lModified = dOrig.Value <> dNew
            End If
        Else
            If Not dOrig Is Nothing AndAlso dOrig.HasValue Then
                lModified = True
            End If
        End If

        Return lModified
    End Function

    Public Function Validate(Optional ByVal lAllowEmpty As Boolean = False, Optional ByVal lAddErrorClass As Boolean = True) As Boolean
        Try
            Dim lValid As Boolean = True

            If lAllowEmpty And txtDate.Text = "" Then
                lValid = True
            Else
                lValid = lValid And ValidParse() 'Test input itself

                If lValid Then
                    If dMinDate.HasValue Then
                        lValid = lValid And dMinDate < dCur()
                    End If
                    If dMaxDate.HasValue Then
                        lValid = lValid And dCur() < dMaxDate
                    End If
                End If
            End If

            Return lValid
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Save(ByRef dDate As Nullable(Of Date))
        If txtDate.Text.Trim = "" Then
            dDate = Nothing
        Else
            If dDate Is Nothing Then
                dDate = New Date
            End If

            Date.TryParse(txtDate.Text, dDate)
        End If
    End Sub

#End Region

#Region "Helpers"
    Private Function dCur()
        Dim dNew As New Date
        Save(dNew)
        Return dNew
    End Function

    Private Function ValidParse() As Boolean
        Dim lValid As Boolean = True
        lValid = Date.TryParse(txtDate.Text, New Date)

        Return lValid
    End Function
#End Region


End Class