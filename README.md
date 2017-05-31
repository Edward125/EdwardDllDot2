# EdwardDllDot2
[![Travis](https://img.shields.io/travis/rust-lang/rust.svg)]()
[![Packagist](https://img.shields.io/badge/Packagist-v1.0.2.0-brightgreen.svg)]()
[![Framework](https://img.shields.io/badge/Framework-DotNet2-brightgreen.svg)]()

## 历史版本
### v1.0.2.0 
1.  增加了SplashForm
***
使用方法：
    在Sub Main 中添加代码
    
     SplashForm.StartSplash(@".\splash.bmp", Color.FromArgb(128, 128, 128));  '
    // simulating operations at startup '
    System.Threading.Thread.Sleep(1000); '
    // close the splash screen'
    SplashForm.CloseSplash();
