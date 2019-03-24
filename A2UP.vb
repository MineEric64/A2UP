Public Class A2UP
    'Made By MineEric64 (최에릭)
    '[BETA] This is Open Project. So You Can Build this Project!

    Public Enum keyLED_AC
        ''' <summary>
        ''' Changing Note Number (64 to x1 y1).
        ''' </summary>
        NoteNumber1
    End Enum

    ''' <summary>
    ''' Get keyLED Position X. (Supports Only MK2)
    ''' </summary>
    ''' <param name="List">keyLED Algorithm List.</param>
    ''' <param name="NoteNumber">MIDI Note Number.</param>
    ''' <returns></returns>
    Public Function GX_keyLED(ByVal List As keyLED_AC, ByVal NoteNumber As Integer) As Integer
        Select Case List
            Case keyLED_AC.NoteNumber1
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
                    Case 52, 53, 54, 55, 85, 86, 87
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
                End Select
        End Select

        Return 0 'Exception
    End Function

    ''' <summary>
    ''' Get keyLED Position Y. (Supports Only MK2)
    ''' </summary>
    ''' <param name="List">keyLED Algorithm List.</param>
    ''' <param name="NoteNumber">MIDI Note Number.</param>
    ''' <returns></returns>
    Public Function GY_keyLED(ByVal List As keyLED_AC, ByVal NoteNumber As Integer) As Integer
        Select Case List
            Case keyLED_AC.NoteNumber1
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
                    Case 100 To 107
                        Return 8192
                End Select
        End Select
        Return 0 'Exception
    End Function
End Class
