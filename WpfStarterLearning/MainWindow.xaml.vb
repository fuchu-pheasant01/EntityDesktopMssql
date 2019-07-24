Imports System.Data.SqlClient
Class MainWindow
    Private Sub MainWindow1_Loaded(sender As Object, e As RoutedEventArgs) Handles MainWindow1.Loaded

        Me.ResizeMode = ResizeMode.NoResize
        Me.Title = "WPFアプリ、スターター学習"
        RichTextBox1.AppendText("WPFアプリ、スターター学習..." & vbCrLf)

    End Sub

    Private Sub ButtonDbRead_Click(sender As Object, e As RoutedEventArgs) Handles ButtonDbRead.Click

        Dim cn As New SqlConnection()
        Dim sb As New SqlConnectionStringBuilder()
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand()
        Dim datat As New System.Data.DataTable()

        sb.DataSource = "(local)\SQLEXPRESS"
        sb.InitialCatalog = "HibernateSample"
        sb.IntegratedSecurity = True
        sb.ConnectTimeout = 3

        cn.ConnectionString = sb.ConnectionString
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "select * from ShohinDataDesk"
        dr = cmd.ExecuteReader()

        datat.Load(dr, System.Data.LoadOption.PreserveChanges)
        dr.Close()
        DataGrid1.ItemsSource = datat.DefaultView

        cn.Close()
        RichTextBox1.AppendText("テーブルの内容を読み込みました。" & vbCrLf)

    End Sub

    Private Sub ButtonTimer_Click(sender As Object, e As RoutedEventArgs) Handles ButtonTimer.Click

        Dim subw As New WindowTimer()
        subw.ShowDialog()

    End Sub
End Class
