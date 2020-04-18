Public Class A2U
    'Made By MineEric64 (최에릭)
    '[BETA] This is Open Project. So you can build this Project!

    ''' <summary>
    ''' Get Version from A2UP.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetVersion() As Version
        Return New Version("2.7.0.0")
    End Function

    Public Class keyLED_MIDEX

        Public Enum keyLED_NoteEvents
            ''' <summary>
            ''' Launchpad LED's Note Number.
            ''' </summary>
            NoteNumber_DrumRackLayout

            ''' <summary>
            ''' Launchpad MIDI In's Note Number.
            ''' </summary>
            NoteNumber_XYLayout



            ''' <summary>
            ''' Launchpad LED's Note Length.
            ''' </summary>
            NoteLength_1

            ''' <summary>
            ''' Get Note Length using FL Studio. (BPM: 120, PPQ: 96 / 192)
            ''' </summary>
            NoteLength_2
        End Enum

        ''' <summary>
        ''' Get keyLED Position X from MIDI Event.
        ''' </summary>
        ''' <param name="List">keyLED Algorithm List.</param>
        ''' <param name="NoteNumber">MIDI Note Number.</param>
        ''' <returns></returns>
        Public Shared Function GX_keyLED(ByVal List As keyLED_NoteEvents, ByVal NoteNumber As Integer) As Integer
            Select Case List

                Case keyLED_NoteEvents.NoteNumber_DrumRackLayout


                    '[Ableton LED To UniPack LED Convert CODE] [BETA!!]'
                    Select Case NoteNumber
                        'Position - Code Cleanup (v2.0)
                        Case 36 To 99
                            If NoteNumber >= 36 AndAlso NoteNumber <= 67 Then
                                Return Math.Ceiling((68 - NoteNumber) / 4)
                            ElseIf NoteNumber >= 68 AndAlso NoteNumber <= 99 Then
                                Return Math.Ceiling((100 - NoteNumber) / 4)
                            End If

                        'MC9 ~ MC32
                        Case 100 To 123
                            Return -8192

                        'MC1 ~ MC8
                        Case 28 To 35
                            Return -8192

                        'Logo Light / Mod Light
                        Case 27
                            Return -8193

                    End Select

                Case keyLED_NoteEvents.NoteNumber_XYLayout

                    Select Case NoteNumber
                        Case 81 To 88
                            Return 1

                        Case 71 To 78
                            Return 2

                        Case 61 To 68
                            Return 3

                        Case 51 To 58
                            Return 4

                        Case 41 To 48
                            Return 5

                        Case 31 To 38
                            Return 6

                        Case 21 To 28
                            Return 7

                        Case 11 To 18
                            Return 8

                        Case 89, 79, 69, 59, 49, 39, 29, 19
                            Return -8192

                    End Select

            End Select

            Return 0 'Exception
        End Function

        ''' <summary>
        ''' Get keyLED Position Y from MIDI Event.
        ''' </summary>
        ''' <param name="List">keyLED Algorithm List.</param>
        ''' <param name="NoteNumber">MIDI Note Number.</param>
        ''' <returns></returns>
        Public Shared Function GY_keyLED(ByVal List As keyLED_NoteEvents, ByVal NoteNumber As Integer) As Integer
            Select Case List

                Case keyLED_NoteEvents.NoteNumber_DrumRackLayout
                    '[Ableton LED To UniPack LED Convert CODE] [BETA!!]'
                    Select Case NoteNumber
                        'Position - Code Cleanup (v2.0)
                        Case 36 To 99
                            Dim addx As Integer = 0

                            If NoteNumber >= 68 AndAlso NoteNumber <= 99 Then
                                addx = 4
                            End If

                            Return (NoteNumber Mod 4) + addx + 1

                        'MC1 ~ MC8 [BETA]
                        Case 28 To 35
                            Return NoteNumber - 27

                        'MC9 ~ MC16
                        Case 100 To 107
                            Return NoteNumber - 91

                        'MC17 ~ MC32 [BETA]
                        Case 108 To 123
                            Return 140 - NoteNumber

                        'Logo Light / Mod Light
                        Case 27
                            Return 33
                    End Select

                Case keyLED_NoteEvents.NoteNumber_XYLayout

                    Select Case NoteNumber

                        Case 81, 71, 61, 51, 41, 31, 21, 11
                            Return 1

                        Case 82, 72, 62, 52, 42, 32, 22, 12
                            Return 2

                        Case 83, 73, 63, 53, 43, 33, 23, 13
                            Return 3

                        Case 84, 74, 64, 54, 44, 34, 24, 14
                            Return 4

                        Case 85, 75, 65, 55, 45, 35, 25, 15
                            Return 5

                        Case 86, 76, 66, 56, 46, 36, 26, 16
                            Return 6

                        Case 87, 77, 67, 57, 47, 37, 27, 17
                            Return 7

                        Case 88, 78, 68, 58, 48, 38, 28, 18
                            Return 8

                        Case 89
                            Return 1

                        Case 79
                            Return 2

                        Case 69
                            Return 3

                        Case 59
                            Return 4

                        Case 49
                            Return 5

                        Case 39
                            Return 6

                        Case 29
                            Return 7

                        Case 19
                            Return 8

                    End Select

            End Select

            Return 0 'Exception
        End Function

        ''' <summary>
        ''' Get Note Delay from NoteOnEvent's Note Length. (NAudio) [Ticks to Milliseconds]
        ''' </summary>
        ''' <param name="List">Note Events.</param>
        ''' <param name="bpm">Beats Per Minute.</param>
        ''' <param name="ppq">Pulses Per Quarter note.</param>
        ''' <param name="delay">Note Length from NoteOnEvent.</param>
        ''' <returns></returns>
        Public Shared Function GetNoteDelay(ByVal List As keyLED_NoteEvents, ByVal bpm As Integer, ByVal ppq As Integer, delay As Integer) As Integer
            Select Case List

                Case keyLED_NoteEvents.NoteLength_1
                    'Note Length: NL4Ticks, N2MS
                    Dim a As Integer = ppq * bpm
                    Dim b As Integer = Math.Round(60000 / a)
                    Return b * delay

                Case keyLED_NoteEvents.NoteLength_2
                    'Note Length to Milliseconds

                    Dim mills As Integer
                    Dim pqn As Integer

                    mills = 120 + (120 - bpm)
                    pqn = ppq / 96
                    Return Math.Round(mills * (delay / pqn / 24))

            End Select

            Return 0
        End Function

#Region "UniPack keyLED to NoteEvents"
        ''' <summary>
        ''' Get Note Number from UniPack keyLED.
        ''' </summary>
        ''' <param name="List">Note Events.</param>
        ''' <param name="x">UniPack X</param>
        ''' <param name="y">UniPack Y</param>
        ''' <returns></returns>
        Public Shared Function GetNoteNumber(ByVal List As keyLED_NoteEvents, ByVal x As Integer, ByVal y As Integer) As Integer
            If Not x = -8192 Then
                If x > 8 OrElse x < 1 Then
                    Throw New ArgumentException("x는 값이 항상 1~8 이여야 합니다.")
                End If
            End If

            If Not x = -8192 Then
                If y > 8 OrElse y < 1 Then
                    Throw New ArgumentException("y는 값이 항상 1~8 이여야 합니다.")
                End If
            Else
                If y < 1 OrElse y > 32 Then
                    Throw New ArgumentException("mc는 값이 항상 1~32 이여야 합니다.")
                End If
            End If

            Select Case List

                Case keyLED_NoteEvents.NoteLength_1

                    Select Case x

                        Case 1 To 8
                            Dim noteN As Integer = 64
                            noteN -= 4 * (x - 1)

                            If y >= 5 Then
                                noteN += 32 + (y - 5)
                            Else
                                noteN += y - 1
                            End If

                            Return noteN

                        Case -8192
                            Dim noteN As Integer
                            Select Case y
                                Case 1 To 8
                                    noteN = 27 + y
                                Case 9 To 32
                                    noteN = 91 + y
                            End Select

                            Return noteN
                    End Select

            End Select

            Return 0
        End Function
#End Region
    End Class

    Public Class keyLED
    End Class

    Public Class keySound

        Public Enum ks_NoteEvents

            ''' <summary>
            ''' Recieving Note Number. [ Drum Rack ]
            ''' </summary>
            NoteNumber_1

        End Enum

        Public Structure ksX
            Public x As Integer
            Public y As Integer
        End Structure

        ''' <summary>
        ''' Get keySound from keySound_X.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetkeySound(ByVal noteEvent As ks_NoteEvents, ByVal RecievingNoteNumber As Integer) As ksX

            Select Case noteEvent

                Case ks_NoteEvents.NoteNumber_1

                    Select Case RecievingNoteNumber
                        'x: 1, y: 1 ~ x: 1, y: 8
                        Case 64
                            Return Create_ksX(1, 1)
                        Case 63
                            Return Create_ksX(1, 2)
                        Case 62
                            Return Create_ksX(1, 3)
                        Case 61
                            Return Create_ksX(1, 4)
                        Case 32
                            Return Create_ksX(1, 5)
                        Case 31
                            Return Create_ksX(1, 6)
                        Case 30
                            Return Create_ksX(1, 7)
                        Case 29
                            Return Create_ksX(1, 8)

                            'x: 2, y: 1 ~ x: 2, y: 8
                        Case 68
                            Return Create_ksX(2, 1)
                        Case 67
                            Return Create_ksX(2, 2)
                        Case 66
                            Return Create_ksX(2, 3)
                        Case 65
                            Return Create_ksX(2, 4)
                        Case 36
                            Return Create_ksX(2, 5)
                        Case 35
                            Return Create_ksX(2, 6)
                        Case 34
                            Return Create_ksX(2, 7)
                        Case 33
                            Return Create_ksX(2, 8)

                            'x: 3, y: 1 ~ x: 3, y: 8
                        Case 72
                            Return Create_ksX(3, 1)
                        Case 71
                            Return Create_ksX(3, 2)
                        Case 70
                            Return Create_ksX(3, 3)
                        Case 69
                            Return Create_ksX(3, 4)
                        Case 40
                            Return Create_ksX(3, 5)
                        Case 39
                            Return Create_ksX(3, 6)
                        Case 38
                            Return Create_ksX(3, 7)
                        Case 37
                            Return Create_ksX(3, 8)

                            'x: 4, y: 1 ~ x: 4, y: 8
                        Case 76
                            Return Create_ksX(4, 1)
                        Case 75
                            Return Create_ksX(4, 2)
                        Case 74
                            Return Create_ksX(4, 3)
                        Case 73
                            Return Create_ksX(4, 4)
                        Case 44
                            Return Create_ksX(4, 5)
                        Case 43
                            Return Create_ksX(4, 6)
                        Case 42
                            Return Create_ksX(4, 7)
                        Case 41
                            Return Create_ksX(4, 8)

                            'x: 5, y: 1 ~ x: 5, y: 8
                        Case 80
                            Return Create_ksX(5, 1)
                        Case 79
                            Return Create_ksX(5, 2)
                        Case 78
                            Return Create_ksX(5, 3)
                        Case 77
                            Return Create_ksX(5, 4)
                        Case 48
                            Return Create_ksX(5, 5)
                        Case 47
                            Return Create_ksX(5, 6)
                        Case 46
                            Return Create_ksX(5, 7)
                        Case 45
                            Return Create_ksX(5, 8)

                            'x: 6, y: 1 ~ x: 6, y: 8
                        Case 84
                            Return Create_ksX(6, 1)
                        Case 83
                            Return Create_ksX(6, 2)
                        Case 82
                            Return Create_ksX(6, 3)
                        Case 81
                            Return Create_ksX(6, 4)
                        Case 52
                            Return Create_ksX(6, 5)
                        Case 51
                            Return Create_ksX(6, 6)
                        Case 50
                            Return Create_ksX(6, 7)
                        Case 49
                            Return Create_ksX(6, 8)

                            'x: 7, y: 1 ~ x: 7, y: 8
                        Case 88
                            Return Create_ksX(7, 1)
                        Case 87
                            Return Create_ksX(7, 2)
                        Case 86
                            Return Create_ksX(7, 3)
                        Case 85
                            Return Create_ksX(7, 4)
                        Case 56
                            Return Create_ksX(7, 5)
                        Case 55
                            Return Create_ksX(7, 6)
                        Case 54
                            Return Create_ksX(7, 7)
                        Case 53
                            Return Create_ksX(7, 8)

                            'x: 8, y: 1 ~ x: 8, y: 8
                        Case 92
                            Return Create_ksX(8, 1)
                        Case 91
                            Return Create_ksX(8, 2)
                        Case 90
                            Return Create_ksX(8, 3)
                        Case 89
                            Return Create_ksX(8, 4)
                        Case 60
                            Return Create_ksX(8, 5)
                        Case 59
                            Return Create_ksX(8, 6)
                        Case 58
                            Return Create_ksX(8, 7)
                        Case 57
                            Return Create_ksX(8, 8)
                    End Select

            End Select

            Return CreateNullksX()
        End Function

        ''' <summary>
        ''' Create the ksX with x and y.
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Shared Function Create_ksX(ByVal x As Integer, ByVal y As Integer) As ksX
            If x > 8 OrElse x < 1 Then
                Throw New ArgumentException("x는 값이 항상 1~8 이여야 합니다.")
            End If

            If y > 8 OrElse y < 1 Then
                    Throw New ArgumentException("y는 값이 항상 1~8 이여야 합니다.")
                End If

            Dim ks As New ksX
            ks.x = x
            ks.y = y
            Return ks
        End Function

        ''' <summary>
        ''' Create the ksX with null. (x: 0, y: 0)
        ''' </summary>
        ''' <returns></returns>
        Private Shared Function CreateNullksX() As ksX
            Dim ks As New ksX
            ks.x = 0
            ks.y = 0
            Return ks
        End Function

        Public Shared Function sLToTime(ByVal sL As Long) As TimeSpan
            '10000ms = 443366
            '1ms = 44
            Const l As Integer = 44
            Dim rT As Integer = Convert.ToInt32(sL / Convert.ToInt64(l))

            Dim rTime As TimeSpan = TimeSpan.FromMilliseconds(rT)
            Return rTime
        End Function
    End Class
End Class
