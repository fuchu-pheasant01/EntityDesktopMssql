Imports System.Security.Permissions
Imports System.Windows.Threading
Public Class WindowTimer
    Private DispaTmr As New System.Windows.Threading.DispatcherTimer()
    Private DispaTmrCnt As Integer
    Private TimersTmr As New System.Timers.Timer()
    Private DoEventsType As Boolean = True
    Private Sub WindowTimer1_Loaded(sender As Object, e As RoutedEventArgs) Handles WindowTimer1.Loaded

        Me.ResizeMode = ResizeMode.NoResize
        Me.Title = "タイマー、メッセージキュー、スレッド関連"

    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As RoutedEventArgs) Handles ButtonExit.Click

        Me.Close()

    End Sub

    Private Sub ButtonDispaTimer_Click(sender As Object, e As RoutedEventArgs) Handles ButtonDispaTimer.Click

        'DispatcherTimerセットアップ
        AddHandler DispaTmr.Tick, New EventHandler(AddressOf dispatcherTimer_Tick)
        DispaTmr.Interval = New TimeSpan(0, 0, 0, 0, 5)
        DispaTmr.Start()

    End Sub

    Private Sub dispatcherTimer_Tick(sender As Object, e As EventArgs) ' Handles dispatcherTimer.Tick

        'DispatcherTimerのイベントハンドラー内はUIスレッドで動作するので時間のかかる処理を行うとその間は他のイベントハンドラーは受け付けない。

        'System.Windows.Threading.DispatcherTimer.Tickハンドラ
        '現在の秒表示を更新しますCommandManagerで
        'InvalidateRequerySuggestedを強制的に使用します。
        'CanExecuteChangedイベントを発生させるCommand。

        '現在の秒を表示するラベルを更新する
        LabelTime.Content = Format(DateTime.Now, "HH:mm:ss")
        'timec += 1
        'LabelTime.Content = timec

        'CommandManagerにRequerySuggestedイベントを発生させる
        CommandManager.InvalidateRequerySuggested()

    End Sub

    Private Sub ButtonDispaStop_Click(sender As Object, e As RoutedEventArgs) Handles ButtonDispaStop.Click

        DispaTmr.Stop()

    End Sub

    Private Sub ButtonTimersTimer_Click(sender As Object, e As RoutedEventArgs) Handles ButtonTimersTimer.Click

        AddHandler TimersTmr.Elapsed, New Timers.ElapsedEventHandler(AddressOf TimersTimer_Tick)
        'TimersTmr.SynchronizingObject = Me.LabelTime
        TimersTmr.Interval = 500
        'TimersTmr.AutoReset = True
        'TimersTmr.Enabled = True
        TimersTmr.Start()

    End Sub

    Private Sub TimersTimer_Tick(sender As Object, e As Timers.ElapsedEventArgs) 'As Handles TimersTimer.Tick

        'Timers.Timerのイベントハンドラーは別スレッドで実行されるので直接UIスレッドのコントロールにアクセスできない。(スレッドプールで実行される)
        'Invoke、BeginInvoke、EndInvoke
        Application.Current.Dispatcher.Invoke(
        Sub()
            LabelTime.Content = Format(DateTime.Now, "HH:mm:ss")
        End Sub)

    End Sub

    Private Sub ButtonTimersStop_Click(sender As Object, e As RoutedEventArgs) Handles ButtonTimersStop.Click

        TimersTmr.Stop()

    End Sub

    ''' <summary>現在メッセージ待ち行列の中にある全てのUIメッセージを処理します。
    ''' </summary>
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
    Private Sub DoEvents()

        Dim Frame = New DispatcherFrame()

        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf ExitFrame), Frame)
        Dispatcher.PushFrame(Frame)

    End Sub

    Public Function ExitFrame(ByVal f As Object) As Object

        CType(f, DispatcherFrame).Continue = False

        Return Nothing

    End Function

    Public Sub DoEvents2()

        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, New System.Threading.ThreadStart(Sub()
                                                                                                              End Sub))
    End Sub

    Private Sub ButtonHeavy_Click(sender As Object, e As RoutedEventArgs) Handles ButtonHeavy.Click

        'System.Threading.Thread.Sleep(5000)
        Dim sw As New Diagnostics.Stopwatch()
        sw.Reset()
        sw.Start()
        Do While sw.ElapsedMilliseconds < 5000
        Loop
        sw.Stop()

    End Sub

    Private Async Sub ButtonHeavyHi_Click(sender As Object, e As RoutedEventArgs) Handles ButtonHeavyHi.Click

        Await Hidouki()

    End Sub

    Private Async Function Hidouki() As System.Threading.Tasks.Task

        Await Task.Delay(5000)

    End Function

    Private Sub ButtonMessageQueue_Click(sender As Object, e As RoutedEventArgs) Handles ButtonMessageQueue.Click

        If DoEventsType Then
            DoEvents()
        Else
            DoEvents2()
        End If

    End Sub

End Class
