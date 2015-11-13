Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input

Namespace NotificationAreaApplication1
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
        Inherits Window
		Private lastWindowState As WindowState
		Private shouldClose As Boolean

		Public Sub New()
			InitializeComponent()
		End Sub

		Protected Overrides Sub OnStateChanged(ByVal e As EventArgs)
			lastWindowState = WindowState
		End Sub

		Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
			If (Not shouldClose) Then
				e.Cancel = True
				Hide()
			End If
		End Sub

        Private Sub OnNotificationAreaIconDoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If e.ChangedButton = MouseButton.Left Then
                Open()
            End If
        End Sub

		Private Sub OnMenuItemOpenClick(ByVal sender As Object, ByVal e As EventArgs)
			Open()
		End Sub

		Private Sub Open()
			Show()
			WindowState = lastWindowState
		End Sub

		Private Sub OnMenuItemExitClick(ByVal sender As Object, ByVal e As EventArgs)
			shouldClose = True
			Close()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show("Hello World")
		End Sub

	End Class
End Namespace