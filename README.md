# FNF_Training

Day 1: Basics, Arrays, Enum, Classes and Objects.
https://github.com/Sakshi-1812/FNF_Training/blob/main/Ex04_ClassesAndObjects


private static void UpdateDeviceDetails()
{
    string slno = MyConsole.GetString("Enter the serial number of the device you want to update:");
    Machine updatedMachine = new Machine
    {
        SlNo = slno,
        Make = MyConsole.GetString("Enter the new make:"),
        Model = MyConsole.GetString("Enter the new model:"),
        Price = MyConsole.GetInt("Enter the new price:")
    };

    MachineDatabase database = new MachineDatabase();
    database.UpdateDeviceDetails(slno, updatedMachine);

    Console.WriteLine("Device details updated successfully.");
}
