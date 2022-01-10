﻿Module Wave
    Dim GainSpo2a As Double
    Dim GainSpo2b As Double
    Dim GainEcg1 As Double
    Dim GainEcg2 As Double
    Dim GainSet As Double = 5
    Dim MaxAxisXEcg As Double = 2000
    Dim MaxAxisXSpo2 As Double = 2000

    Sub SetMaxChart()
        Dashboard.Chart1.ChartAreas(0).AxisX.Maximum = MaxAxisXEcg
        Dashboard.Chart3.ChartAreas(0).AxisX.Maximum = MaxAxisXSpo2
        'Dashboard.Chart1.ChartAreas(0).AxisX.Minimum = MinAxisX
    End Sub
    Sub LineWaveSpo2(y1 As String)
        GainSpo2a = GainSpo2a + GainSet
        GainSpo2b = GainSpo2b + GainSet
        Dashboard.Chart3.Series("spo2a").Points.AddXY(GainSpo2a, (y1))

        'Line 1
        Select Case GainSpo2a
            Case MaxAxisXSpo2
                GainSpo2b = 0
                Dashboard.Chart3.Series("spo2a").Points.RemoveAt(0)
                Dashboard.Chart3.Series("spo2b").Points.Clear()
                'Debug.WriteLine("SWITCH 1")
        End Select

        Select Case GainSpo2a
            Case > MaxAxisXSpo2
                Dashboard.Chart3.Series("spo2a").Points.RemoveAt(0)
                Dashboard.Chart3.Series("spo2b").Points.AddXY(GainSpo2b, (y1))
                'Debug.WriteLine("SWITCH 2")
        End Select

        'Line 2
        Select Case GainSpo2b
            Case MaxAxisXSpo2
                GainSpo2a = 0
                Dashboard.Chart3.Series("spo2b").Points.RemoveAt(0)
                Dashboard.Chart3.Series("spo2a").Points.Clear()
                'Debug.WriteLine("SWITCH 3")
        End Select
        Select Case GainSpo2b
            Case > MaxAxisXSpo2
                Dashboard.Chart3.Series("spo2b").Points.RemoveAt(0)
                'Debug.WriteLine("SWITCH 4")
        End Select

    End Sub
    Sub LineWaveECG(y1 As Double)
        GainEcg1 = GainEcg1 + GainSet
        GainEcg2 = GainEcg2 + GainSet


        Dashboard.LabelA.Text = GainEcg1
        Dashboard.LabelB.Text = GainEcg2

        Dashboard.Chart1.Series("ecg1a").Points.AddXY(GainEcg1, (y1))

        'Line 1
        Select Case GainEcg1
            Case MaxAxisXEcg
                GainEcg2 = 0
                Dashboard.Chart1.Series("ecg1a").Points.RemoveAt(0)
                Dashboard.Chart1.Series("ecg1b").Points.Clear()
                'Debug.WriteLine("SWITCH 1")
        End Select

        Select Case GainEcg1
            Case > MaxAxisXEcg
                Dashboard.Chart1.Series("ecg1a").Points.RemoveAt(0)
                Dashboard.Chart1.Series("ecg1b").Points.AddXY(GainEcg2, (y1))
                'Debug.WriteLine("SWITCH 2")
        End Select

        'Line 2
        Select Case GainEcg2
            Case MaxAxisXEcg
                GainEcg1 = 0
                Dashboard.Chart1.Series("ecg1b").Points.RemoveAt(0)
                Dashboard.Chart1.Series("ecg1a").Points.Clear()
                'Debug.WriteLine("SWITCH 3")
        End Select
        Select Case GainEcg2
            Case > MaxAxisXEcg
                Dashboard.Chart1.Series("ecg1b").Points.RemoveAt(0)
                'Debug.WriteLine("SWITCH 4")
        End Select

    End Sub


End Module
