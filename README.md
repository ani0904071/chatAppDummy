# Chat App (test)

## Table of contents

1. who to talk to
2. technical information
3. setting up your project
4. running and testing

### 1. who to talk to
```
Design:                     Animesh Kar
Frontend:                   Animesh Kar
Backend:                    Animesh Kar
```

### 2. technical information
This app is setup with the Angular 7.0.1, .Net Core 3.1 Framework, SQL Server!
For more information and documentation, visit https://dotnet.microsoft.com/download, https://cli.angular.io/, https://nodejs.org/en/download/

### 3. setting up your project

#### steps
1. First off, you need to have Node installed globally. This can be done by executing: ```npm i -g @angular/cli@ 7.0.1``` 
2. Clone this repository
3. Navigate to your project `client` folder (for UI)
3. Run ```npm install```
5. Run ```ng serve``` and in your browser it will run on http://localhost:4200, Routes [http://localhost:4200/register, http://localhost:4200/login/, http://localhost:4200/user]
6. Run ```dotnet watch run``` in `\ChatApplication\ChatApplication` directory, in your browser it will run on http://localhost:4200


#### used setup (global)

1. Node
2. .Net Core 
3. Angular
4. SQL Server
5. Insomnia (for API Doc)


### 4. running and testing

#### create tables : Run the following SQL commands to start off: [User Id = 'root', Password = 'root']
   
CREATE TABLE [dbo].[TblUser](
    [UserID] [int] IDENTITY(1,1) NOT NULL,
    [FirstName] [varchar](50) NOT NULL,
    [Email] [varchar](50) NOT NULL,
    [LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED
(
    [UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TblChatDetails](
    [ChatID] [int] IDENTITY(1,1) NOT NULL,
    [CreatedAt] [datetime] NOT NULL CONSTRAINT CreateTS_DF DEFAULT CURRENT_TIMESTAMP,
    [FromUserID] [int] NOT NULL,
    [ChatText] [text] NOT NULL,
    [ToUserID] [int] NOT NULL
 CONSTRAINT [PK_TblChatDetails] PRIMARY KEY CLUSTERED
(
    [ChatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

#### test apis 
with `ChatApp_APIs_Insomnia_.json`

1. Initial Login after Registration will create a JWT Token
2. Put ``Authorization`` Header and give the value of `Bearer Generated_Token`
