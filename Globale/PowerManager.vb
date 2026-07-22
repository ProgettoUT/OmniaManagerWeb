''' <summary>
''' Simple power manager class that enables applications to inform the system
''' that it is in use, thereby preventing the system from entering the sleeping
''' power state or turning off the display while the application is running.
''' </summary>
Public Class PowerManager

#Region " Private Sub New "
    Private Sub New()
        'keep compiler from creating default constructor to create utility class
    End Sub
#End Region

    ''' <summary>
    ''' Enables applications to inform the system that it is in use, thereby preventing the system from entering the sleeping power state or turning off the display while the application is running.
    ''' </summary>
    ''' <param name="esFlags">The thread's execution requirements. This parameter can be one or more of the EXECUTION_STATE values.</param>
    ''' <returns>
    ''' <para>If the function succeeds, the return value is the previous thread execution state, as a EXECUTION_STATE value.</para>
    ''' <para>If the function fails, the return value is NULL.</para>
    '''</returns>
    ''' <remarks>
    ''' <para>This function does not stop the screen saver from executing.</para>
    ''' <para>http://msdn.microsoft.com/en-us/library/aa373208.aspx</para>
    ''' </remarks>
    Private Declare Function SetThreadExecutionState Lib "kernel32" (esFlags As EXECUTION_STATE) As EXECUTION_STATE

    Public Enum EXECUTION_STATE As Integer

        ''' <summary>
        ''' Informs the system that the state being set should remain in effect until the next call that uses ES_CONTINUOUS and one of the other state flags is cleared.
        ''' </summary>
        ES_CONTINUOUS = &H80000000

        ''' <summary>
        ''' Forces the display to be on by resetting the display idle timer.
        ''' </summary>
        ES_DISPLAY_REQUIRED = &H2

        ''' <summary>
        ''' Forces the system to be in the working state by resetting the system idle timer.
        ''' </summary>
        ES_SYSTEM_REQUIRED = &H1

    End Enum

    Public Shared Function PowerSaveOff() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or EXECUTION_STATE.ES_DISPLAY_REQUIRED Or EXECUTION_STATE.ES_CONTINUOUS)
    End Function

    Public Shared Function PowerSaveOn() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
    End Function

End Class
