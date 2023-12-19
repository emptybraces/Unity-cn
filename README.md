# Unity_cn
Custom Logger, easy, shortname, minimum.

# Install
Intall via Unity Package Manager:

```
https://github.com/emptybraces/Unity_cn.git?path=UPM
```

## Samples
~~~
cn.log();
cn.log(this);
cn.log("cn.log");
cn.logf("1", "2", "3", "4");

cn.PushLogger(_loggerUI);
cn.PushLogger(_loggerFile);

cn.logw();
cn.logw(this);
cn.logw("cn.logw");
cn.logwf("1", "2", "3", "4");

cn.loge();
cn.loge(this);
cn.loge("cn.loge");
cn.logef("1", "2", "3", "4", Vector3.up);
cn.PopLogger();

cn.logBlue();
cn.logBlue(this);
cn.logBlue("logBlue");
cn.logBluef("1", "2", "3", "4");

cn.logGreen();
cn.logGreen(this);
cn.logGreen("logGreen");
cn.logGreenf("1", "2", "3", "4", Vector3.up);

cn.logmem(Vector3.one);
cn.logmem(this, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.FlattenHierarchy);

cn.LogEnable(false);
cn.logGreen("not show");
cn.LogEnable(true);
cn.PopLogger();
~~~
![スクリーンショット 2023-03-10 181342](https://user-images.githubusercontent.com/1441835/224276131-fa2d5804-eaa1-494b-bc0a-baedb52bf926.png)

## No Namespace, Simple method group.
- cn.log() prints the framecount, filename and the number of lines called.
- cn.log(arg1, arg2...) prints the framecount and arguments.
- cn.logf(...) prints the framecount, filename and the function name that was called.
- cn.logw, cn.logwf are warning log type version.
- cn.loge, cn.logef are error log type version.

## DLL ready, for jump to called source by double click the console.
