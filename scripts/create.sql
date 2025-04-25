DROP TABLE Embedded;
DROP TABLE PersonalComputer;
DROP TABLE Smartwatch;
DROP TABLE Device;

create table Device
(
    Id        varchar(255) not null
        primary key,
    Name      varchar(255) not null,
    IsEnabled bit     not null
);
create table Embedded
(
    Id          int         not null
        primary key,
    IpAddress    varchar(255)    not null,
    NetworkName varchar(255)     not null,
    DeviceId    varchar(255)     not null
        constraint Embedded_Device_Id_fk
            references Device (Id)
);
create table PersonalComputer
(
    Id              int     not null
        primary key,
    OperationSystem varchar(255),
    DeviceId        varchar(255) not null
        constraint PersonalComputer_Device_Id_fk
            references Device (Id)
);
create table Smartwatch
(
    Id                int     not null
        primary key,
    BatteryPercentage int     not null,
    DeviceId          varchar(255) not null
        constraint Smartwatch_Device_Id_fk
            references Device (Id)
);













