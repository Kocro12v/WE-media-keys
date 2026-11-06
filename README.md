# WE Media Keys

三个极小的 Windows 媒体键发送工具，用于 **Wallpaper Engine 场景壁纸**的播放控制按钮（用户快捷方式 / User Shortcut）。

点击按钮 → 发送一次系统媒体键 → 网易云、QQ 音乐、Spotify 等播放器响应。

## 文件

| 文件 | 作用 | 键码 |
|---|---|---|
| `WEPrev.exe` | 上一曲 | `VK_MEDIA_PREV_TRACK` (0xB1) |
| `WEPlay.exe` | 播放 / 暂停 | `VK_MEDIA_PLAY_PAUSE` (0xB3) |
| `WENext.exe` | 下一曲 | `VK_MEDIA_NEXT_TRACK` (0xB0) |

启动耗时约 0.03 秒，无窗口、无控制台、无网络请求。

## 用法

1. 把三个 exe 放到任意**固定目录**（例如 `D:\WallpaperTools\`），路径中避免中文和空格。
2. 在 Wallpaper Engine 主界面选中壁纸，右侧属性栏找到对应的三个「用户快捷方式」。
3. 每一项选择 **文件**，分别指向 `WEPrev.exe` / `WEPlay.exe` / `WENext.exe`。
4. 点击壁纸上的按钮测试。

> 注意：快捷方式绑定单机、不随壁纸预设分发，换电脑需要重新配置。

## 校验

```
be50f05da118d5d4f083b20d6454ba9521722759b69ad718e69fae9480e4c2f8  WEPrev.exe
0c82ed9b4f5e874751f43360522885918465b4f7d32a07e136681188330d0c6f  WEPlay.exe
d9fbf0253029f5b6df2e6ae015ff062a67a4b4d24cffee0353ad6d1baec480c6  WENext.exe
```

PowerShell 校验：

```powershell
Get-FileHash .\WEPrev.exe, .\WEPlay.exe, .\WENext.exe -Algorithm SHA256 |
  Format-Table Hash, Path -AutoSize
```

## 自行编译

源码在 `src/`，用 Windows 自带的 .NET Framework 编译器即可，不需要安装任何 SDK：

```bat
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /optimize+ /out:WEPlay.exe src\WEPlay.cs
```

三个文件同理。编译产物与 Release 中的 exe 功能一致（哈希可能因编译时间戳不同而不同）。

## 安全说明

程序只调用 `user32.dll` 的 `keybd_event`，发送一次按键按下 + 抬起。

- 不联网、不读写文件、不修改注册表
- 不注入其他进程、不申请管理员权限
- 全部逻辑就是 `src/` 里的二十来行代码

部分杀毒软件会对任何模拟按键的程序做启发式报警，这是行为特征导致的误报，可以对照源码自行编译验证。

## 已知限制

- 只支持 Windows（依赖 Win32 媒体键）。
- 播放器需要支持系统媒体键（网易云、QQ 音乐需在设置里开启全局快捷键/媒体键）。
- 这是壁纸的可选辅助工具；不安装也不影响壁纸本身的显示。

## License

MIT
