Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Linq
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports Drawing = System.Drawing
Imports Forms = System.Windows.Forms
Imports System.Threading
Imports System.Diagnostics
Imports System.Windows.Threading
Imports System.Collections
Imports System.Collections.Generic

Namespace NotificationAreaApplication1
	''' <summary>
	''' Represents a thin wrapper for <see cref="Forms.NotifyIcon"/>
	''' </summary>
    <ContentProperty("Text"), DefaultEvent("MouseDoubleClick")>
    Public Class NotificationAreaIcon
        Inherits FrameworkElement
        Private notifyIcon As Forms.NotifyIcon

        Public Shared ReadOnly MouseClickEvent As RoutedEvent = EventManager.RegisterRoutedEvent("MouseClick", RoutingStrategy.Bubble, GetType(MouseButtonEventHandler), GetType(NotificationAreaIcon))

        Public Shared ReadOnly MouseDoubleClickEvent As RoutedEvent = EventManager.RegisterRoutedEvent("MouseDoubleClick", RoutingStrategy.Bubble, GetType(MouseButtonEventHandler), GetType(NotificationAreaIcon))

        Public Shared ReadOnly IconProperty As DependencyProperty = DependencyProperty.Register("Icon", GetType(ImageSource), GetType(NotificationAreaIcon))

        Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(NotificationAreaIcon))

        Public Shared ReadOnly FormsContextMenuProperty As DependencyProperty = DependencyProperty.Register("MenuItems", GetType(List(Of Forms.MenuItem)), GetType(NotificationAreaIcon), New PropertyMetadata(New List(Of Forms.MenuItem)()))

        Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
            MyBase.OnInitialized(e)


            ' Create and initialize the window forms notify icon based
            notifyIcon = New Forms.NotifyIcon()
            notifyIcon.Text = Text
            If (Not DesignerProperties.GetIsInDesignMode(Me)) Then
                notifyIcon.Icon = FromImageSource(Icon)
            End If
            notifyIcon.Visible = FromVisibility(Visibility)

            If Me.MenuItems IsNot Nothing AndAlso Me.MenuItems.Count > 0 Then
                notifyIcon.ContextMenu = New System.Windows.Forms.ContextMenu(Me.MenuItems.ToArray())
            End If

            AddHandler notifyIcon.MouseDown, AddressOf OnMouseDown
            AddHandler notifyIcon.MouseUp, AddressOf OnMouseUp
            AddHandler notifyIcon.MouseClick, AddressOf OnMouseClick
            AddHandler notifyIcon.MouseDoubleClick, AddressOf OnMouseDoubleClick

            AddHandler Dispatcher.ShutdownStarted, AddressOf OnDispatcherShutdownStarted
        End Sub

        Private Sub OnDispatcherShutdownStarted(ByVal sender As Object, ByVal e As EventArgs)
            notifyIcon.Dispose()
        End Sub

        Private Overloads Sub OnMouseDown(ByVal sender As Object, ByVal e As Forms.MouseEventArgs)
            OnRaiseEvent(MouseDownEvent, New MouseButtonEventArgs(InputManager.Current.PrimaryMouseDevice, 0, ToMouseButton(e.Button)))
        End Sub

        Private Overloads Sub OnMouseUp(ByVal sender As Object, ByVal e As Forms.MouseEventArgs)
            OnRaiseEvent(MouseUpEvent, New MouseButtonEventArgs(InputManager.Current.PrimaryMouseDevice, 0, ToMouseButton(e.Button)))
        End Sub

        Private Sub OnMouseDoubleClick(ByVal sender As Object, ByVal e As Forms.MouseEventArgs)
            OnRaiseEvent(MouseDoubleClickEvent, New MouseButtonEventArgs(InputManager.Current.PrimaryMouseDevice, 0, ToMouseButton(e.Button)))
        End Sub

        Private Sub OnMouseClick(ByVal sender As Object, ByVal e As Forms.MouseEventArgs)
            OnRaiseEvent(MouseClickEvent, New MouseButtonEventArgs(InputManager.Current.PrimaryMouseDevice, 0, ToMouseButton(e.Button)))
        End Sub

        Private Sub OnRaiseEvent(ByVal handler As RoutedEvent, ByVal e As MouseButtonEventArgs)
            e.RoutedEvent = handler
            MyBase.RaiseEvent(e)
        End Sub

        Public Property MenuItems() As List(Of Forms.MenuItem)
            Get
                Return CType(GetValue(FormsContextMenuProperty), List(Of Forms.MenuItem))
            End Get
            Set(ByVal value As List(Of Forms.MenuItem))
                SetValue(FormsContextMenuProperty, value)
            End Set
        End Property

        Public Property Icon() As ImageSource
            Get
                Return CType(GetValue(IconProperty), ImageSource)
            End Get
            Set(ByVal value As ImageSource)
                SetValue(IconProperty, value)
            End Set
        End Property

        Public Property Text() As String
            Get
                Return CStr(GetValue(TextProperty))
            End Get
            Set(ByVal value As String)
                SetValue(TextProperty, value)
            End Set
        End Property

        Public Custom Event MouseClick As MouseButtonEventHandler
            AddHandler(ByVal value As MouseButtonEventHandler)
                MyBase.AddHandler(MouseClickEvent, value)
            End AddHandler
            RemoveHandler(ByVal value As MouseButtonEventHandler)
                MyBase.RemoveHandler(MouseClickEvent, value)
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDoubleClick As MouseButtonEventHandler
            AddHandler(ByVal value As MouseButtonEventHandler)
                MyBase.AddHandler(MouseDoubleClickEvent, value)
            End AddHandler
            RemoveHandler(ByVal value As MouseButtonEventHandler)
                MyBase.RemoveHandler(MouseDoubleClickEvent, value)
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
            End RaiseEvent
        End Event

#Region "Conversion members"

        Private Shared Function FromImageSource(ByVal icon As ImageSource) As Drawing.Icon
            If icon Is Nothing Then
                Return Nothing
            End If
            Dim iconUri As New Uri(icon.ToString())
            Return New Drawing.Icon(Application.GetResourceStream(iconUri).Stream)
        End Function

        Private Shared Function FromVisibility(ByVal visibility As Visibility) As Boolean
            Return visibility = Windows.Visibility.Visible
        End Function

        Private Function ToMouseButton(ByVal button As Forms.MouseButtons) As MouseButton
            Select Case button
                Case Forms.MouseButtons.Left
                    Return MouseButton.Left
                Case Forms.MouseButtons.Right
                    Return MouseButton.Right
                Case Forms.MouseButtons.Middle
                    Return MouseButton.Middle
                Case Forms.MouseButtons.XButton1
                    Return MouseButton.XButton1
                Case Forms.MouseButtons.XButton2
                    Return MouseButton.XButton2
            End Select
            Throw New InvalidOperationException()
        End Function

#End Region
    End Class
End Namespace