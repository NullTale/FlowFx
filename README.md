# FlowFx

Old school Image Flow effect or pixel blur for Unity Urp, </br>
Controlled via volume profile, works as render feature
![_cover](https://github.com/NullTale/FlowFx/assets/1497430/08642a3a-f050-4d9c-b835-e0d37cf02f23)

## Usage
Install via Unity [PackageManager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
```
https://github.com/NullTale/FlowFx.git
```

It works as a `RenderFeature` blending each new frame with the previous one by weight,</br>
adding displacement and rotation, can be combined with other post effects to create scenes</br>
of confusion or strange flow.</br>

![image](https://github.com/NullTale/FlowFx/assets/1497430/ec20ecb2-0eb7-45be-9792-99990c868f94)

The feature is fps dependent and is rendered with target frame specified in the asset,</br>
this means that new frames for blending will be taken at the specified frame rate,</br>
if the frame rate is higher it does not affect the picture, if it is lower the effect will not be the same.

Scene  from the documentation can be found in project samples.
