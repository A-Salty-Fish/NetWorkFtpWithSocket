# 计算机网络实验大作业：简单的使用Socket实现的Ftp客户端
![GitHub top language](https://img.shields.io/github/languages/top/A-Salty-Fish/NetWorkFtpWithSocket)
![GitHub](https://img.shields.io/github/license/A-Salty-Fish/NetWorkFtpWithSocket)
![GitHub repo size](https://img.shields.io/github/repo-size/A-Salty-Fish/NetWorkFtpWithSocket)
![GitHub contributors](https://img.shields.io/github/contributors/A-Salty-Fish/NetWorkFtpWithSocket)
![GitHub last commit](https://img.shields.io/github/last-commit/A-Salty-Fish/NetWorkFtpWithSocket)

## 开发环境
* Windows 10
* Internet Information Services 提供的 FtpSite
* Visual Studio 2019
* .Net Framework 4.7.2
* Winform样式库: CSkin

## 功能
* 登录Ftp服务器
* 获取Ftp服务器扩展信息
* 上传本地文件
* 下载Ftp服务器中的文件
* 支持简单的断点续传

## 注意事项
* 由于Ftp坑爹的编码规则，导致在存在中文文件名时，上传下载文件需要打开服务器的UTF-8设置，而在获取服务器文件名列表时又需要关闭UTF-8设置。
* 由于断点续传基于简单文件大小的判断，如果在下载\上传时将本地\服务器上的文件删去一部分，会导致启动断点续传，而造成文件内容的不可控制。
* 懒得修一个前端bug，该bug导致勾选文件大小与刷新按钮的互动不正常

## 缺陷
* 没有完成删除Ftp服务器上的文件的功能
* 基于简单文件大小判断的断点续传导致不能随意修改本地和云端上的文件
* 有一部分异常处理没有写
* 前端交互bug比较多，懒得写前端注释

## 参考资料
https://www.ibm.com/developerworks/cn/linux/l-cn-socketftp/index.html
https://blog.csdn.net/qq_21882325/article/details/73302959