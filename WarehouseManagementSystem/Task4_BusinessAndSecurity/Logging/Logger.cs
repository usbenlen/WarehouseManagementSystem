using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Task1_DataModel.Products;

namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Logging;

public class Logger : ILogger
{
    private readonly List<string> LogInfo = new();
    public void Info(string message)
    {
        LogInfo.Add(message);
    }

    public void Warn(string message)
    {
        LogInfo.Add(message);
    }

    public void Error(string message)
    {
        LogInfo.Add(message);
    }
}
