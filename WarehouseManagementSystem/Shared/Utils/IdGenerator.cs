using System;

namespace WarehouseManagementSystem.Shared.Utils;

public static class IdGenerator
{
    public static string Generate()
    {
        return Guid.NewGuid().ToString("N");
    }
}
