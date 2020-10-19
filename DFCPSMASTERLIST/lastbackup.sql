/*
 Navicat Premium Data Transfer

 Source Server         : generalLedgerDB
 Source Server Type    : SQL Server
 Source Server Version : 10001600
 Source Host           : dfarm3:1433
 Source Catalog        : DFCPSMASTERLISTDB
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 10001600
 File Encoding         : 65001

 Date: 09/11/2018 11:21:50
*/


-- ----------------------------
-- Table structure for tblBenefitsPaymentSum
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBenefitsPaymentSum]') AND type IN ('U'))
	DROP TABLE [dbo].[tblBenefitsPaymentSum]
GO

CREATE TABLE [dbo].[tblBenefitsPaymentSum] (
  [premsID] int  IDENTITY(1,1) NOT NULL,
  [payrollID] varchar(50) COLLATE Latin1_General_CI_AS  NULL,
  [empPayrollTransNo] int  NULL,
  [erSSS] money  NULL,
  [erPI] money  NULL,
  [erPH] money  NULL
)
GO

ALTER TABLE [dbo].[tblBenefitsPaymentSum] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblBenefitsPaymentSum
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tblBenefitsPaymentSum] ON
GO

INSERT INTO [dbo].[tblBenefitsPaymentSum] ([premsID], [payrollID], [empPayrollTransNo], [erSSS], [erPI], [erPH]) VALUES (N'133', N'PR-00002', N'206', N'.0000', N'.0000', N'.0000')
GO

INSERT INTO [dbo].[tblBenefitsPaymentSum] ([premsID], [payrollID], [empPayrollTransNo], [erSSS], [erPI], [erPH]) VALUES (N'134', N'PR-00003', N'207', N'820.3000', N'100.0000', N'151.7700')
GO

INSERT INTO [dbo].[tblBenefitsPaymentSum] ([premsID], [payrollID], [empPayrollTransNo], [erSSS], [erPI], [erPH]) VALUES (N'135', N'PR-00004', N'208', N'304.7000', N'100.0000', N'137.5000')
GO

SET IDENTITY_INSERT [dbo].[tblBenefitsPaymentSum] OFF
GO


-- ----------------------------
-- Table structure for tblChildrenInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblChildrenInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[tblChildrenInfo]
GO

CREATE TABLE [dbo].[tblChildrenInfo] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [employeeID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [lastname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [firstname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [middlename] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblChildrenInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblDesciplinaryAction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDesciplinaryAction]') AND type IN ('U'))
	DROP TABLE [dbo].[tblDesciplinaryAction]
GO

CREATE TABLE [dbo].[tblDesciplinaryAction] (
  [descActionNo] varchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [date] datetime2(7)  NULL,
  [employeeID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [typeofViolation] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [actionTaken] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [punishDateFrom] datetime2(7)  NULL,
  [punishDateTo] datetime2(7)  NULL,
  [detailsofincrement] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [preparedby] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblDesciplinaryAction] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblEmployeesInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmployeesInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[tblEmployeesInfo]
GO

CREATE TABLE [dbo].[tblEmployeesInfo] (
  [employeeID] varchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [lastname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [firstname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [middlename] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [address] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [contactNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [homeNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [religion] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [gender] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [birthdate] datetime2(7)  NULL,
  [civilstatus] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [department] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [division] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [position] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [rate] money  NULL,
  [grade] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [payMethod] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [dateHired] datetime2(7)  NULL,
  [workingStatus] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [field] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [sssNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [tinNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [piNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [phNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [allowBenefitsDeduction] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [remarks] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblEmployeesInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblEmployeesInfo
-- ----------------------------
INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00001', N'BALADIANG', N'MARVIN', N'', N'LAGAO, GENERAL SANTOS CITY', N'Single', N'', N'CATHOLIC', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'IT', N'', N'LAYOUT ARTIST', N'9100.0000', N'1', N'Monthly', N'2017-10-01 00:00:00.0000000', N'Regular', N'15 Days', N'0934530426', N'', N'121175189393', N'170502911131', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00002', N'CABANGAL', N'RENZ EDRYAN', N'', N'GENSAN VILLE, GENERAL SANTOS CITY', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ACCOUNTING', N'11500.0000', N'', N'Monthly', N'2018-08-31 00:00:00.0000000', N'Regular', N'15 Days', N'0942461671', N'', N'121198759679', N'170255677988', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00003', N'DELA SERNA', N'ELVIRA', N'', N'APOPONG, GENERAL SANTOS CITY', N'Married', N'', N'', N'Female', N'2018-08-31 00:00:00.0000000', N'Married', N'', N'', N'HR', N'15000.0000', N'', N'Monthly', N'2018-08-31 00:00:00.0000000', N'Regular', N'15 Days', N'0914888855', N'', N'111', N'1111', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00004', N'DUMAGO', N'RODMAR', N'', N'GREENVILLE, CALUMPANG, GENERAL SANTOS CITY', N'Single', N'', N'NONE', N'Male', N'1996-06-19 00:00:00.0000000', N'Single', N'IT', N'', N'MIS', N'15000.0000', N'1', N'Monthly', N'2018-08-31 00:00:00.0000000', N'Regular', N'15 Days', N'0940834569', N'', N'121174769816', N'170504061720', N'Yes', N'Updated Last 10/30/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00005', N'LACOTO', N'NORODEN', N'', N'', N'Single', N'', N'MUSLIM', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ACCOUNTING', N'11500.0000', N'', N'Monthly', N'2018-08-31 00:00:00.0000000', N'Regular', N'15 Days', N'0941732495', N'', N'121116701904', N'172508720701', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00006', N'ESCALANTE', N'ALVIN', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Regular', N'15 Days', N'0928241048', N'', N'914050007606', N'170501678972', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00007', N'TERRADO', N'JERUEL', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'', N'17000.0000', N'', N'Monthly', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0926776793', N'', N'121075748943', N'170501411216', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00008', N'MACADINI', N'ROMEO JR.', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Regular', N'15 Days', N'0922663761', N'', N'121030144432', N'170502526742', N'Yes', N'Updated Last 09/04/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00009', N'VIRTUDAZO', N'JUDEL', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'395.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Inactive', N'15 Days', N'', N'', N'', N'', N'Yes', N'Updated Last 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00010', N'MAZO', N'RENATO', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'400.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0928174267', N'', N'121064001665', N'170252428197', N'Yes', N'Updated Last 09/04/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00011', N'OTERO', N'SOL', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'400.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0919089905', N'', N'121115390569', N'170500516111', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00012', N'DELLOSA', N'ALJUNE RAY', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'400.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0931536944', N'', N'121064840499', N'170502247584', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00013', N'JORING', N'JHON', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0942641381', N'', N'121202037155', N'172017593760', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00014', N'PALERO', N'DEXTER', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'12000.0000', N'', N'Monthly', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0929204880', N'', N'070505360417', N'121133555265', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00015', N'ABALLE', N'JASON', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0936546078', N'', N'121155622459', N'465101394', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00016', N'SOLIMINIANO', N'JAY', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'400.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0915404461', N'', N'121147528297', N'190900548935', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00017', N'MALINAO', N'RYAN', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'0933338920', N'', N'12189137870', N'170503224448', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00018', N'SINOY', N'ADONIS', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'400.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'062502300', N'', N'103000138440', N'120503535829', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00019', N'TINAY', N'GERON', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'000922689253', N'', N'121021069698', N'170501022694', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00020', N'GARPIA', N'NELMAR', N'', N'', N'Single', N'', N'', N'Male', N'2018-08-31 00:00:00.0000000', N'Single', N'', N'', N'ELECTRICIAN', N'350.0000', N'', N'Daily', N'2018-08-31 00:00:00.0000000', N'Probationary', N'15 Days', N'011133910846', N'', N'121134366597', N'170502789670', N'Yes', N'Updated Last 09/03/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00021', N'BIÑAN', N'DEVINE', N'', N'', N'Single', N'', N'', N'Female', N'2018-09-03 00:00:00.0000000', N'Single', N'', N'', N'', N'9500.0000', N'', N'Monthly', N'2018-09-03 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Updated Last 09/22/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00022', N'CABAJAR', N'ROBERT', N'', N'', N'', N'', N'', N'Male', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'DRIVER', N'350.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00023', N'RODRIGUEZ', N'JOSHUA', N'', N'', N'', N'', N'', N'Male', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'310.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00024', N'DIZON', N'VIRGINIA', N'', N'', N'Single', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Updated Last 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00025', N'ABDULLAH', N'NORHAINE', N'', N'', N'Single', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Updated Last 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00026', N'ALBEDA', N'JOANNIE', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00027', N'ATES', N'JESSA', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00028', N'ATIS', N'ROXANNE', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00029', N'ATIS', N'JANICE', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00030', N'GOROSFE', N'SHIENNA', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00031', N'LAVIÃ‘A', N'LEAH', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00032', N'LUNZAGA', N'FERY GWEN', N'', N'', N'', N'', N'', N'Female', N'2018-09-17 00:00:00.0000000', N'Single', N'', N'', N'OPERATOR', N'311.0000', N'', N'Daily', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'', N'Employees Info Added 09/17/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00033', N'FERRAN', N'ZALDY', N'', N'', N'', N'', N'', N'Male', N'2018-10-04 00:00:00.0000000', N'Married', N'', N'', N'OPERATOR', N'54000.0000', N'', N'Monthly', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'No', N'Employees Info Added 10/04/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00034', N'PANGILINAN', N'ARMIN', N'', N'', N'', N'', N'', N'Male', N'2018-10-04 00:00:00.0000000', N'Married', N'', N'', N'OPERATOR', N'45000.0000', N'', N'Monthly', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'No', N'Employees Info Added 10/04/2018')
GO

INSERT INTO [dbo].[tblEmployeesInfo]  VALUES (N'EMP-00035', N'GUMARO', N'NOEL', N'', N'', N'', N'', N'', N'Male', N'2018-10-04 00:00:00.0000000', N'Married', N'', N'', N'OPERATOR', N'42000.0000', N'', N'Monthly', N'2018-09-17 00:00:00.0000000', N'Probationary', N'15 Days', N'', N'', N'', N'', N'No', N'Employees Info Added 10/04/2018')
GO


-- ----------------------------
-- Table structure for tblLeave
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLeave]') AND type IN ('U'))
	DROP TABLE [dbo].[tblLeave]
GO

CREATE TABLE [dbo].[tblLeave] (
  [leaveNo] varchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [dateFilled] datetime2(7)  NULL,
  [employeeID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [leaveType] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [reason] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [dateFrom] datetime2(7)  NULL,
  [dateTo] datetime2(7)  NULL,
  [totalDays] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [withpay] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [remarks] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblLeave] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblPayroll
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPayroll]') AND type IN ('U'))
	DROP TABLE [dbo].[tblPayroll]
GO

CREATE TABLE [dbo].[tblPayroll] (
  [payrollID] varchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [dateCreated] datetime2(7)  NULL,
  [dateFrom] datetime2(7)  NULL,
  [dateTo] datetime2(7)  NULL,
  [totalEmployees] int  NULL,
  [totalOvertime] money  NULL,
  [totalGrossPay] money  NULL,
  [totalDeduction] money  NULL,
  [totalNetpay] money  NULL,
  [preparedBy] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [remarks] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblPayroll] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblPayroll
-- ----------------------------
INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00001', N'2018-09-17 00:00:00.0000000', N'2018-09-01 00:00:00.0000000', N'2018-09-15 00:00:00.0000000', N'30', N'330.0000', N'121399.9800', N'.0000', N'121399.9800', N'Rodmar A. Dumago', N'Admin')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00002', N'2018-10-30 00:00:00.0000000', N'2018-10-01 00:00:00.0000000', N'2018-10-15 00:00:00.0000000', N'1', N'359.4200', N'7831.8700', N'.0000', N'7831.8700', N'Noroden E. Lacoto', N'Admin')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00003', N'2018-10-30 00:00:00.0000000', N'2018-09-16 00:00:00.0000000', N'2018-09-30 00:00:00.0000000', N'1', N'.0000', N'7482.0300', N'651.4700', N'6830.5600', N'Noroden E. Lacoto', N'Admin')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00004', N'2018-11-05 00:00:00.0000000', N'2018-10-16 00:00:00.0000000', N'2018-10-31 00:00:00.0000000', N'1', N'273.4400', N'3942.6000', N'382.8000', N'3559.8000', N'Noroden E. Lacoto', N'Admin')
GO


-- ----------------------------
-- Table structure for tblPayrollofEmployees
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPayrollofEmployees]') AND type IN ('U'))
	DROP TABLE [dbo].[tblPayrollofEmployees]
GO

CREATE TABLE [dbo].[tblPayrollofEmployees] (
  [empPayrollTransNo] int  IDENTITY(1,1) NOT NULL,
  [payrollID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [employeeID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [totalWorkedDays] money  NULL,
  [absent] money  NULL,
  [rhd] decimal(18)  NULL,
  [nwhd] decimal(18)  NULL,
  [regHolidays] decimal(18)  NULL,
  [NonWorkHolidays] decimal(18)  NULL,
  [leavePay] money  NULL,
  [overtimeHRS] money  NULL,
  [restdayReportHRS] money  NULL,
  [lateUTMins] money  NULL,
  [basicPay] money  NULL,
  [regHolidayPay] money  NULL,
  [nonWorkHolidayPay] money  NULL,
  [leavePayCash] money  NULL,
  [overtimePay] money  NULL,
  [restdayReportAmount] money  NULL,
  [lateUndertimeDed] money  NULL,
  [cashAdvance] money  NULL,
  [wHoldingTax] money  NULL,
  [sssPrems] money  NULL,
  [piPrems] money  NULL,
  [phPrems] money  NULL,
  [sssLoans] money  NULL,
  [piLoans] money  NULL,
  [ledgerBalance] money  NULL,
  [grossPay] money  NULL,
  [Deduction] money  NULL,
  [Netpay] money  NULL
)
GO

ALTER TABLE [dbo].[tblPayrollofEmployees] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblPayrollofEmployees
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tblPayrollofEmployees] ON
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'44', N'PR-00001', N'EMP-00015', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'23.0000', N'3150.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'16.7700', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3133.2300', N'.0000', N'3133.2300')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'45', N'PR-00001', N'EMP-00025', N'10.5000', N'1.5000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'10.0000', N'3265.5000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'6.4800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3259.0200', N'.0000', N'3259.0200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'46', N'PR-00001', N'EMP-00026', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'10.0000', N'2799.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'6.4800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'2792.5200', N'.0000', N'2792.5200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'47', N'PR-00001', N'EMP-00027', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'20.0000', N'2799.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'12.9600', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'2786.0400', N'.0000', N'2786.0400')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'48', N'PR-00001', N'EMP-00028', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'25.0000', N'3110.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'16.2000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3093.8000', N'.0000', N'3093.8000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'49', N'PR-00001', N'EMP-00029', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'35.0000', N'2799.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'22.6800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'2776.3200', N'.0000', N'2776.3200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'50', N'PR-00001', N'EMP-00001', N'12.0000', N'.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'21.0000', N'4201.1200', N'.0000', N'348.8800', N'.0000', N'.0000', N'.0000', N'15.3100', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4534.6900', N'.0000', N'4534.6900')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'51', N'PR-00001', N'EMP-00021', N'12.0000', N'.0000', N'0', N'1', N'0', N'8', N'.0000', N'.0000', N'.0000', N'.0000', N'4385.7800', N'.0000', N'473.4800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4859.2700', N'.0000', N'4859.2700')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'52', N'PR-00001', N'EMP-00022', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'18.0000', N'3500.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'13.1300', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3486.8800', N'.0000', N'3486.8800')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'53', N'PR-00001', N'EMP-00002', N'12.0000', N'.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'5309.1100', N'.0000', N'440.8900', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5750.0000', N'.0000', N'5750.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'54', N'PR-00001', N'EMP-00003', N'12.0000', N'.0000', N'0', N'1', N'0', N'8', N'.0000', N'.0000', N'.0000', N'.0000', N'6924.9200', N'.0000', N'747.6000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'7672.5200', N'.0000', N'7672.5200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'55', N'PR-00001', N'EMP-00024', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'20.0000', N'3110.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'12.9600', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3097.0400', N'.0000', N'3097.0400')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'56', N'PR-00001', N'EMP-00004', N'9.5000', N'2.5000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'167.0000', N'3328.9100', N'.0000', N'348.8800', N'.0000', N'.0000', N'.0000', N'121.7700', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3556.0200', N'.0000', N'3556.0200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'57', N'PR-00001', N'EMP-00006', N'12.0000', N'.0000', N'0', N'1', N'0', N'6', N'.0000', N'.0000', N'.0000', N'48.0000', N'4200.0000', N'.0000', N'341.2500', N'.0000', N'.0000', N'.0000', N'35.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4506.2500', N'.0000', N'4506.2500')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'58', N'PR-00001', N'EMP-00020', N'11.0000', N'1.0000', N'0', N'1', N'0', N'0', N'.0000', N'4.0000', N'.0000', N'.0000', N'3850.0000', N'.0000', N'.0000', N'.0000', N'175.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4025.0000', N'.0000', N'4025.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'59', N'PR-00001', N'EMP-00030', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'10.0000', N'2799.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'6.4800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'2792.5200', N'.0000', N'2792.5200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'60', N'PR-00001', N'EMP-00013', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'3500.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3500.0000', N'.0000', N'3500.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'61', N'PR-00001', N'EMP-00005', N'10.0000', N'1.0000', N'0', N'2', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'4427.3200', N'.0000', N'881.7900', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5309.1100', N'.0000', N'5309.1100')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'62', N'PR-00001', N'EMP-00031', N'11.0000', N'1.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'1.0000', N'3421.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.6500', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3420.3500', N'.0000', N'3420.3500')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'63', N'PR-00001', N'EMP-00032', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'4.0000', N'3110.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'2.5900', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3107.4100', N'.0000', N'3107.4100')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'64', N'PR-00001', N'EMP-00008', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'98.0000', N'3500.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'71.4600', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3428.5400', N'.0000', N'3428.5400')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'65', N'PR-00001', N'EMP-00017', N'10.0000', N'2.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'7.0000', N'3500.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5.1000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3494.9000', N'.0000', N'3494.9000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'66', N'PR-00001', N'EMP-00010', N'11.5000', N'.5000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'4600.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4600.0000', N'.0000', N'4600.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'67', N'PR-00001', N'EMP-00011', N'11.0000', N'1.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'10.0000', N'4400.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'8.3300', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4391.6700', N'.0000', N'4391.6700')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'68', N'PR-00001', N'EMP-00014', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'14.0000', N'4159.7400', N'.0000', N'460.0600', N'.0000', N'.0000', N'.0000', N'13.4600', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4606.3500', N'.0000', N'4606.3500')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'69', N'PR-00001', N'EMP-00023', N'11.0000', N'1.0000', N'0', N'1', N'0', N'0', N'.0000', N'4.0000', N'.0000', N'4.0000', N'3410.0000', N'.0000', N'.0000', N'.0000', N'155.0000', N'.0000', N'2.5800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3562.4200', N'.0000', N'3562.4200')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'70', N'PR-00001', N'EMP-00018', N'12.0000', N'.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'1.0000', N'4800.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.8300', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4799.1700', N'.0000', N'4799.1700')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'71', N'PR-00001', N'EMP-00016', N'9.0000', N'3.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'3600.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3600.0000', N'.0000', N'3600.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'72', N'PR-00001', N'EMP-00007', N'11.0000', N'1.0000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'44.0000', N'7196.4900', N'.0000', N'651.7600', N'.0000', N'.0000', N'.0000', N'59.9400', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'7788.3100', N'.0000', N'7788.3100')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'73', N'PR-00001', N'EMP-00019', N'10.5000', N'1.5000', N'0', N'1', N'0', N'0', N'.0000', N'.0000', N'.0000', N'6.0000', N'3675.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4.3800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'3670.6300', N'.0000', N'3670.6300')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'206', N'PR-00002', N'EMP-00004', N'13.0000', N'.0000', N'0', N'0', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'7500.0000', N'.0000', N'.0000', N'.0000', N'359.4200', N'.0000', N'27.5600', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'7831.8700', N'.0000', N'7831.8700')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'207', N'PR-00003', N'EMP-00004', N'12.0000', N'.0000', N'0', N'0', N'0', N'0', N'.0000', N'.0000', N'.0000', N'.0000', N'7500.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'17.9700', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'7482.0300', N'651.4700', N'6830.5600')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [employeeID], [totalWorkedDays], [absent], [rhd], [nwhd], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [restdayReportHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [restdayReportAmount], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [ledgerBalance], [grossPay], [Deduction], [Netpay]) VALUES (N'208', N'PR-00004', N'EMP-00015', N'10.5000', N'3.5000', N'0', N'0', N'0', N'0', N'.0000', N'5.0000', N'.0000', N'8.0000', N'3675.0000', N'.0000', N'.0000', N'.0000', N'273.4400', N'.0000', N'5.8300', N'.0000', N'.0000', N'145.3000', N'100.0000', N'137.5000', N'.0000', N'.0000', N'.0000', N'3942.6000', N'382.8000', N'3559.8000')
GO

SET IDENTITY_INSERT [dbo].[tblPayrollofEmployees] OFF
GO


-- ----------------------------
-- Table structure for tblSpouseInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSpouseInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[tblSpouseInfo]
GO

CREATE TABLE [dbo].[tblSpouseInfo] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [employeeID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [lastname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [firstname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [middlename] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblSpouseInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblSystemSettings
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSystemSettings]') AND type IN ('U'))
	DROP TABLE [dbo].[tblSystemSettings]
GO

CREATE TABLE [dbo].[tblSystemSettings] (
  [systemID] int  NOT NULL,
  [backupDir] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblSystemSettings] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table tblBenefitsPaymentSum
-- ----------------------------
ALTER TABLE [dbo].[tblBenefitsPaymentSum] ADD CONSTRAINT [PK__tblBenef__9FE512694CA06362] PRIMARY KEY CLUSTERED ([premsID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblChildrenInfo
-- ----------------------------
ALTER TABLE [dbo].[tblChildrenInfo] ADD CONSTRAINT [PK__tblChild__3213E83F07020F21] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblDesciplinaryAction
-- ----------------------------
ALTER TABLE [dbo].[tblDesciplinaryAction] ADD CONSTRAINT [PK__tblDesci__8E560CD00EA330E9] PRIMARY KEY CLUSTERED ([descActionNo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblEmployeesInfo
-- ----------------------------
ALTER TABLE [dbo].[tblEmployeesInfo] ADD CONSTRAINT [PK__tblEmplo__C134C9A17F60ED59] PRIMARY KEY CLUSTERED ([employeeID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblLeave
-- ----------------------------
ALTER TABLE [dbo].[tblLeave] ADD CONSTRAINT [PK__tblLeave__CB45E81B1273C1CD] PRIMARY KEY CLUSTERED ([leaveNo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblPayroll
-- ----------------------------
ALTER TABLE [dbo].[tblPayroll] ADD CONSTRAINT [PK__tblPayro__EBDFA71A03317E3D] PRIMARY KEY CLUSTERED ([payrollID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblPayrollofEmployees
-- ----------------------------
ALTER TABLE [dbo].[tblPayrollofEmployees] ADD CONSTRAINT [PK__tblPayro__AB921DDA0EA330E9] PRIMARY KEY CLUSTERED ([empPayrollTransNo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblSpouseInfo
-- ----------------------------
ALTER TABLE [dbo].[tblSpouseInfo] ADD CONSTRAINT [PK__tblSpous__3213E83F03317E3D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblSystemSettings
-- ----------------------------
ALTER TABLE [dbo].[tblSystemSettings] ADD CONSTRAINT [PK__tblSyste__5C4AE16E145C0A3F] PRIMARY KEY CLUSTERED ([systemID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

