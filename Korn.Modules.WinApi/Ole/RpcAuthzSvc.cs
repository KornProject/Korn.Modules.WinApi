﻿namespace Korn.Modules.WinApi.Ole
{
    public enum RpcAuthzSvc : uint
    {
        None = 0,
        Name = 1,
        Dce = 2,
        Default = 0xFFFFFFFF
    }
}