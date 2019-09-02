'Made By MineEric64 (최에릭)
'[BETA] This is Open Project. So you can build this Project!

''' <summary>
''' Ableton to UniPack Project.
''' </summary>
Public Class A2U

    ''' <summary>
    ''' The Functions about keyLED (MIDI Extension).
    ''' </summary>
    Public Class keyLED_MIDEX

        ''' <summary>
        ''' NEW UX2A of keyLED (MIDI Extension) Note Events.
        ''' </summary>
        Public Enum keyLED_NoteEvents
            ''' <summary>
            ''' Launchpad LED's Note Number.
            ''' </summary>
            NoteNumber_1

            ''' <summary>
            ''' Launchpad MIDI In's Note Number.
            ''' </summary>
            NoteNumber_2



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
        ''' Get Version from A2UP.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetVersion() As Version
            Return New Version("1.2.4.0")
        End Function

        ''' <summary>
        ''' Get keyLED Position X from MIDI Event.
        ''' </summary>
        ''' <param name="List">keyLED Algorithm List.</param>
        ''' <param name="NoteNumber">MIDI Note Number.</param>
        ''' <returns></returns>
        Public Shared Function GX_keyLED(ByVal List As keyLED_NoteEvents, ByVal NoteNumber As Integer) As Integer
            Select Case List

                Case keyLED_NoteEvents.NoteNumber_1


                    '[Ableton LED To UniPack LED Convert CODE] [BETA!!]'
                    Select Case NoteNumber
                    'Postion X: 1
                        Case 64, 65, 66, 67, 96, 97, 98, 99
                            Return 1

                        'Position X: 2
                        Case 60, 61, 62, 63, 92, 93, 94, 95
                            Return 2

                        'Position X: 3
                        Case 56, 57, 58, 59, 88, 89, 90, 91
                            Return 3

                        'Position X: 4
                        Case 52, 53, 54, 55, 84, 85, 86, 87
                            Return 4

                        'Position X: 5
                        Case 48, 49, 50, 51, 80, 81, 82, 83
                            Return 5

                        'Position X: 6
                        Case 44, 45, 46, 47, 76, 77, 78, 79
                            Return 6

                        'Position X: 7
                        Case 40, 41, 42, 43, 72, 73, 74, 75
                            Return 7

                        'Position X: 8
                        Case 36, 37, 38, 39, 68, 69, 70, 71
                            Return 8

                        'MC9 ~ MC16
                        Case 100 To 107
                            Return -8192

                        'MC17 ~ MC32 [BETA]
                        Case 108 To 123
                            Return -8192

                        'MC1 ~ MC8 [BETA]
                        Case 28 To 35
                            Return -8192

                    End Select

                Case keyLED_NoteEvents.NoteNumber_2

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

                Case keyLED_NoteEvents.NoteNumber_1
                    '[Ableton LED To UniPack LED Convert CODE] [BETA!!]'
                    Select Case NoteNumber
                    'Position Y: 1
                        Case 64, 60, 56, 52, 48, 44, 40, 36
                            Return 1

                        'Position Y: 2
                        Case 65, 61, 57, 53, 49, 45, 41, 37
                            Return 2

                        'Position Y: 3
                        Case 66, 62, 58, 54, 50, 46, 42, 38
                            Return 3

                        'Position Y: 4
                        Case 67, 63, 59, 55, 51, 47, 43, 39
                            Return 4

                        'Position Y: 5
                        Case 96, 92, 88, 84, 80, 76, 72, 68
                            Return 5

                        'Position Y: 6
                        Case 97, 93, 89, 85, 81, 77, 73, 69
                            Return 6

                        'Position Y: 7
                        Case 98, 94, 90, 86, 82, 78, 74, 70
                            Return 7

                        'Position Y: 8
                        Case 99, 95, 91, 87, 83, 79, 75, 71
                            Return 8

                        'MC9 ~ MC16
                        Case 100
                            Return 9
                        Case 101
                            Return 10
                        Case 102
                            Return 11
                        Case 103
                            Return 12
                        Case 104
                            Return 13
                        Case 105
                            Return 14
                        Case 106
                            Return 15
                        Case 107
                            Return 16

                        'MC17 ~ MC32 [BETA]
                        Case 108
                            Return 17
                        Case 109
                            Return 18
                        Case 110
                            Return 19
                        Case 111
                            Return 20
                        Case 112
                            Return 21
                        Case 113
                            Return 22
                        Case 114
                            Return 23
                        Case 115
                            Return 24
                        Case 116
                            Return 25
                        Case 117
                            Return 26
                        Case 118
                            Return 27
                        Case 119
                            Return 28
                        Case 120
                            Return 29
                        Case 121
                            Return 30
                        Case 122
                            Return 31
                        Case 123
                            Return 32

                        'MC1 ~ MC8 [BETA]
                        Case 28
                            Return 1
                        Case 29
                            Return 2
                        Case 30
                            Return 3
                        Case 31
                            Return 4
                        Case 32
                            Return 5
                        Case 33
                            Return 6
                        Case 34
                            Return 7
                        Case 35
                            Return 8

                    End Select

                Case keyLED_NoteEvents.NoteNumber_2

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
                    '[24ticks] Members
                    '110BPM: 130ms
                    '120BPM: 120ms
                    '128BPM: 110ms
                    '130BPM: 110ms

                    Dim mills As Integer = 1000
                    Dim pqn As Integer
                    Select Case bpm
                        Case 110
                            mills = 130
                        Case 120
                            mills = 120
                        Case 128, 130
                            mills = 110
                    End Select

                    Select Case ppq
                        Case 96
                            pqn = 1
                        Case 192
                            pqn = 2
                        Case Else
                            pqn = ppq / 96
                    End Select

                    Return Math.Round(mills * (delay / pqn / 24))

            End Select

            Return 0
        End Function
    End Class

    Public Class keyLED
    End Class
End Class
