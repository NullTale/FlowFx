# FlowFx

Old school Image Flow effect or pixel blur for Unity Urp, </br>
Controlled via volume profile, works as render feature

![_cover](https://github.com/NullTale/FlowFx/assets/1497430/99ddc6d9-e727-4f3f-8b36-9f3d8ec5aebd)

## Usage
Install via Unity [PackageManager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
```
https://github.com/NullTale/FlowFx.git
```

It works as a `RenderFeature` blending each new frame with the previous one by weight,</br>
adding displacement and rotation, can be combined with other post effects to create scenes</br>
of confusion or strange flow.</br>

![image](https://github.com/NullTale/FlowFx/assets/1497430/d88917d2-5ca0-492c-96f1-4db7a7fc0722)

The feature is fps dependent and is rendered with target frame specified in the asset,</br>
this means that new frames for blending will be taken at the specified frame rate,</br>
if the frame rate is higher it does not affect the picture, if it is lower the effect will not be the same.

Scene  from the documentation can be found in project samples.
