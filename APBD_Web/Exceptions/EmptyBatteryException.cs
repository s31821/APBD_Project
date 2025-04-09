namespace DeviceManager.Exceptions;

public class EmptyBatteryException(string? message) : Exception(message);