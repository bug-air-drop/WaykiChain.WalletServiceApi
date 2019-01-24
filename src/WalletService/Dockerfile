
FROM microsoft/dotnet:2.2-aspnetcore-runtime

#拷贝项目publish文件夹中的所有文件到 docker容器中的publish文件夹中  
COPY /publish /publish

#设置工作目录为 `/publish` 文件夹，即容器启动默认的文件夹
WORKDIR /publish

#设置Docker容器对外暴露6999端口
EXPOSE 6999

#使用`dotnet HelloWebApp.dll`来运行应用程序
ENTRYPOINT ["dotnet", "WalletServiceApi.dll","--urls","http://*:6999"]