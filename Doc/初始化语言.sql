USE [SuperTheaterPro_Res]
go



/*
1 - API
2 - Android
3 - IOS
99 - 后台网站
*/


declare @PlatformType tinyint
set @PlatformType = 1

-- BASIC(1-199999、900000-999999)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('200','OK',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('100001','未授权的访问',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('100002','客户端语言设置错误',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('100003','客户端识别码设置错误',@PlatformType)
INSERT into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('999996','参数错误',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('999997','服务器内部错误，请联系客服',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('999998','服务器内部错误，请稍候重试',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('999999','未知错误',@PlatformType)

-- PROG(200000-599999)  - 每个业务接口100个数字
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('200000','用户令牌有效',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('200001','用户令牌无效',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('200002','用户令牌已超时',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('200003','用户令牌已失效',@PlatformType)

-- MODEL(600000-899999) - 每个实体模型100个数字
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('600100','类型不正确',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('600101','类型不正确',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('600102','用户令牌无效',@PlatformType)
insert into ProgStringInfo_CN(StringKey,StringValue,PlatformType) values('600103','用户令牌无效',@PlatformType)


-- UI(1000000-...)

go



/*

select * from ProgStringInfo_CN
select * from ProgStringInfo_EN


truncate table ProgStringInfo_CN
truncate table ProgStringInfo_EN

*/












