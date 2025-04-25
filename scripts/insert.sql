insert into Device (Id, Name, IsEnabled) values
                                             ('SW-1', 'Apple Watch SE2', 1),
                                             ('P-1', 'LinuxPC', 0),
                                             ('P-2', 'ThinkPad T440', 0),
                                             ('ED-1', 'Pi3', 1),
                                             ('ED-2', 'Pi4', 0),
                                             ('ED', 'SmartHeater', 0);

insert into Smartwatch (Id, BatteryPercentage, DeviceId) values
    (1, 27, 'SW-1');

insert into PersonalComputer (Id, OperationSystem, DeviceId) values
                                                                 (1, 'Linux Mint', 'P-1'),
                                                                 (2, null, 'P-2');

insert into Embedded (Id, IpAddress, NetworkName, DeviceId) values
                                                                (1, '192.168.1.44', 'MD Ltd.Wifi-1', 'ED-1'),
                                                                (2, '192.168.1.45', 'eduroam', 'ED-2'),
                                                                (3, '192.168.0.125', 'Home', 'ED');
