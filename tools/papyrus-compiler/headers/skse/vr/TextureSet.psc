Scriptname TextureSet extends Form Hidden


; SKSE 64 additions built 2020-07-01 22:24:50.239000 UTC

; Returns the number of texture paths
int Function GetNumTexturePaths() native

; Returns the path of the texture
string Function GetNthTexturePath(int n) native

; Sets the path of the texture
Function SetNthTexturePath(int n, string texturePath) native