USE [SuperTheaterPro_Res]
go



/*
1 - API
2 - Android
3 - IOS
99 - 后台网站
*/


declare @PlatformType tinyint
set @PlatformType = 0 -- 目前系统扩展数据只针对一套程序因此不用考虑平台类型


/************ 1. 初始化扩展数据类型 *****************/

SET IDENTITY_INSERT [dbo].[SystemExtendTypeInfo] ON

-- 基础数据(1-9999)
insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(1,'PlatformType','平台类型','PlatformType',@PlatformType)

insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(2,'LanguageType','语言类型','LanguageType',@PlatformType)

insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(3,'ProgErrorRankType','业务错误级别','ProgErrorRankType',@PlatformType)

insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(4,'ProgErrorNotifyType','业务错误通知类型','ProgErrorNotifyType',@PlatformType)


-- 业务数据(10000-49999)
insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(10000,'UserStatus','用户状态','UserStatus',@PlatformType)

insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(10001,'SendLogType','发送日志类型','SendLogType',@PlatformType)



-- 订单数据(40000-49999)
insert into [dbo].[SystemExtendTypeInfo](ID,TypeCode,CnName,EnName,PlatformType)
values(40000,'OrderType','订单类型','OrderType',@PlatformType)


SET IDENTITY_INSERT [dbo].[SystemExtendTypeInfo] OFF

-- select * from [dbo].[SystemExtendTypeInfo]
-- truncate table [dbo].[SystemExtendTypeInfo]





/************ 2. 初始化扩展数据详细 *****************/

-- 平台类型
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(1,'1','API',NULL,@PlatformType) -- 2D12C3946B4B4821A4AF690749A1E276
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(1,'2','Android','AF0158484BB4428598B7F6096072DB93',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(1,'3','IOS','05AF9690986343D5801D1746C30E4FD6',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(1,'99','后台端',NULL,@PlatformType) -- D13F2D29773E47C98B96D2486FB8D65F

-- 语言类型
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(2,'1','简体中文','zh-cn',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(2,'2','英语美国','en-us',@PlatformType)

-- 业务错误级别
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(3,'1','一级','{"email":["79623784@qq.com"],"sms":["13301257936"]}',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(3,'2','二级','{"email":["79623784@qq.com"],"sms":["13301257936"]}',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(3,'3','三级','{"email":["79623784@qq.com"],"sms":["13301257936"]}',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(3,'4','四级','{"email":["79623784@qq.com"],"sms":["13301257936"]}',@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(3,'5','五级','{"email":["79623784@qq.com"],"sms":["13301257936"]}',@PlatformType)

-- 业务错误通知类型
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(4,'1','短信',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(4,'2','邮件',NULL,@PlatformType)



-- 用户状态
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(10000,'1','冻结',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(10000,'99','正常',NULL,@PlatformType)

-- 发送日志类型
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(10001,'1','短信',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(10001,'2','邮件',NULL,@PlatformType)






-- 订单类型
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(40000,'1','充值',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(40000,'2','提现',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(40000,'3','退款',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(40000,'50','购票',NULL,@PlatformType)
insert into [dbo].[SystemExtendTypeData_CN](TypeID,DataKey,DataValue,DataRemark,PlatformType)
values(40000,'200','活动',NULL,@PlatformType)


-- select * from [dbo].[SystemExtendTypeData_CN]
-- truncate table [dbo].[SystemExtendTypeData_CN]
-- select * from [dbo].[SystemExtendTypeInfo] a left join [dbo].[SystemExtendTypeData_CN] b on a.ID=b.TypeID order by a.ID








/*

truncate table [dbo].[SystemExtendTypeData_EN]
truncate table [dbo].[SystemExtendTypeData_CN]
truncate table [dbo].[SystemExtendTypeInfo]


DBCC CHECKIDENT ('[dbo].[SystemExtendTypeData_CN]', RESEED, 1) 

*/
















