# FlowFx

[![Twitter](https://img.shields.io/badge/Follow-Twitter?logo=twitter&color=white)](https://twitter.com/NullTale)
[![Discord](https://img.shields.io/badge/Discord-Discord?logo=discord&color=white)](https://discord.gg/CkdQvtA5un)
[![Boosty](https://img.shields.io/badge/Support-Boosty?logo=boosty&color=white)](https://boosty.to/nulltale)

Old school Image Flow Effect for Unity Urp, controlled via volume profile </br>
Works as render feature or a pass for selective post processing [VolFx](https://github.com/NullTale/VolFx)

![_cover](https://github.com/NullTale/FlowFx/assets/1497430/99ddc6d9-e727-4f3f-8b36-9f3d8ec5aebd)

## Part of Artwork Project

* [Vhs](https://github.com/NullTale/VhsFx)
* [OldMovie](https://github.com/NullTale/OldMovieFx)
* [GradientMap](https://github.com/NullTale/GradientMapFilter)
* [ScreenOutline](https://github.com/NullTale/OutlineFilter)
* [ImageFlow]
* [Pixelation](https://github.com/NullTale/PixelationFx)
* [Ascii](https://github.com/NullTale/AsciiFx)
* [Dither](https://github.com/NullTale/DitherFx)
* ...

## Usage
Install via Unity [PackageManager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
```
https://github.com/NullTale/FlowFx.git
```

Works as a `RenderFeature` blending each new frame with the previous one by weight,</br>
adding displacement and rotation, can be combined with other post effects to create scenes</br>
of confusion or strange flow.</br>

![image](https://github.com/NullTale/FlowFx/assets/1497430/d88917d2-5ca0-492c-96f1-4db7a7fc0722)

The feature is fps dependent and is rendered with target frame specified in the asset,</br>
this means that new frames for blending will be taken at the specified frame rate,</br>
if the frame rate is higher it does not affect the picture, otherwise the effect will look different.

Scene  from the documentation can be found in project samples.
  
