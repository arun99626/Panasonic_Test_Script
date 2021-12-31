#include <GDIPlus.au3>
#include <GUIConstantsEx.au3>
#include <MsgBoxConstants.au3>

_Example()

Func _Example()
    If Not _GDIPlus_Startup() Or @extended < 6 Then
		MsgBox($MB_SYSTEMMODAL, "ERROR", "GDIPlus.dll v1.1 not available")
		Return
	EndIf

	Local $hBitmap = _GDIPlus_BitmapCreateFromMemory(_RedEye())

	Local $iWidth = 600
	Local $iHeight = _GDIPlus_ImageGetHeight($hBitmap) * 600 / _GDIPlus_ImageGetWidth($hBitmap)

	Local $hGui = GUICreate("GDI+ v1.1 (" & @ScriptName & ")", $iWidth, $iHeight)
	Local $hGraphics = _GDIPlus_GraphicsCreateFromHWND($hGui)
	GUISetState(@SW_SHOW)

	Local $aAreas[3][4] = [[2]]
	$aAreas[1][0] = 50
	$aAreas[1][1] = 64
	$aAreas[1][2] = 22
	$aAreas[1][3] = 18

	$aAreas[2][0] = 155
	$aAreas[2][1] = 64
	$aAreas[2][2] = 21
	$aAreas[2][3] = 18

	Local $hEffect = _GDIPlus_EffectCreateRedEyeCorrection($aAreas)
	Local $hBitmap_FX = _GDIPlus_BitmapCreateApplyEffect($hBitmap, $hEffect)

	Local $iTimer = TimerInit(), $iStep = 0
	Do
		If TimerDiff($iTimer) > 400 Then
			Switch Mod($iStep, 2)
				Case 0
					_GDIPlus_GraphicsDrawImageRect($hGraphics, $hBitmap, 0, 0, $iWidth, $iHeight)
				Case Else
					_GDIPlus_GraphicsDrawImageRect($hGraphics, $hBitmap_FX, 0, 0, $iWidth, $iHeight)
			EndSwitch
			$iStep += 1
			$iTimer = TimerInit()
		EndIf
	Until GUIGetMsg() = $GUI_EVENT_CLOSE

	_GDIPlus_EffectDispose($hEffect)
	_GDIPlus_ImageDispose($hBitmap_FX)
	_GDIPlus_ImageDispose($hBitmap)
	_GDIPlus_GraphicsDispose($hGraphics)
	_GDIPlus_Shutdown()
EndFunc   ;==>_Example

; Code below was generated by: 'File to Base64 String' Code Generator v1.11 Build 2012-10-13
Func _RedEye($bSaveBinary = False)
	Local $sRedEye
	$sRedEye &= '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'
	$sRedEye &= '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'
	$sRedEye &= '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'
	$sRedEye &= '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'
	$sRedEye &= 'oLTITOkcxV1zMR1BJS6FxAMggimIMsly4SR8wmKzrp4+4f2sGIial0SmVqrYGY2qdtBzRmOB70KGtqlG+AaQ+xrSpkAZoTYLbO/mTHJO1OJXpOTBFVE0t+I1lVkWxvvS32Un2QdMWE28xsNqkWFfUeq3NoS7cMBNtqjUDn3qpNn3PXZ30q9beZQ60sFKtqXob8jZNwQmAZFVstQLcvApMmKR+iBHV1P3C2unsl7RusmE/Sjx/I8rTZDq120rToPINTs/sR8Np/Mec2BMCnCyaqAU7mYq2c6VE5IzPrSa6UrIB/mkYd0fMQJpKlDrViDgUjCuKIwTjgUGGdUQoJn0kU0++wr64RAPpvimzy6BnJEyMc9j/wAVri4+W/QFweI4olJVBiTRWWmUuwNAK4JCgPrEftNVA7YLMpGCoAZHHvUZN+M+tFQN5/aorqx7NGFYEcZqa0hgyoadJpKHM7gk4FIDkeVKTgmmn2JQdWMGR2pi9C2SNOo04yy36L7/AEuJUk5MVNvasZ0z7P8A6N0hf/tk9tqKLPoTfItL+2DflzxwaXtWONx7L0234BcNAeGdwBgVcZZXsR47mMGPSjQ8ppU6lV2PDJKUH5vbtT9FvdMOmN9PsGilISkRsNgai2NrhllFV04i7XptgVTuRgUvYxxsOumNBhoIMd6acjVpUiqiFTh0qnmitJ2pcURJI47UtqkCrUcgc9zSUoUomR259KAFdgEQJgzQAr51TjmZp+y9AnVaSEJwfWqkY53fYdKwlhzOIjV2EnH1rXH04c72Vu3S2nFJQec6hzWdt2JCfqzBZZ7DVO23b960xLL3YCs1gLMQIzjmlk14z61VpEDPes66cabW7kBIJ42AqWkMrdcAxEdqTTQxo5Sc/WkDBkyQcmmkU3uCKCtWOLCZ3iltGthHDKiRgmltpPWglyylwEKAIjkUHKXL6eEL1sah3AODStVMtTVMha62xr+aKuVz5e1RsztnNPaPGCEWf5agAB60rVToInp7ZXK06ozBqPt0+V9DbdlKT8okbUy2MSdJ2zRtFXtuYHFOVNixyFIJJqhLqh1zsPuaTTc+wroknGIoPYZxXIkwd6DDunyaeIyaC39hn3PmgASPpTRZoA+sgKKonseKqOfkv4C3EJ0TnVkg44n61rXJWavLhX4p0mVEmSRNYZZarfHHoT1R0uWzobSFypQPuMx+la4M+X/vIrQwpBnVM7/tRVYHlooxEzUV0Y2G1uoTvioaymVuoxuZ2E0mko5gmRJwaDM2VTjahmKQ4AN5o2VVOrzMZqbVYqyed6AiZJM8cUz2taQCRjNJGVGttpKIj9KuMrX3hxxinobWBseHPP8Aeke+wbqYXMDNRemsvSl19LbjaVTKsAxTt0vDC5S2LgrO0UqlJK4pbC8Lx6VUqUVq82aez+gziSTj2oPYR48Zg9jTOBFqkiSByZoOhn9iRsMY7U2VoF0AvQSkgEA/Srxc2d6DXylpWYASdMgRtxV2ucht2g+lThVEqxisNb7dmONs6ZD4P6i89069bfWta0veIVkzMiumyS9OG2+W6e4UsGIkgCOPKDtUVthTK0mTxmKixvKaW6sEZxUVriZMrIUJpVriPaOUig9mFucJ9aSbRBUYEUk7cnaeaBKiFSfQUj2mkSByfWmW1rf2EU5E0e2sBkECrnplfbhdEHFGzkSS7qSMR2o9wa0oeTmDzU2HMgq0hwDUNjik2xysfJKisgxAxUn9Jp3PtS2m1NKiFAb0wm4cA0ylDPKg01TsC6rWJ43FNfoK5kCQNJmnCtDkkygGABNNjnfsvcUUztG3rNaRz53ZX1G40NPOpEeQx6YoyvTKTt5v1jrvULbqLrNq8W2kQNMcwKMMJZtr/Uyx6j//2Q=='
	Local $dBinary = Binary(_Base64Decode($sRedEye))
	If $bSaveBinary Then
		Local $hFile = FileOpen(@ScriptDir & "\220px-BoldRedEye.JPG", 18)
		FileWrite($hFile, $dBinary)
		FileClose($hFile)
	EndIf
	Return $dBinary
EndFunc   ;==>_RedEye

Func _Base64Decode($sB64String)
	Local $tStruct = DllStructCreate("int")
	Local $a_Call = DllCall("Crypt32.dll", "int", "CryptStringToBinary", "str", $sB64String, "int", 0, "int", 1, "ptr", 0, "struct*", $tStruct, "ptr", 0, "ptr", 0)
	If @error Or Not $a_Call[0] Then Return SetError(1, 0, "")
	Local $tA = DllStructCreate("byte[" & DllStructGetData($tStruct, 1) & "]")
	$a_Call = DllCall("Crypt32.dll", "int", "CryptStringToBinary", "str", $sB64String, "int", 0, "int", 1, "struct*", $tA, "struct*", $tStruct, "ptr", 0, "ptr", 0)
	If @error Or Not $a_Call[0] Then Return SetError(2, 0, "")
	Return DllStructGetData($tA, 1)
EndFunc   ;==>_Base64Decode