Für Anbindung mit VBS ist keine eigene DLL notwendig.
Es ist jedoch ein aktives Alarmcontrol im WinCC nötig (Graphics Runtime).

Hinter der Eigenschaft "Activate_Trigger" wird folgendes Skript angebunden:

Function Activate_Trigger(ByVal Item)
'VBS355 
Dim objAlarmControl
Dim lIndex
Dim lCellIndex
Dim strJSONToSend
Dim URL
Dim ConditionName

Dim objXmlHttpMain
Set objXmlHttpMain = CreateObject("Msxml2.ServerXMLHTTP") 


'create reference to the alarm control
Set objAlarmControl = ScreenItems("Control1")

URL="http://192.168.52.1:50003/api/newevent"

'enumerate and trace out row numbers 
For lIndex = 1 To objAlarmControl.GetRowCollection.Count
HMIRuntime.trace "Row: " & (objAlarmControl.GetRow(lIndex).RowNumber) & " "
'enumerate and trace out column titles and cell texts
For lCellIndex = 1 To objAlarmControl.GetRow(lIndex).CellCount

HMIRuntime.trace objAlarmControl.GetMessageColumn(lCellIndex -1).Name & " "
HMIRuntime.trace objAlarmControl.GetRow(lIndex).CellText(lCellIndex) & " "

If lCellIndex = 1 Then
strJSONToSend = "{""ConditionName"": """ & objAlarmControl.GetRow(lIndex).CellText(0) & """}"
HMIRuntime.trace strJSONToSend
End If

On Error Resume Next   'enable error handling
objXmlHttpMain.open "POST",URL, False
objXmlHttpMain.setRequestHeader "Content-Type", "application/json"
objXmlHttpMain.send strJSONToSend
If Err Then            'handle errors
  HMIRuntime.trace Err.Description & " [0x" & Hex(Err.Number) & "]"
End If
On Error Goto 0        'disable error handling again

Next
HMIRuntime.trace vbNewLine
Next

Set objJSONDoc = Nothing 
Set objResult = Nothing

End Function